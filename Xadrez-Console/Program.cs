using EntidadesTabuleiro;
using Xadrez_Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Tabuleiro tabuleiro = new Tabuleiro(8, 8);

        Tela.ImprimirTela(tabuleiro);

        Console.ReadKey();
    }
}