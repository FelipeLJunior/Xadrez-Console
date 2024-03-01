using Xadrez_Console;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
        
        while(!partidaDeXadrez.Terminada)
        {
            try
            {
            Console.Clear();
            Tela.ImprimirPartida(partidaDeXadrez);

            Console.Write("\nSelecione uma peça: ");
            Posicao origem = Tela.LerPosicaoXadrez();

            partidaDeXadrez.ValidarPosicaoDeOrigem(origem);

            Console.Clear();
            bool[,] possiveisMovimentos = partidaDeXadrez.Tabuleiro.Peca(origem).PossiveisMovimentos();
                
            Tela.ImprimirTela(partidaDeXadrez.Tabuleiro, possiveisMovimentos);

            Console.Write("\nSelecione o destino dela: ");
            Posicao destino = Tela.LerPosicaoXadrez();

            partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);

            partidaDeXadrez.RealizarJogada(origem, destino);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        Console.ReadKey();
    }
}