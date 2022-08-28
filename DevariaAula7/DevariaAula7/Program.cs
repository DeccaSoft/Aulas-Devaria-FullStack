using System;
using System.Collections.Generic;
using System.Linq;

namespace DevariaAula7
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagem = "";
            List<string> listaMercado = new List<string>()
            {
                "Tomate", "Cebola", "Batata", "Cenoura", "Alaface", "Banana", "Goiaba", "Laranja","Maçã", "Limão","Uva"
            };

            try
            {
                Console.WriteLine("Qual Produto vc Deseja Comprar? ");
                string produtoSelecionado = Console.ReadLine();
                bool validaProduto = listaMercado.Where(l => l.Equals(produtoSelecionado)).Any();
                if (validaProduto)
                {
                    Console.WriteLine("Produto com Estoque, vc pode comprar: " + produtoSelecionado);
                }
                else
                {
                    Console.WriteLine("Produto SEM Estoque...");
                }

                Console.WriteLine("Produtos Disponíveis em Estoque: ");
                foreach(string produto in listaMercado.OrderBy(produto => produto))
                {
                    Console.WriteLine(produto);
                }
                mensagem = "Obrigado e Boas Compras!";
            }
            catch (Exception e)
            {
                mensagem = "Ooops! Aconteceu o seguinte problema: " + e.Message;
            }
            finally
            {
                Console.WriteLine(mensagem);
            }
        }
    }
}
