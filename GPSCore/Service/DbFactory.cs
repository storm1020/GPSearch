using GpsCommom.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSCore.Service
{
    public class DbFactory
    {
        public void SalvarEmpresa(EmpresaVM emVM)
        {
            emVM.ValidarEmpresa(emVM);

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

        //chamar api no metodo 
    }
}
