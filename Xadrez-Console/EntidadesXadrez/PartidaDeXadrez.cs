using System;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesXadrez;

namespace EntidadesXadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public Cor JogadorAtual { get; set; }
        public int Turno { get; set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            Turno = 1;
            Terminada = false;
            ColocarPecas();
        }

        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca pecaSelecionada = Tabuleiro.RemoverPeca(origem);
            pecaSelecionada.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.AdicionarPeca(pecaSelecionada, destino);
        }

        public void ColocarPecas()
        {
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.AdicionarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());

            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.AdicionarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
        }
    }
}
