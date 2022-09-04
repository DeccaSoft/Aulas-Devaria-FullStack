using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula10_2
{
    public class FormaPagamento
    {
        public virtual void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento Efetuado com Sucesso!");
        }

        public class Boleto : FormaPagamento
        {
            public override void EfetuarPagamento()
            {
                Console.WriteLine("Pagamento Efetuado por Boleto");
            }
        }

        public class Cartao : FormaPagamento
        {
            public override void EfetuarPagamento()
            {
                Console.WriteLine("Pagamento Efetuado por Cartão");
            }
        }

        public class Pix : FormaPagamento
        {
            public override void EfetuarPagamento()
            {
                Console.WriteLine("Pagamento Efetuado por Pix");
            }
        }
    }
}
