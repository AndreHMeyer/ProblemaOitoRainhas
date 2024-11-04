using System;
using System.Collections.Generic;

namespace ProblemaOitoRainhas
{
    public class GeradorTabuleiro
    {
        public class Tabuleiro
        {
            public int altura { get; }
            public int largura { get; }
            public int[,] matriz { get; }

            public Tabuleiro(int altura, int largura)
            {
                this.altura = altura;
                this.largura = largura;
                matriz = new int[altura, largura];
            }
        }

        public void GerarTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.altura; i++)
            {
                for (int j = 0; j < tabuleiro.largura; j++)
                {
                    tabuleiro.matriz[i, j] = 0;
                }
            }
        }

        private bool PosicaoValida(Tabuleiro tabuleiro, int linha, int coluna)
        {
            //Verifica a linha na esquerda
            for (int i = 0; i < coluna; i++)
            {
                if (tabuleiro.matriz[linha, i] == 1)
                    return false;
            }

            //Verifica a diagonal superior esquerda
            for (int i = linha, j = coluna; i >= 0 && j >= 0; i--, j--)
            {
                if (tabuleiro.matriz[i, j] == 1)
                    return false;
            }

            //Verifica a diagonal inferior esquerda
            for (int i = linha, j = coluna; i < tabuleiro.altura && j >= 0; i++, j--)
            {
                if (tabuleiro.matriz[i, j] == 1)
                    return false;
            }

            return true;
        }

        public bool ResolverNRainhas(Tabuleiro tabuleiro, int coluna)
        {
            if (coluna >= tabuleiro.largura)
                return true;

            for (int i = 0; i < tabuleiro.altura; i++)
            {
                if (PosicaoValida(tabuleiro, i, coluna))
                {
                    tabuleiro.matriz[i, coluna] = 1;

                    if (ResolverNRainhas(tabuleiro, coluna + 1))
                        return true;

                    tabuleiro.matriz[i, coluna] = 0;
                }
            }

            return false;
        }
    }
}
