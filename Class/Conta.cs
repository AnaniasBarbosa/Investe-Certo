using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvesteCerto
{
    class Conta
    {

        public string Titular { get; private set; }
        public int RG { get; private set; }
        private int Numero { get; set; }
        public double Saldo { get; private set; }
        private double Investimento { get; set; }

        public Conta(string titular, int rg, int numero)
        {
            this.Titular = titular;
            this.RG = rg;
            this.Numero = numero;
        }
        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }
        public bool Saca(double valor)
        {
            if(this.Saldo < valor)
            {
                Console.WriteLine(" Não há saldo suficiente\n" +
                                 $" Saldo atual: {this.Saldo}");
                return false;
            }
            this.Saldo -= valor;
            return true;
        }
        public void Investir(double valor)
        {
            this.Saldo += valor * 0.10;
        }
        public void Transferir(double valor, Conta conta)
        {
            if (this.Saldo >= valor)
            {
                this.Saca(valor);
                conta.Deposita(valor);
            }

        }

        public override string ToString()
        {
            string dadosConta = "";
            dadosConta += " Titular: " + this.Titular;
            dadosConta += "\n RG: " + this.RG;
            dadosConta += "\n Numero: " + this.Numero;
            dadosConta += "\n Saldo: " + this.Saldo;
            dadosConta += "\n Investimento " + this.Investimento;
            dadosConta += "\n";

            return dadosConta;
        }

    }
}
