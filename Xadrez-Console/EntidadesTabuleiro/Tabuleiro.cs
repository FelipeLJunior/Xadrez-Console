using EntidadesTabuleiro.Exceptions;

namespace EntidadesTabuleiro
{
    internal class Tabuleiro
    {
        private Peca[,] _pecas;
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return _pecas[linha, coluna];
        }

        public Peca Peca(Posicao posicao)
        {
            return _pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void AdicionarPeca(Peca peca, Posicao posicao)
        {
            if(ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RemoverPeca(Posicao posicao)
        {
            if(Peca(posicao) == null)
            {
                return null;
            }

            Peca pecaRemovida = Peca(posicao);
            pecaRemovida.Posicao = null;
            _pecas[posicao.Linha, posicao.Coluna] = null;
            return pecaRemovida;
        }

        public bool VerificarPosicao(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha >= Linhas || 
               posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }

            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if(!VerificarPosicao(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
