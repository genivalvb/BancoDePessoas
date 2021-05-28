using System;

namespace DIO.RegistroPessoas
{
    class Program
    {
        static PessoaRepositorio repositorio = new PessoaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoPessoa();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarPessoas();
                        break;
                    case "2":
                        InserirPessoa();
                        break;
                    case "3":
                        AtualizarPessoa();
                        break;
                    case "4":
                        ExcluirPessoa();
                        break;
                    case "5":
                        VisualizarPessoa();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoPessoa();
            }
            Console.WriteLine("Obrigado por utilizar nossos servições.");
            Console.ReadLine();
        }

        private static void VisualizarPessoa()
        {
            Console.Write("Digite o id da Pessoa: ");
            int indicePessoa = int.Parse(Console.ReadLine());

            var pessoa = repositorio.RetornaPorId(indicePessoa);

            Console.WriteLine(pessoa);
        }

        private static void ExcluirPessoa()
        {
            Console.Write("Digite o id da Pessoa: ");
            int indicePessoa = int.Parse(Console.ReadLine());

            repositorio.exclui(indicePessoa);
        }

        private static void AtualizarPessoa()
        {
            Console.Write("Digite o id da pessoa: ");
            int indicePessoa = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}={1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da pessoa: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite a Obra da pessoa: ");
            string entradaObra = Console.ReadLine();

            Console.Write("Digite data de nascimento da pessoa: ");
            string entradaDataNascimento = Console.ReadLine();

            Console.Write("Digite uma descrição da pessoa: ");
            string entradaDescricao = Console.ReadLine();

            Pessoa atualizaPessoa = new Pessoa(id: indicePessoa,
                                            genero: (Genero)entradaGenero,
                                            nome: entradaNome,
                                            obras: entradaObra,
                                            dataNascimento: entradaDataNascimento,
                                            descricao: entradaDescricao);
            
            repositorio.Atualiza(indicePessoa, atualizaPessoa);
        }

        private static void InserirPessoa()
        {
            Console.WriteLine("Inserir nova Pessoa");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome da Pessoa: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite as Obras da Pessoa: ");
            string entradaObras = Console.ReadLine();

            Console.Write("Digite a data de nascimento da Pessoa: ");
            string entradaDataNascimento = Console.ReadLine();

            Console.Write("Digite uma Descrição da Pessoa: ");
            string entradaDescricao = Console.ReadLine();

            Pessoa novaPessoa = new Pessoa(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                                        nome: entradaNome,
                                        obras: entradaObras,
                                        dataNascimento: entradaDataNascimento,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaPessoa);
        }

        private static void ListarPessoas()
        {
            Console.WriteLine("Listar Pessoas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada.");
                return;
            }

            foreach (var pessoa in lista)
            {
                var excluido = pessoa.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", pessoa.retornaId(),
                                     pessoa.retornaNome(),(excluido ? "Excluido" : ""));
            }
        }

        private static string ObterOpcaoPessoa()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Pessoas a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Pessoas");
            Console.WriteLine("2- Inserir nova Pessoa");
            Console.WriteLine("3- Atualizar Pessoa");
            Console.WriteLine("4- Excluir Pessoa");
            Console.WriteLine("5- Visualizar Pessoa");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoPessoa = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoPessoa;
        }
    }
}
