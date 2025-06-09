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

        struct Paciente
        {
            public string nome;
            public string cpf;
            public string rg;
            public string cel;
        }

        static List<Paciente> Pacientes = new List<Paciente>();

        enum Menu { cadastrar = 1, remover = 2, listar = 3, consultar = 4, sair = 5 };

        static void Main(string[] args)
        {
            Carregar();

            bool EscolhaSair = false;
            while (!EscolhaSair) 
            {
                Console.Write("Sistema de Vacinação\n");
                Console.WriteLine("1 - Cadastrar Paciente\n2 - Remover\n3 - Listar Pacientes\n4 - Consultar por CPF\n5 - Sair");
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
            if (Pacientes.Count > 0)
            {
                Console.WriteLine("Lista de Pacientes:");
                int i = 0;
                foreach (Paciente paciente in Pacientes)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {paciente.nome}");
                    Console.WriteLine($"CPF: {paciente.cpf}");
                    Console.WriteLine($"RG: {paciente.rg}");
                    Console.WriteLine($"Celular: {paciente.cel}");
                    Console.WriteLine("=====================================");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nenhum paciente encontrado");
            }
        }
        static void Cadastrar()
        {
            string Cpf;
            string Rg;
            Paciente paciente = new Paciente();
            Console.WriteLine("Cadastro de Pacientes");
            Console.WriteLine("Nome do paciente");
            paciente.nome = Console.ReadLine();
            Console.WriteLine("CPF do paciente");
            Cpf = Console.ReadLine();
            paciente.cpf = FormatCnpjCpf.FormatCPF(Cpf);
            Console.WriteLine("RG do paciente");
            Rg = Console.ReadLine();
            paciente.rg = FormatCnpjRg.FormatRG(Rg);
            Console.WriteLine("Número de celular do paciente");
            paciente.cel = Console.ReadLine();

            Pacientes.Add(paciente);
            Salvar();

            Console.WriteLine("Cadastro concluído, aperte enter para sair.");
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o id do Paciente que deseja remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < Pacientes.Count)
            {
                Pacientes.RemoveAt(id);
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
            int c = Pacientes.Count;
            Console.WriteLine("Digite o CPF do paciente:");
            string cpfCon = Console.ReadLine();
            string cpfPes = FormatCnpjCpf.FormatCPF(cpfCon);
            for (int i = 0; i < c; i++)
            {
                if (String.Compare(cpfPes, Pacientes[i].cpf) == 0)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {Pacientes[i].nome}");
                    Console.WriteLine($"CPF: {Pacientes[i].cpf}");
                    Console.WriteLine($"RG: {Pacientes[i].rg}");
                    Console.WriteLine($"Celular: {Pacientes[i].cel}");
                    Console.WriteLine("=====================================");
                }
            }
            Console.WriteLine("Aperte enter para sair.");
            Console.ReadLine();
        }
        static void ConsultarRG()
        {
            int c = Pacientes.Count;
            Console.WriteLine("Digite o RG do paciente");
            string rgCon = Console.ReadLine();
            string rgPes = FormatCnpjRg.FormatRG(rgCon);
            for (int i = 0; i < c;i++)
            {
                if (String.Compare(rgPes, Pacientes[i].rg) == 0)
                {
                    Console.WriteLine($"Código: {i}");
                    Console.WriteLine($"Nome: {Pacientes[i].nome}");
                    Console.WriteLine($"CPF: {Pacientes[i].cpf}");
                    Console.WriteLine($"RG: {Pacientes[i].rg}");
                    Console.WriteLine($"Celular: {Pacientes[i].cel}");
                    Console.WriteLine("=====================================");
                }
            }
            Console.WriteLine("Aperte enter para sair");
            Console.ReadLine();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("Pacientes.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, Pacientes);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("Pacientes.txt", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                Pacientes = (List<Paciente>)encoder.Deserialize(stream);  

                if (Pacientes == null)
                {
                    Pacientes = new List<Paciente>();
                }
            }
            catch (Exception e) 
            {
                Pacientes = new List<Paciente>();
            }

            stream.Close();
        }
    }
}

