using System;
using System.Collections.Generic;

namespace ProblemaOitoRainhas
{
    public class GeradorTabuleiro
    {
        public class Tabuleiro
        {
            public const int altura = 8;
            public const int largura = 8;
            public int[,] matriz = new int[altura, largura];
        }

        private void GerarTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < Tabuleiro.altura; i++)
            {
                for (int j = 0; j < Tabuleiro.largura; j++)
                {
                    tabuleiro.matriz[i, j] = 0;
                }
            }
        }

        private void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            var posicoesRainhas = new List<int[]>();
            int contador = 0;
            string rainha = "R";

            Console.WriteLine("            Tabuleiro");
            Console.WriteLine("    -------------------------\n");

            Console.Write("   ");
            for (int j = 0; j < Tabuleiro.largura; j++)
            {
                Console.Write($"  {j + 1}");
            }
            Console.WriteLine("\n   ┌────────────────────────┐");

            for (int i = 0; i < Tabuleiro.altura; i++)
            {
                Console.Write($" {i + 1} │");
                for (int j = 0; j < Tabuleiro.largura; j++)
                {
                    if (tabuleiro.matriz[i, j] == 0)
                    {
                        Console.Write(" _ ");
                    }
                    else if (tabuleiro.matriz[i, j] == 1)
                    {
                        Console.Write($" {rainha} ");
                        posicoesRainhas.Add(new int[] { i, j });
                    }
                }
                Console.WriteLine("│");
            }
            Console.WriteLine("   └────────────────────────┘");

            Console.WriteLine("\n\n");
            Console.WriteLine("        Posições das Rainhas");
            Console.WriteLine("    --------------------------");

            foreach (var posicaoRainha in posicoesRainhas)
            {
                contador++;
                Console.WriteLine($"     Posição Rainha {contador}: [{posicaoRainha[0] + 1}, {posicaoRainha[1] + 1}]");
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
            for (int i = linha, j = coluna; i < Tabuleiro.altura && j >= 0; i++, j--)
            {
                if (tabuleiro.matriz[i, j] == 1)
                    return false;
            }

            return true;
        }

        private bool ResolverOitoRainhas(Tabuleiro tabuleiro, int coluna)
        {
            if (coluna >= Tabuleiro.largura)
                return true;

            for (int i = 0; i < Tabuleiro.altura; i++)
            {
                if (PosicaoValida(tabuleiro, i, coluna))
                {
                    tabuleiro.matriz[i, coluna] = 1;

                    if (ResolverOitoRainhas(tabuleiro, coluna + 1))
                        return true;

                    tabuleiro.matriz[i, coluna] = 0;
                }
            }

            return false;
        }

        public void PosicionarRainhasNoTabuleiro()
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            GerarTabuleiro(tabuleiro);

            if (ResolverOitoRainhas(tabuleiro, 0))
            {
                ImprimirTabuleiro(tabuleiro);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Solução não encontrada!");
            }   
        }
    }
}
