using System;

namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }


        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar (double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine();
            Console.WriteLine($"Saldo atual da conta é de {this.Nome} é {this.Saldo, 0:00}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine();
            Console.WriteLine($"Saldo atual da conta é de {this.Nome} é {this.Saldo, 0:00}");
        }

        public void Transferir (double valorTranferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédtio " + this.Credito;
            return retorno;
        }
    }
}