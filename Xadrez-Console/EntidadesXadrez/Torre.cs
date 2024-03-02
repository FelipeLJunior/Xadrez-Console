﻿using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using System.Runtime.ConstrainedExecution;

namespace EntidadesXadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao provavelPosicao = new Posicao(0, 0);

            // acima
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))

            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                if (Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }
                provavelPosicao.Linha = provavelPosicao.Linha - 1;
            }

            // abaixo
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                if (Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }
                provavelPosicao.Linha = provavelPosicao.Linha + 1;
            }

            // direita
            provavelPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                if (Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }
                provavelPosicao.Coluna = provavelPosicao.Coluna + 1;
            }

            // esquerda
            provavelPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                if (Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }
                provavelPosicao.Coluna = provavelPosicao.Coluna - 1;
            }

            return movimentosPossiveis;
        }
    }
}