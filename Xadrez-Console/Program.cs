using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using Xadrez_Console;
using EntidadesXadrez;
using EntidadesTabuleiro.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.AdicionarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 1));
            tabuleiro.AdicionarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.AdicionarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(3, 4));

            Tela.ImprimirTela(tabuleiro);

        }
        catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}