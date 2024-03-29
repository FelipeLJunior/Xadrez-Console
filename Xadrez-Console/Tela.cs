﻿using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesXadrez;

namespace Xadrez_Console
{
    internal class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine($"\nTurno: {partida.Turno}");

            if(partida.Terminada)
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"O vencedor: {partida.JogadorAtual}");
                return;
            }

            Console.WriteLine($"Aguardando Jogada das: {partida.JogadorAtual}s");
            if(partida.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
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
            Console.WriteLine("  a b c d e f g h\n");
        }
        
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] possiveisMovimentos)
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

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("\nPretas: ");
            ConsoleColor corConsole = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corConsole;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach(Peca elemento in conjunto)
            {
                Console.Write(elemento + " ");
            }
            Console.Write("]");
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
