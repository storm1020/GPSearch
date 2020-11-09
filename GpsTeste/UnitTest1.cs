using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GpsCommom.Classes;
using GPSCore.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GpsTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTest()
        {
            EmpresaVM eVM = new EmpresaVM();

            eVM.Nome = "Iago";
            eVM.Cnpj = "0123";
            eVM.TipoEmpresa = "";
            eVM.CapitalSocial = "XPTO";
            eVM.Procura = "XPTO";
            eVM.Socios = "XPTO";
            //var dataS = DateTime.Today.ToString("yyyy-MM-dd");
            //var data = DateTime.Parse(dataS);
            eVM.DataAbertura = "";


            DbFactory df = new DbFactory();
            df.SalvarEmpresa(eVM);
        }

        [TestMethod]
        public void BuscarApiTest()
        {
            var retorno = Task.Run(() => Api());
        }

        public async void Api()
        {
            try
            {
                var cnpj = "25091550000194";
                var url = @"https://www.receitaws.com.br/v1/cnpj/" + cnpj;
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(url);
                var retorno = await response.Content.ReadAsAsync<RetornoApi>();

            }
            catch (Exception ex)
            {
                var mensagem = ex.Message;
            }
        }

    }
}
