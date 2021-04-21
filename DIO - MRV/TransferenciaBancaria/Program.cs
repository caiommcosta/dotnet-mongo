using System;
using System.Collections.Generic;

namespace TransferenciaBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Caio");

            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
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
                        LimparTela();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            System.Console.ReadLine();

        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void Depositar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            
            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Tranferir(valorTransferencia, listaContas[indiceContaDestino]);
        }
        private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            
            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Insir a nova conta: ");
            System.Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            
            System.Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta (tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo,
                                         credito: entradaCredito,
                                         nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listando as contas...");

            if (listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada.");
            }

            for (int i=0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }
        }
        public static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("BANK BANK ao seu Dispor");
            System.Console.WriteLine("Informe a opção desejada");

            System.Console.WriteLine("1 - Listar Contas");
            System.Console.WriteLine("2 - Inserir nova conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");

            string OpcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
