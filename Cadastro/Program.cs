using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{ 
    class Program
    {
        [System.Serializable]

        struct Cliente
        {
            public string nome;
            public string cpf;
            public string rg;
            public string cel;
        }

        static List<Cliente> Clientes = new List<Cliente>();

        enum Menu { cadastrar = 1, remover = 2, listar = 3, consultar = 4, sair = 5 };

        static void Main(string[] args)
        {
            Carregar();

            bool EscolhaSair = false;
            while (!EscolhaSair) 
            {
                Console.Write("Sistema de clientes\n");
                Console.WriteLine("1 - Cadastrar Cliente\n2 - Remover\n3 - Listar Clientes\n4 - Consultar por CPF\n5 - Sair");
                int intOp = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)intOp;

                switch (opcao)
                {
                    case Menu.cadastrar:
                        Cadastrar();
                        break; 
                    case Menu.remover:
                        Remover();
                        break;
                    case Menu.listar:
                        Listagem();

                        Console.WriteLine("Aperte enter para sair.");
                        Console.ReadLine();
                        break;
                    case Menu.consultar:
                        Console.WriteLine("Para consultar por RG digite 1       Para consultar por CPF digite 2");
                        int c = int.Parse(Console.ReadLine());
                        if (c == 1)
                        {
                            ConsultarRG();
                        }else if (c == 2)
                        {
                            ConsultarCPF();
                        }else
                        {
                            Console.WriteLine("Opção inválida");
                        }
                        break;
                    case Menu.sair:
                        EscolhaSair = true;
                        break;
                }
                Console.Clear();

            }
        }
        static void Listagem()
        {
            if (Clientes.Count > 0)
            {
                Console.WriteLine("Lista de Clientes:");
                int i = 0;
                foreach (Cliente cliente in Clientes)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    Console.WriteLine($"RG: {cliente.rg}");
                    Console.WriteLine($"Celular: {cliente.cel}");
                    Console.WriteLine("=====================================");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente encontrado");
            }
        }
        static void Cadastrar()
        {
            string Cpf;
            string Rg;
            Cliente cliente = new Cliente();
            Console.WriteLine("Cadastro de clientes");
            Console.WriteLine("Nome do cliente");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("CPF do cliente");
            Cpf = Console.ReadLine();
            cliente.cpf = FormatCnpjCpf.FormatCPF(Cpf);
            Console.WriteLine("RG do cliente");
            Rg = Console.ReadLine();
            cliente.rg = FormatCnpjRg.FormatRG(Rg);
            Console.WriteLine("Número de celular do cliente");
            cliente.cel = Console.ReadLine();

            Clientes.Add(cliente);
            Salvar();

            Console.WriteLine("Cadastro concluído, aperte enter para sair.");
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o id do Cliente que deseja remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < Clientes.Count)
            {
                Clientes.RemoveAt(id);
                Salvar();
            }
            else
            {
                Console.WriteLine("Id inválido, tente novamente");
                Console.ReadLine();
            }
        }        
        static void ConsultarCPF()
        {
            int c = Clientes.Count;
            Console.WriteLine("Digite o CPF do cliente:");
            string cpfCon = Console.ReadLine();
            string cpfPes = FormatCnpjCpf.FormatCPF(cpfCon);
            for (int i = 0; i < c; i++)
            {
                if (String.Compare(cpfPes, Clientes[i].cpf) == 0)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {Clientes[i].nome}");
                    Console.WriteLine($"CPF: {Clientes[i].cpf}");
                    Console.WriteLine($"RG: {Clientes[i].rg}");
                    Console.WriteLine($"Celular: {Clientes[i].cel}");
                    Console.WriteLine("=====================================");
                }
            }
            Console.WriteLine("Aperte enter para sair.");
            Console.ReadLine();
        }
        static void ConsultarRG()
        {
            int c = Clientes.Count;
            Console.WriteLine("Digite o RG do cliente");
            string rgCon = Console.ReadLine();
            string rgPes = FormatCnpjRg.FormatRG(rgCon);
            for (int i = 0; i < c;i++)
            {
                if (String.Compare(rgPes, Clientes[i].rg) == 0)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {Clientes[i].nome}");
                    Console.WriteLine($"CPF: {Clientes[i].cpf}");
                    Console.WriteLine($"RG: {Clientes[i].rg}");
                    Console.WriteLine($"Celular: {Clientes[i].cel}");
                    Console.WriteLine("=====================================");
                }
            }
            Console.WriteLine("Aperte enter para sair");
            Console.ReadLine();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, Clientes);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                Clientes = (List<Cliente>)encoder.Deserialize(stream);  

                if (Clientes == null)
                {
                    Clientes = new List<Cliente>();
                }
            }
            catch (Exception e) 
            {
                Clientes = new List<Cliente>();
            }

            stream.Close();
        }
    }
}

