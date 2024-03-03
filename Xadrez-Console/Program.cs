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
            PartidaDeXadrez partida = new PartidaDeXadrez();
        
            while(!partida.Terminada)
            {
                try
                {
                Console.Clear();
                Tela.ImprimirPartida(partida);

                Console.Write("\nSelecione uma peça: ");
                Posicao origem = Tela.LerPosicaoXadrez();

                partida.ValidarPosicaoDeOrigem(origem);

                bool[,] possiveisMovimentos = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();
                
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tabuleiro, possiveisMovimentos);

                Console.Write("\nSelecione o destino dela: ");
                Posicao destino = Tela.LerPosicaoXadrez();

                partida.ValidarPosicaoDeDestino(origem, destino);

                partida.RealizarJogada(origem, destino);
                }
                catch(TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Valor inválido!");
                    Console.ReadKey();
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Valor inválido!");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Tela.ImprimirPartida(partida);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}