using System;
using System.Collections.Generic;

namespace InvesteCerto
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoMenu = OpcaoMenu();
            while (opcaoMenu.ToUpper() != "X")
            {
                Console.Clear();
                switch (opcaoMenu)
                {
                    case "1":
                        CadastrarConta();
                        break;
                    case "2":
                        ConsultarSaldo();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        break;
                    case "6":
                        ListarContas();
                        break;
                    case "7":
                        break;
                    default:
                        break;
                }
                opcaoMenu = OpcaoMenu();
            }
        }

        private static void Depositar()
        {
            string opcao;
            string nome;
            double valor;

            if (VerificaContas()) { }
            else
            {
                Console.WriteLine(" +-------------------------------+\n" +
                                  " |        Procurar Conta         |\n" +
                                  " |-------------------------------|\n" +
                                  " | 1 - Procurar por Nome         |\n" +
                                  " | 2 - Procurar por RG           |\n" +
                                  " +-------------------------------+\n");
                Console.Write(" >>Escolha uma das opções: ");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.Write(" >>Digite o seu nome: ");
                    nome = Console.ReadLine();
                    Console.WriteLine("");
                    foreach (var item in ListaContas)
                    {
                        if (item.Titular == nome)
                        {
                            Console.Write(" Informe Valor: ");
                            valor = double.Parse(Console.ReadLine());
                            item.Deposita(valor);
                        }
                    }
                }
            }
        }
        private static void Transferir()
        {
            string nome;
            string nomeDestino; // INDICA CONTA PARA TRANSFERENCIA
            double valor;

            if (VerificaContas()) { }
            else
            {
                Console.WriteLine(" +-------------------------------+\n" +
                                  " |         Transferir            |\n" +
                                  " |-------------------------------|\n" +
                                  " | 1 - Procurar por Nome         |\n" +
                                  " +-------------------------------+\n");
                Console.Write(    " >>Digite o seu nome: ");
                nome = Console.ReadLine();

                Console.Write(    " >>Digite o valor: ");
                valor = double.Parse(Console.ReadLine());
                
                Console.Write(    " >>Digite o nome da conta de destino: ");
                nomeDestino = Console.ReadLine();
                foreach (var item in ListaContas)
                {
                    if (item.Titular == nome)
                    {
                        foreach (var itemD in ListaContas)
                        {
                            if (itemD.Titular == nomeDestino)
                            {
                                if (item.Saldo >= valor)
                                {
                                    item.Transferir(valor, itemD);
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void ConsultarSaldo()
        {
            string opcao;
            string nome;
            int rg;
            //VERIFICA SE HÁ CONTAS CADASTRADAS
            if (VerificaContas()){}
            else
            {
                Console.WriteLine(" +-------------------------------+\n" +
                                  " |        Consultar Saldo        |\n" +
                                  " |-------------------------------|\n" +
                                  " | Procurar Conta por:           |\n" +
                                  " | 1 - Nome                      |\n" +
                                  " | 2 - RG                        |\n" +
                                  " +-------------------------------+\n");
                Console.Write(" >>Escolha uma das opções: ");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.Write(" >>Digite o nome: ");
                    nome = Console.ReadLine();
                    Console.WriteLine("");//APENAS PARA PULAR LINHA...
                    foreach (var item in ListaContas)
                    {
                        if (item.Titular == nome)
                        {
                            Console.WriteLine("Saldo: "+ item.Saldo);
                        }
                    }
                }
                else if (opcao == "2")
                {
                    Console.Write(" >>Digite o RG: ");
                    rg = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    foreach (var item in ListaContas)
                    {
                        if (item.RG == rg)
                        {
                            Console.WriteLine(" Saldo: " + item.Saldo);
                        }
                    }
                }
            }
        }

        //LISTAR AS CONTAS CADASTRADAS
        private static void ListarContas()
        {
            string opcao;
            int rg;
            string nome;
            // VERIFICA SE HÁ CONTAS CADASTRADAS
            if (VerificaContas()){}
            else
            {
                //OPÇÕES DE PESQUISA
                Console.WriteLine(" +-------------------------------+\n" +
                                  " |     Relatório de Contas       |\n" +
                                  " |-------------------------------|\n" +
                                  " | 1 - Listar todas as Contas    |\n" +
                                  " | 2 - Procurar Conta específica |\n" +
                                  " +-------------------------------+");
                Console.Write(    " >>Escolha uma das opções: ");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.WriteLine(" +-------------------------------+\n" +
                                      " |        Todas as contas        |\n" +
                                      " +-------------------------------+\n" );
                    foreach (var item in ListaContas)
                    {
                        Console.WriteLine($"{ item }");
                    }
                }
                else
                {
                    Console.WriteLine(" +-------------------------------+\n" +
                                      " |        Procurar Conta         |\n" +
                                      " |-------------------------------|\n" +
                                      " | 1 - Procurar por Nome         |\n" +
                                      " | 2 - Procurar por RG           |\n" +
                                      " +-------------------------------+\n");
                    Console.Write(" >>Escolha uma das opções: ");
                    opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        Console.Write(" >>Digite o nome: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("");
                        foreach (var item in ListaContas)
                        {
                            if (item.Titular == nome)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                    else if (opcao == "2")
                    {
                        Console.Write(" >>Digite o RG: ");
                        rg = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        foreach (var item in ListaContas)
                        {
                            if (item.RG == rg)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
            }
        }
        //CADASTRO DE NOVAS CONTAS
        private static void CadastrarConta()
        {
            string nome;
            int rg;
            int numero = ListaContas.Count + 1;
            Console.WriteLine(" +-------------------------------+\n" +
                              " |      Cadastro de Contas       |\n" +
                              " |-------------------------------|\n" +
                              " | Informações necessárias:      |\n" +
                              " | 1 - Nome do Titular           |\n" +
                              " | 2 - RG do Titular             |\n" +
                              " +-------------------------------+");
            Console.Write(    " >>Informe o nome do Titular: ");
            nome = Console.ReadLine();
            Console.Write(    " >>Informe o RG do Titular: ");
            rg = int.Parse(Console.ReadLine());
            Console.Write(" Agradecemos a preferência, aproveite\n");
            //GRAVA INFORMAÇÕES NA LISTA CONTAS
            Conta novaConta = new Conta(nome, rg, numero);
            ListaContas.Add(novaConta);
        } 
        //VERIFICA SE HÁ CONTAS CADASTRADAS
        static bool VerificaContas()
        {
            if (ListaContas.Count == 0)
            {
                Console.WriteLine(" +-------------------------------+\n" +
                                  " |     Relatório de Contas       |\n" +
                                  " |-------------------------------|\n" +
                                  " | Não há contas cadastradas     |\n" +
                                  " +-------------------------------+\n");
                return true;
            }
            return false;
        }
        // PEGA A OPÇÃO DO USUÁRIO
        static string OpcaoMenu()
        {
            string opcao;
            Console.WriteLine(" +------------------------------+\n" +
                              " |  Bem Vindo ao Investe Certo  |\n" +
                              " |------------------------------|\n" +
                              " | 1 - Cadastrar Conta          |\n" +
                              " | 2 - Consultar Saldo          |\n" +
                              " | 3 - Transferir               |\n" +
                              " | 4 - Depositar                |\n" +
                              " | 5 - Sacar                    |\n" +
                              " | 6 - Listar Contas            |\n" +
                              " | 7 - Deletar Conta            |\n" +
                              " | X - Sair                     |\n" +
                              " +------------------------------+");
            Console.Write(    " >> Escolha uma das opções: ");
            opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    }
}
