using System;
using System.Collections.Generic;
using static Aula10_2.FormaPagamento;

namespace Aula10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite 3 produtos que queira comprar: ");
            List<string> produtos = new List<string>();
            for (int i=0; i<3; i++)
            {
                produtos.Add(Console.ReadLine());
            }
            Console.WriteLine("Qual a Forma de Pagamento(Boleto, Cartão ou Pix)? ");
            string formaPagamento = Console.ReadLine();
            if (formaPagamento == FormasPagamentoEnum.Boleto.ToString())
            {
                Boleto boleto = new Boleto();
                boleto.EfetuarPagamento();
            }
            else if (formaPagamento == FormasPagamentoEnum.Cartao.ToString())
            {
                Cartao cartao = new Cartao();
                cartao.EfetuarPagamento();
            }
            else if(formaPagamento == FormasPagamentoEnum.Pix.ToString())
            {
                Pix pix = new Pix();
                pix.EfetuarPagamento();
            }
            else
            {
                FormaPagamento pagamento = new FormaPagamento();
                pagamento.EfetuarPagamento();
            }
        }
    }
}
