using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsCommom.Classes
{
    public class RetornoApi
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Status { get; set; }
        public string Mensagem { get; set; }
        public string Cnpj { get; set; }
        public string TipoEmpresa { get; set; }
        public string DataAbertura { get; set; }
        public string CapitalSocial { get; set; }
        public string Procura { get; set; }
        public string Socios { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Email { get; set; }
        public ResultadoVM resultadoVM { get; set; }

        public RetornoApi()
        {

        }
        public RetornoApi(string nome, string nomeFantasia, string status, string mensagem, string cnpj, string tipoEmpresa,
            string dataAbertura, string capitalSocial, string procura, string socios, string numero, string cep, string bairro, string uf, string telefone,
            string logradouro, string complemento, string municipio, string email)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Status = status;
            Mensagem = mensagem;
            Cnpj = cnpj;
            TipoEmpresa = tipoEmpresa;
            DataAbertura = dataAbertura;
            CapitalSocial = capitalSocial;
            Procura = procura;
            Socios = socios;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Uf = uf;
            Telefone = telefone;
            Logradouro = logradouro;
            Complemento = complemento;
            Municipio = municipio;
            Email = email;
        }

    }
}
