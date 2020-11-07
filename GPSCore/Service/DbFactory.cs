using GpsCommom.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSCore.Service
{
    public class DbFactory
    {
        public void PesquisaEmpresa(EmpresaVM emVM)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var pesquisa = db.GpsTblEmpresas.Where(o => o.Id == emVM.Id).FirstOrDefault();

                if(pesquisa == null)
                {
                    emVM.Resultado.Erro = true;
                    emVM.Resultado.Mensagem = "Não encontrou empresa";
                }
                else
                {
                    emVM.Id = pesquisa.Id;
                    emVM.Empresa = pesquisa.CapitalSocial;
                }
            }
        }

        public void ValidarEmpresa(EmpresaVM emVM)
        {
            if(string.IsNullOrEmpty(emVM.Empresa))
            {
                emVM.Resultado.Erro = true;
                emVM.Resultado.Mensagem = "Campo Vazio";
            }
        }

        public void SalvarEmpresa(EmpresaVM emVM)
        {
            ValidarEmpresa(emVM);

            if(!emVM.Resultado.Erro)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var sql = @"insert";
                    StringBuilder sb = new StringBuilder(sql);

                    // SELECT
                    //var retorno = db.Database.SqlQuery<EmpresaVM>(sb.ToString());

                    db.Database.ExecuteSqlCommand(sb.ToString());

                    //Create - Linq
                    GpsTblEmpresa Cem = new GpsTblEmpresa
                    {
                        Id = emVM.Id,
                        CapitalSocial = emVM.Empresa
                    };

                    db.GpsTblEmpresas.Add(Cem);
                    db.SaveChanges();
                }
            }
        }
    }
}
