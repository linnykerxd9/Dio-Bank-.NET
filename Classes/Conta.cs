using Dio.bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.bank.Classes
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double saque)
        {
            if(this.Saldo - saque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= saque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;

        }

        public void Depositar(double deposito)
        {
            this.Saldo += deposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double transferencia, Conta contaTrasferencia)
        {
            if (this.Sacar(transferencia))
            {
                contaTrasferencia.Depositar(transferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";

            return retorno;
        }
        
    }
}
