using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula08
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagem = "";
            try
            {
                Console.WriteLine("BEM VINDO ao Sistema de Cadaastro de Contas");
                List<ContaBancaria> listContas = new List<ContaBancaria>();

                ContaBancaria contaBancaria1 = new ContaBancaria("Conta Corrente", 1, 1, 547.8);
                //contaBancaria1.Tipo = "Conta Corrente";
                //contaBancaria1.Numero = 00027;
                //contaBancaria1.Agencia = 0001;
                listContas.Add(contaBancaria1);
                Console.WriteLine($"Conta Bancária 1 da Agência: {contaBancaria1.Agencia} " +
                    $"com Número de Conta = {contaBancaria1.Numero} é do tipo {contaBancaria1.Tipo} e possui Saldo de: {contaBancaria1.Saldo}.");

                ContaBancaria contaBancaria2 = new ContaBancaria("Conta Poupança", 2, 2, 1487.22);
                //contaBancaria2.Tipo = "Conta Poupança";
                //contaBancaria2.Numero = 00086;
                //contaBancaria2.Agencia = 0002;
                listContas.Add(contaBancaria2);
                Console.WriteLine(contaBancaria2.ExibirDados());

                for (int cont = 1; cont <= 3; cont++)
                {
                    Console.WriteLine("Digite a Agência:");
                    int agencia = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Tipo de Conta:");
                    string tipo = Console.ReadLine();
                    Console.WriteLine("Digite o Número da Conta:");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Saldo Inicial:");
                    double saldo = Convert.ToDouble(Console.ReadLine());

                    ContaBancaria contaBancaria = new ContaBancaria(tipo, numero, agencia, saldo);
                    listContas.Add(contaBancaria);
                }
                int numConta;
                do
                {
                    Console.WriteLine("Digite o Número da Conta que deseja exibir os Dados (Zero '0' para Sair): ");
                    numConta = Convert.ToInt32(Console.ReadLine());
                    if (listContas.Where(conta => conta.Numero == numConta).Any())
                    {
                        ContaBancaria contaBusacada = listContas.Where(conta => conta.Numero == numConta).FirstOrDefault();
                        Console.WriteLine(contaBusacada.ExibirDados());
                    }
                    else
                    {
                        Console.WriteLine("Essa Conta Não Existe!!");
                    }
                } while (numConta != 0);

            }
            catch (Exception e)
            {
                mensagem = $"Ooops! Ocorreu o seguinte Erro: {e.Message}";
            }
            finally
            {
                mensagem = "Bye, Bye... fim do Programa!";
                Console.WriteLine(mensagem);
            }
        }
    }
}
