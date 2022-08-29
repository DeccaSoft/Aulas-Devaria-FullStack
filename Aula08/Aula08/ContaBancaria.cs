using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula08
{
    class ContaBancaria
    {
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public double Saldo { get; set; }

        public ContaBancaria(string tipo, int numero, int agencia, double saldo)
        {
            Tipo = tipo;
            Numero = numero;
            Agencia = agencia;
            Saldo = saldo;
        }

        public string ExibirDados()
        {
            return $"Conta Bancária da Agência: {Agencia} com Número de Conta = {Numero} é do tipo {Tipo} e possui Saldo de: {Saldo}.";
        }
    }
}
