using System;
using System.Collections.Generic;

namespace Conta.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por ultilizar nossos serviços");
            Console.WriteLine("Tenha um ótimo dia =D");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("O Banco PoupaAqui está ao seu Dispor!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir uma nova Conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas(){
            Console.WriteLine("Listar Contas: ");

            if (listContas.Count == 0 ){
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }
            for(int i = 0; i < listContas.Count;i++){
                Conta conta = listContas[i];
                Console.Write("Número da Conta: #{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        private static void Depositar(){
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado: ");
            double ValorDespositado = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(ValorDespositado);
        }

        private static void SacarConta(){
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque= double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void Transferir(){
            Console.Write("Digite o número da sua Conta: ");
            int indiceContaOriginal = int.Parse(Console.ReadLine());

            Console.Write("Digite a Conta que deseja Tansferir o Valor: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor que deseja Transferir: ");
            double ValorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOriginal].Transferir(ValorTransferencia, listContas[indiceContaDestino]);
        }

    }
}
