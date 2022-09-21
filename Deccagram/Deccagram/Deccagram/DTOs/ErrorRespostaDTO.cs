using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deccagram.DTOs
{
    public class ErrorRespostaDTO
    {
        public int Status { get; set; }
        public string Descricao { get; set; }
        public List<string> Erros { get; set; }
    }
}
