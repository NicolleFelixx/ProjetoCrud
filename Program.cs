using System;

namespace ProjetoCrud
{
    class Program
    {
        // Arrays para armazenar os dados dos usuários
        static int[] ids = new int[100];
        static string[] names = new string[100];
        static string[] emails = new string[100];
        static int[] ages = new int[100];
        static int currentIndex = 0;
        static int nextID = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gerenciamento de Usuários");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Atualizar Usuário");
                Console.WriteLine("4. Deletar Usuário");
                Console.WriteLine("5. Pesquisar Usuário por ID");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ListUsers();
                        break;
                    case "3":
                        UpdateUser();
                        break;
                    case "4":
                        DeleteUser();
                        break;
                    case "5":
                        SearchUserByID();
                        break;
                    case "6":
                        Console.WriteLine("Encerrando o sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar Usuário");

            // Armazena os dados do usuário
            ids[currentIndex] = nextID++;
            Console.Write("Nome: ");
            names[currentIndex] = Console.ReadLine();
            Console.Write("E-mail: ");
            emails[currentIndex] = Console.ReadLine();
            Console.Write("Idade: ");
            while (!int.TryParse(Console.ReadLine(), out ages[currentIndex]) || ages[currentIndex] <= 0)
            {
                Console.WriteLine("Idade inválida. Digite um número válido.");
            }

            currentIndex++;
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");

            if (currentIndex == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            for (int i = 0; i < currentIndex; i++)
            {
                if (ids[i] != 0) // Verifica se o usuário não foi excluído
                {
                    Console.WriteLine($"ID: {ids[i]}, Nome: {names[i]}, E-mail: {emails[i]}, Idade: {ages[i]}");
                }
            }
        }

        static void UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Usuário");
            Console.Write("Digite o ID do usuário: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    if (ids[i] == id)
                    {
                        Console.Write("Novo Nome (pressione Enter para manter o atual): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName))
                        {
                            names[i] = newName;
                        }

                        Console.Write("Novo E-mail (pressione Enter para manter o atual): ");
                        string newEmail = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newEmail))
                        {
                            emails[i] = newEmail;
                        }

                        Console.Write("Nova Idade (pressione Enter para manter o atual): ");
                        string ageInput = Console.ReadLine();
                        if (int.TryParse(ageInput, out int newAge) && newAge > 0)
                        {
                            ages[i] = newAge;
                        }

                        Console.WriteLine("Usuário atualizado com sucesso!");
                        return;
                    }
                }

                Console.WriteLine("Usuário não encontrado.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Deletar Usuário");
            Console.Write("Digite o ID do usuário: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    if (ids[i] == id)
                    {
                        ids[i] = 0; // Marca o usuário como excluído
                        Console.WriteLine("Usuário excluído com sucesso!");
                        return;
                    }
                }

                Console.WriteLine("Usuário não encontrado.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        static void SearchUserByID()
        {
            Console.Clear();
            Console.WriteLine("Pesquisar Usuário por ID");
            Console.Write("Digite o ID do usuário: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    if (ids[i] == id)
                    {
                        Console.WriteLine($"ID: {ids[i]}, Nome: {names[i]}, E-mail: {emails[i]}, Idade: {ages[i]}");
                        return;
                    }
                }

                Console.WriteLine("Usuário não encontrado.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}