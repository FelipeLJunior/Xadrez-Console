using System;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesXadrez;

namespace Xadrez_Console
{
    internal class Tela
    {

        public static void ImprimirTela(Tabuleiro tabuleiro)
        {
            for(int i = 0; i < tabuleiro.Linhas; i++)
            {

                Console.Write(tabuleiro.Linhas - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
        public static void ImprimirTela(Tabuleiro tabuleiro, bool[,] possiveisMovimentos)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for(int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(tabuleiro.Linhas - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (possiveisMovimentos[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }

        public static Posicao LerPosicaoXadrez()
        {
            string posicaoString = Console.ReadLine();

            char coluna = posicaoString[0];
            int linha = int.Parse(posicaoString[1] + "");

            return new PosicaoXadrez(coluna, linha).ToPosicao();
        }
    }
}
