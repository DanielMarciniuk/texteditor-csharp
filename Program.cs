// ImplicitUsings enabled
namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("3 - Deletar arquivo");
            Console.WriteLine("0 - Sair");

            if (!short.TryParse(Console.ReadLine(), out short option))
            {
                Menu();
                return;
            }

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                case 3: Delete(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo que deseja abrir:");
            string path = Console.ReadLine();

            try
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            catch
            {
                Console.WriteLine("Não foi possível abrir o arquivo.");
            }

            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo da linha (Digite 'exit' para sair)");
            Console.WriteLine("--------------------------------");

            string text = "";
            string line;

            do
            {
                line = Console.ReadLine();

                if (line?.ToLower() != "exit")
                    text += line + Environment.NewLine;

            } while (line?.ToLower() != "exit");

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Em qual caminho deseja salvar o arquivo?");
            string path = Console.ReadLine();

            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.WriteLine($"O arquivo {path} foi salvo com sucesso!");
            }
            catch
            {
                Console.WriteLine("Não foi possível salvar o arquivo.");
            }

            Console.ReadLine();
            Menu();
        }

        static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo que deseja deletar:");
            string path = Console.ReadLine();

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Arquivo deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
            }
            catch
            {
                Console.WriteLine("Não foi possível deletar o arquivo.");
            }

            Console.ReadLine();
            Menu();
        }
    }
}