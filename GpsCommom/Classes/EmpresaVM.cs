using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsCommom.Classes
{
    public class EmpresaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int TipoEmpresa { get; set; }
        public string CapitalSocial { get; set; }
        public string Procura { get; set; }
        public string Socios { get; set; }
        public DateTime DataAbertura { get; set; }
        public ResultadoVM Resultado { get; set; } = new ResultadoVM();
        public RetornoApi ResultadoApi { get; set; } = new RetornoApi();
        public void ValidarEmpresa(EmpresaVM emVM)
        {
            if (string.IsNullOrEmpty(emVM.Nome) || string.IsNullOrEmpty(emVM.Cnpj))
            {
                emVM.Resultado.Erro = true;
                emVM.Resultado.Mensagem = "Campo Vazio ou Nullo";
            }
        }

    }
}
