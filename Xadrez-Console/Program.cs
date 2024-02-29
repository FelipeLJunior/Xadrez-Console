using Xadrez_Console;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
            
            while(!partidaDeXadrez.Terminada)
            {
                Console.Clear();
                Tela.ImprimirTela(partidaDeXadrez.Tabuleiro);

                Console.Write("Selecione uma peça: ");
                Posicao origem = Tela.LerPosicaoXadrez();

                Console.Clear();
                bool[,] possiveisMovimentos = partidaDeXadrez.Tabuleiro.Peca(origem).PossiveisMovimentos();
                
                Tela.ImprimirTela(partidaDeXadrez.Tabuleiro, possiveisMovimentos);

                Console.Write("Selecione o destino dela: ");
                Posicao destino = Tela.LerPosicaoXadrez();

                partidaDeXadrez.MovimentarPeca(origem, destino);
            }


        }
        catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}