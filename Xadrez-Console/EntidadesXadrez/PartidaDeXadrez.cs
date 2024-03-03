
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;

namespace EntidadesXadrez
{
    internal class PartidaDeXadrez
    {
        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;
        public Tabuleiro Tabuleiro { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public int Turno { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            Turno = 1;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca pecaSelecionada = Tabuleiro.RemoverPeca(origem);
            pecaSelecionada.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.AdicionarPeca(pecaSelecionada, destino);
            
            if(pecaCapturada != null) 
            { 
                _capturadas.Add(pecaCapturada);
            }

            // Jogada especial: roque pequeno
            if(pecaSelecionada is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao posicaoInicialDaTorreMaisProxima = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao posicaoDestinoDaTorreMaisProxima = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torreMaisProxima = Tabuleiro.RemoverPeca(posicaoInicialDaTorreMaisProxima);
                torreMaisProxima.IncrementarMovimento();
                Tabuleiro.AdicionarPeca(torreMaisProxima, posicaoDestinoDaTorreMaisProxima);
            }
            
            // Jogada especial: roque grande
            if(pecaSelecionada is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao posicaoInicialDaTorreMaisProxima = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao posicaoDestinoDaTorreMaisProxima = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torreMaisProxima = Tabuleiro.RemoverPeca(posicaoInicialDaTorreMaisProxima);
                torreMaisProxima.IncrementarMovimento();
                Tabuleiro.AdicionarPeca(torreMaisProxima, posicaoDestinoDaTorreMaisProxima);
            }

            // Jogada especial: en passant
            if(pecaSelecionada is Peao && destino.Coluna != origem.Coluna && pecaCapturada == null)
            {
                Posicao posicaoPeaoInimigo = new Posicao(origem.Linha, destino.Coluna);

                pecaCapturada = Tabuleiro.RemoverPeca(posicaoPeaoInimigo); ;
                _capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }
        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca pecaMovimentada = Tabuleiro.RemoverPeca(destino);
            pecaMovimentada.DecrementarMovimento();
            
            if (pecaCapturada != null)
            {
                Tabuleiro.AdicionarPeca(pecaCapturada, destino);
                _capturadas.Remove(pecaCapturada);
            }
            Tabuleiro.AdicionarPeca(pecaMovimentada, origem);

            // Jogada especial: roque pequeno
            if (pecaMovimentada is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao posicaoAtualDaTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Posicao posicaoInicialDaTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Peca torreMaisProxima = Tabuleiro.RemoverPeca(posicaoAtualDaTorre);
                torreMaisProxima.DecrementarMovimento();
                Tabuleiro.AdicionarPeca(torreMaisProxima, posicaoInicialDaTorre);
            }

            // Jogada especial: roque grande
            if (pecaMovimentada is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao posicaoAtualDaTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Posicao posicaoInicialDaTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Peca torreMaisProxima = Tabuleiro.RemoverPeca(posicaoAtualDaTorre);
                torreMaisProxima.DecrementarMovimento();
                Tabuleiro.AdicionarPeca(torreMaisProxima, posicaoInicialDaTorre);
            }

            // Jogada especial: en passant
            if (pecaMovimentada is Peao && destino.Coluna != origem.Coluna && pecaCapturada == VulneravelEnPassant)
            {
                Peca peaoCapturado = Tabuleiro.RemoverPeca(destino);

                Posicao posicaoPeaoInimigo = new Posicao(origem.Linha, destino.Coluna);

                Tabuleiro.AdicionarPeca(peaoCapturado, posicaoPeaoInimigo);
            }

        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = MovimentarPeca(origem, destino);

            if(VerificarXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (VerificarXeque(CorAdversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (VerificarXequemate(CorAdversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudarJogador();
            }

            Peca pecaMovimentada = Tabuleiro.Peca(destino);

            if(pecaMovimentada is Peao && (origem.Linha - 2 == destino.Linha || origem.Linha + 2 == destino.Linha))
            {
                VulneravelEnPassant = pecaMovimentada;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição!");
            }
            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("Essa peça pertence ao outro jogador!");
            }
            if (!Tabuleiro.Peca(posicao).ExisteMovimento(posicao))
            {
                throw new TabuleiroException("Essa peça não possui movimentos possíveis!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao posicaoDeOrigem, Posicao posicaoDeDestino)
        {
            if (!Tabuleiro.Peca(posicaoDeOrigem).PossibilidadeDeMovimento(posicaoDeDestino))
            {
                throw new TabuleiroException("Não pode mover para essa posição!");
            }
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasDeUmaCor = new HashSet<Peca>();
            foreach (Peca capturada in _capturadas)
            {
                if (capturada.Cor == cor)
                {
                    pecasDeUmaCor.Add(capturada);
                }
            }

            return pecasDeUmaCor;
        }
        
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecasDeUmaCor = new HashSet<Peca>();
            foreach (Peca peca in _pecas)
            {
                if (peca.Cor == cor)
                {
                    pecasDeUmaCor.Add(peca);
                }
            }

            pecasDeUmaCor.ExceptWith(PecasCapturadas(cor));
            return pecasDeUmaCor;
        }

        private Cor CorAdversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca PegarRei(Cor cor)
        {
            foreach (Peca pecaEmJogo in PecasEmJogo(cor))
            {
                if (pecaEmJogo is Rei)
                {
                    return pecaEmJogo;
                }
            }
            return null;
        }

        public bool VerificarXeque(Cor cor)
        {
            Peca rei = PegarRei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca pecaAdversariaEmJogo in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] movimentosPossiveis = pecaAdversariaEmJogo.MovimentosPossiveis();
                if (movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarXequemate(Cor cor)
        {
            if (!VerificarXeque(cor))
            {
                return false;
            }
            foreach (Peca pecaEmJogo in PecasEmJogo(cor))
            {
                bool[,] movimentosPossiveis = pecaEmJogo.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (movimentosPossiveis[i, j])
                        {
                            Posicao origem = pecaEmJogo.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = MovimentarPeca(origem, destino);
                            bool testeXeque = VerificarXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(Peca peca, char coluna, int linha)
        {
            Tabuleiro.AdicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        public void ColocarPecas()
        {
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'a', 1);
            ColocarNovaPeca(new Cavalo(Tabuleiro, Cor.Branca), 'b', 1);
            ColocarNovaPeca(new Bispo(Tabuleiro, Cor.Branca), 'c', 1);
            ColocarNovaPeca(new Dama(Tabuleiro, Cor.Branca), 'd', 1);
            ColocarNovaPeca(new Rei(Tabuleiro, Cor.Branca, this), 'e', 1);
            ColocarNovaPeca(new Bispo(Tabuleiro, Cor.Branca), 'f', 1);
            ColocarNovaPeca(new Cavalo(Tabuleiro, Cor.Branca), 'g', 1);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'h', 1);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'a', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'b', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'c', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'd', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'e', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'f', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'g', 2);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Branca, this), 'h', 2);

            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'a', 8);
            ColocarNovaPeca(new Cavalo(Tabuleiro, Cor.Preta), 'b', 8);
            ColocarNovaPeca(new Bispo(Tabuleiro, Cor.Preta), 'c', 8);
            ColocarNovaPeca(new Dama(Tabuleiro, Cor.Preta), 'd', 8);
            ColocarNovaPeca(new Rei(Tabuleiro, Cor.Preta, this), 'e', 8);
            ColocarNovaPeca(new Bispo(Tabuleiro, Cor.Preta), 'f', 8);
            ColocarNovaPeca(new Cavalo(Tabuleiro, Cor.Preta), 'g', 8);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'h', 8);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'a', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'b', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'c', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'd', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'e', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'f', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'g', 7);
            ColocarNovaPeca(new Peao(Tabuleiro, Cor.Preta, this), 'h', 7);
        }
    }
}
