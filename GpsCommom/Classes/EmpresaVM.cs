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
        public string Empresa { get; set; }
        public ResultadoVM Resultado { get; set; } = new ResultadoVM();
    }
}
