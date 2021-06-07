using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Gabriel Delgado");

            string opUser = ObterOpcaoUser();

            while (opUser.ToUpper() != "X")
            {
                switch (opUser)
                {
                    case "1":
                       Listarcontas();
                        break;
                    
                    case "2":
                        Inserirconta();
                        break;
                    
                    case "3":
                        Transferir();
                        break;
                    
                    case "4":
                        Sacar();
                        break;
                    
                    case "5":
                        Depositar();
                        break;
                    
                    case "C":
                        Console.Clear();
                        break;
                    
                    case "X":
                        Console.WriteLine("Obrigado por utilizar os nossos serviços!");
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opUser = ObterOpcaoUser();
            }
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTranferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número de conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número de conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Listarcontas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta Conta = listaContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(Conta);
            }

        }

        private static void Inserirconta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para conta fisica e 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome: entradaNome,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        tipoConta: (TipoConta)entradaTipoConta);

            listaContas.Add(novaConta);

        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Bank!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar contas,");
            Console.WriteLine("2 - Inserir nova conta,");
            Console.WriteLine("3 - Transferir,");
            Console.WriteLine("4 - Sacar,");
            Console.WriteLine("5 - Depositar,");
            Console.WriteLine("C - Limpar Tela,");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
            
        }
    }
}
