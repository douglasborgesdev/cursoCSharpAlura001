// Screen Sound
string mensagemDeBoasVindas = "Boas vindas aos exercicios dos cursos da carreira em Desenvolvimento Back-End .NET da Alura!";
// List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"};  
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> {10, 8, 6});
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.Clear();
    Console.WriteLine(mensagemDeBoasVindas);
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1: Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            ExibirOpcoesDoMenu();
            break;
    }

}

void ExibirTituloDaOpcao(string titulo)
{
    Console.Clear();
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void RegistrarBanda()
{
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}

void MostrarBandas()
{
    ExibirTituloDaOpcao("Lista de Bandas Registradas");
    Console.WriteLine("As bandas registradas são:");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
}

void AvaliarBanda()
{
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Digite a sua avaliação para a banda {nomeDaBanda} (0 a 10):");
        string avaliacaoString = Console.ReadLine()!;
        int avaliacao = int.Parse(avaliacaoString);
        bandasRegistradas[nomeDaBanda].Add(avaliacao);
        Console.WriteLine($"Você avaliou a banda {nomeDaBanda} com {avaliacao} pontos.");
        Thread.Sleep(2000);
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está registrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    ExibirOpcoesDoMenu();
}

void ExibirMediaBanda()
{
    ExibirTituloDaOpcao("Média de Avaliações da Banda");
    Console.Write("Digite o nome da banda que deseja ver a média de avaliações: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> avaliacoes = bandasRegistradas[nomeDaBanda];
        if (avaliacoes.Count > 0)
        {
            double media = avaliacoes.Average();
            Console.WriteLine($"A média de avaliações da banda {nomeDaBanda} é {media:F1} pontos.");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} ainda não possui avaliações.");
        }
        Thread.Sleep(4000);
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está registrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();