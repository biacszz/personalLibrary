using System;
using System.Collections.Generic;
using System.IO;
using personalLibrary;

class Program
{

    static Leitor leitor;

    static void Main(string[] args)
    {
        Console.WriteLine("bem vindo ao seu novo gerenciador de biblioteca pessoal!\n");
        
        Console.Write("Digite seu nome: ");
        string nomeLeitor = Console.ReadLine();
        leitor = new Leitor(nomeLeitor);
        
        Console.WriteLine($"\nOlá, {leitor.Nome}! Sua estante pessoal foi criada.");

        bool executando = true;
        while (executando)
        {
            MostrarMenu();
            int opcao = int.Parse(Console.ReadLine());
            
            switch (opcao)
            {
                case 1:
                    AdicionarLivro();
                    break;
                case 2:
                    AdicionarGibi();
                    break;
                case 3:
                    leitor.MinhaEstante.ListarItens();
                    break;
                case 4:
                    RemoverItem();
                    break;
                case 5:
                    RegistrarLeitura();
                    break;
                case 6:
                    AvaliarItem();
                    break;
                case 7:
                    BuscarItem();
                    break;
                case 8:
                    ListarStatus();
                    break;
                case 9:
                    Arquivos.salvar(leitor.MinhaEstante, "estante.txt");
                    break;
                case 10:
                    Arquivos.load(leitor.MinhaEstante, "estante.txt");
                    break;
                case 0:
                    executando = false;
                    Console.WriteLine("\nencerrando o programa. até logo!");
                    break;
                default:
                    Console.WriteLine("opção inválida! tente novamente.");
                    break;
            }
            
            if (executando)
            {
                Console.WriteLine("\npressione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENU PRINCIPAL ===");
        Console.WriteLine("1. Adicionar Livro");
        Console.WriteLine("2. Adicionar Gibi");
        Console.WriteLine("3. Listar Todos os Itens");
        Console.WriteLine("4. Remover um item da estante");
        Console.WriteLine("5. Registrar Progresso de Leitura");
        Console.WriteLine("6. Avaliar Item");
        Console.WriteLine("7. Buscar Item por Título");
        Console.WriteLine("8. Listar por Status de Leitura");
        Console.WriteLine("9. Salvar a estante atual");
        Console.WriteLine("10. Carregar a estante já existente");
        Console.WriteLine("0. Sair");
        Console.Write("\nEscolha uma opção: ");
    }

    static void AdicionarLivro()
    {
        Console.WriteLine("\n--- ADICIONAR LIVRO ---");
        
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        
        Console.Write("Ano de Publicação: ");
        int ano = int.Parse(Console.ReadLine());
        
        Console.Write("Número de Páginas: ");
        int paginas = int.Parse(Console.ReadLine());
        
        Livro novoLivro = new Livro(titulo, autor, ano, paginas);
        leitor.MinhaEstante.AddItem(novoLivro);
    }

    static void AdicionarGibi()
    {
        Console.WriteLine("\n--- ADICIONAR GIBI ---");
        
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        
        Console.Write("Ano de Publicação: ");
        int ano = int.Parse(Console.ReadLine());
        
        Console.Write("Número de Páginas: ");
        int paginas = int.Parse(Console.ReadLine());
        
        Console.Write("Editora: ");
        string editora = Console.ReadLine();
        
        Console.Write("Número da Edição: ");
        int numeroEdicao = int.Parse(Console.ReadLine());
        
        Gibi novoGibi = new Gibi(titulo, autor, ano, paginas, editora, numeroEdicao);
        leitor.MinhaEstante.AddItem(novoGibi);
    }

    static void RemoverItem()
    {
        if (leitor.MinhaEstante.qtdeItens() == 0)
        {
            Console.WriteLine("Sua estante está vazia! Adicione algum item primeiro.");
            return;
        }

        Console.WriteLine("\n--- REMOVER ITEM ---");
        
        Console.Write("Digite o título, ou parte dele, do item que deseja remover: ");
        string titulo = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(titulo))
        {
            leitor.MinhaEstante.RemoverItem(titulo);
            Console.WriteLine("item removido da estante");
        }
        else
        {
            Console.WriteLine("título inválido!");
        }
    }

    private static ItemEstante.StatusLeitura obterstts()
    {
            Console.WriteLine("\nOpções disponíveis:");
            Console.WriteLine("1. Quero Ler");
            Console.WriteLine("2. Lendo");
            Console.WriteLine("3. Lido");
            Console.WriteLine("4. Abandonado");
            Console.Write("Escolha o status (1-4): ");

            int codigo = int.Parse(Console.ReadLine());

            switch (codigo)
            {
                case 1: return ItemEstante.StatusLeitura.QueroLer; 
                case 2: return ItemEstante.StatusLeitura.Lendo; 
                case 3: return ItemEstante.StatusLeitura.Lido; 
                case 4: return ItemEstante.StatusLeitura.Abandonado; 
                default: return ItemEstante.StatusLeitura.NaoDefinido;
            }
    }

    static void RegistrarLeitura()
    {
        if (leitor.MinhaEstante.qtdeItens() == 0)
        {
            Console.WriteLine("Sua estante está vazia! Adicione algum livro primeiro.");
            return;
        }
        
        Console.WriteLine("\n--- REGISTRAR PROGRESSO DE LEITURA ---");
        leitor.MinhaEstante.ListarItens();
        
        Console.Write("Escolha o item que deseja atualizar: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        
        var item = leitor.MinhaEstante.BuscaIndice(indice);
        if (item != null)
        {
            ItemEstante.StatusLeitura novoStatus = obterstts();

            if(novoStatus == ItemEstante.StatusLeitura.NaoDefinido)
            {
                Console.WriteLine("status inválido!");
                return;
            }
            
            item.RegistrarLeitura(novoStatus);
        }
    }

    static void AvaliarItem()
    {
        if (leitor.MinhaEstante.qtdeItens() == 0)
        {
            Console.WriteLine("Sua estante está vazia! Adicione algum item primeiro.");
            return;
        }
        
        Console.WriteLine("\n--- AVALIAR ITEM ---");
        leitor.MinhaEstante.ListarItens();
        
        Console.Write("Digite o número do item que deseja avaliar: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        
        var item = leitor.MinhaEstante.BuscaIndice(indice);
        if (item != null)
        {
            Console.Write("Digite a avaliação (0-5 estrelas): ");
            int estrelas = int.Parse(Console.ReadLine());
            item.Avaliar(estrelas);
        }
        else
        {
            Console.WriteLine("Item não encontrado!");
        }
    }

    static void BuscarItem()
    {
        if (leitor.MinhaEstante.qtdeItens() == 0)
        {
            Console.WriteLine("Sua estante está vazia! Adicione algum item primeiro.");
            return;
        }
        
        Console.WriteLine("\n--- BUSCAR ITEM ---");
        Console.Write("Digite o título ou parte dele: ");
        string termo = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(termo))
        {
            leitor.MinhaEstante.BuscarTitulo(termo);
        }
        else
        {
            Console.WriteLine("Termo de busca inválido!");
        }
    }

    static void ListarStatus()
    {
        Console.WriteLine("\n--- LISTAR POR STATUS ---");
        ItemEstante.StatusLeitura status = obterstts();

        if(status == ItemEstante.StatusLeitura.NaoDefinido)
        {
            Console.WriteLine("status inválido!");
            return;
        }

        leitor.MinhaEstante.ListarStatus(status);
    }
}