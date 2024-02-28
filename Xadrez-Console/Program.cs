using Xadrez_Console;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;
using Xadrez_Console.EntidadesXadrez;

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

            tabuleiro.AdicionarPeca(new Rei(tabuleiro, Cor.Branca), new Posicao(7, 5));
            PosicaoXadrez posicaoXadrez = new PosicaoXadrez(8, 'a');

            Tela.ImprimirTela(tabuleiro);

            Console.WriteLine(posicaoXadrez);
            Console.WriteLine(posicaoXadrez.ToPosicao());

        }
        catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}