using GpsCommom.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GPSCore.Service
{
    public class DbFactory
    {
        public void SalvarEmpresa(EmpresaVM emVM)
        {
            emVM.ValidarEmpresa(emVM);

            int ultimoIdEmpresa = 0;

            if (!emVM.Resultado.Erro)
            {
                try
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append(@"INSERT INTO dbo.gps_tbl_empresa (Nome, Cnpj, TipoEmpresa, CapitalSocial, Procura, Socios, DataAbertura)");
                        sb.Append("VALUES ('" + emVM.Nome + "', '" + emVM.Cnpj + "', '" + emVM.TipoEmpresa + "', '" + emVM.CapitalSocial + "', '" + emVM.Procura + "', ");
                        sb.Append(" '" + emVM.Socios + "', '" + emVM.DataAbertura + "'  )");

                        db.Database.ExecuteSqlCommand(sb.ToString());

                        ultimoIdEmpresa = BuscarUltimoIdEmpresa();
                        InserirEnderecoEmpresa(ultimoIdEmpresa, emVM);
                        InserirContatoEmpresa(ultimoIdEmpresa, emVM);

                    }
                }
                catch (Exception ex)
                {
                    emVM.Resultado.Mensagem = "Erro ao salvar empresa: " + ex.ToString();
                    emVM.Resultado.Erro = true;
                }
            }
            else
            {
                emVM.Resultado.Mensagem = "Dado de empresa vazio ou nullo";
            }
        }
        private void InserirEnderecoEmpresa(int ultimoIdEmpresa, EmpresaVM emVM)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(@"INSERT INTO dbo.gps_tbl_endereco (Endereco, Numero, Cep, Bairro, Uf, IdEmpresa)");
                    sb.Append("VALUES ('" + emVM.Logradouro + "', '" + emVM.Numero + "', '" + emVM.Cep + "', '" + emVM.Bairro + "', '" + emVM.Uf + "', ");
                    sb.Append(" '" + emVM.Uf + "', '" + ultimoIdEmpresa + "' ");

                    db.Database.ExecuteSqlCommand(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                emVM.Resultado.Mensagem = "Erro ao inserir Endereco Empresa: " + ex.ToString();
                emVM.Resultado.Erro = true;
            }
            
        }
        private void InserirContatoEmpresa(int ultimoIdEmpresa, EmpresaVM emVM)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(@"INSERT INTO gps_tbl_contato_empresa (Telefone, Email, IdEmpresa)");
                    sb.Append("VALUES ('" + emVM.Telefone + "', '" + emVM.Email + "', '" + ultimoIdEmpresa + "' ");

                    db.Database.ExecuteSqlCommand(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                emVM.Resultado.Mensagem = "Erro ao inserir Contato Empresa: " + ex.ToString();
                emVM.Resultado.Erro = true;
            }
        }
        public int BuscarUltimoIdEmpresa()
        {
            EmpresaVM empresaVM = new EmpresaVM();
            int ultimoId = 0;

            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(@"SELECT MAX(Id) FROM dbo.gps_tbl_empresa");

                    ultimoId = db.GpsTblEmpresas.Select(p => p.Id).DefaultIfEmpty(0).Max();
                }
            }
            catch (Exception ex)
            {
                empresaVM.Resultado.Mensagem = "Erro ao pesquisar empresa: " + ex.ToString();
                empresaVM.Resultado.Erro = true;
            }

            return ultimoId;
        }
        public EmpresaVM BuscarPorCnpj(string cnpj)
        {
            EmpresaVM empresaObj = new EmpresaVM();
            var url = @"https://www.receitaws.com.br/v1/cnpj/" + cnpj;
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rtn = response.Content.ReadAsAsync<RetornoApi>();

                    empresaObj = new EmpresaVM(rtn.Result.Nome, rtn.Result.NomeFantasia, rtn.Result.Status, rtn.Result.Mensagem, rtn.Result.Cnpj,
                        rtn.Result.TipoEmpresa, rtn.Result.DataAbertura, rtn.Result.CapitalSocial, rtn.Result.Procura, rtn.Result.Socios,
                        rtn.Result.Numero, rtn.Result.Cep, rtn.Result.Bairro, rtn.Result.Uf, rtn.Result.Telefone, rtn.Result.Logradouro,
                        rtn.Result.Complemento, rtn.Result.Municipio, rtn.Result.Email);
                }
            }
            catch (Exception ex)
            {
                empresaObj.Resultado.Erro = true;
                empresaObj.Resultado.Mensagem = ex.Message;
            }

            return empresaObj;
        }

    }
}
