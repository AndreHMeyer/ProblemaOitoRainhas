using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemaOitoRainhas.GeradorTabuleiro;

namespace ProblemaOitoRainhas
{
    public class TabuleiroGUI
    {
        public void IniciarTabuleiro()
        {
            Console.WriteLine("Insira o tamanho N do tabuleiro (N >= 4 para soluções válidas):");
            int tamanho;
            if (!int.TryParse(Console.ReadLine(), out tamanho) || (tamanho < 4 && tamanho != 1))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Tamanho inválido. Não existe solução para o problema das N rainhas em um tabuleiro menor que 4x4 (exceto 1x1).");
                Console.ResetColor();
                return;
            }

            Console.Clear();
            Tabuleiro tabuleiro = new Tabuleiro(tamanho, tamanho);
            PosicionarRainhasNoTabuleiro(tabuleiro);
        }

        private void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            var posicoesRainhas = new List<int[]>();
            int contador = 0;
            string rainha = "R";

            Console.WriteLine("            Tabuleiro");
            Console.WriteLine("    -------------------------\n");

            Console.Write("   ");
            for (int j = 0; j < tabuleiro.largura; j++)
            {
                Console.Write($"  {j + 1}");
            }
            Console.WriteLine();

            Console.Write("   ┌");
            Console.Write(new string('─', tabuleiro.largura * 3));
            Console.WriteLine("┐");

            for (int i = 0; i < tabuleiro.altura; i++)
            {
                Console.Write($" {i + 1} │");
                for (int j = 0; j < tabuleiro.largura; j++)
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

            Console.Write("   └");
            Console.Write(new string('─', tabuleiro.largura * 3));
            Console.WriteLine("┘");

            Console.WriteLine("\n\n");
            Console.WriteLine("        Posições das Rainhas");
            Console.WriteLine("    --------------------------");

            foreach (var posicaoRainha in posicoesRainhas)
            {
                contador++;
                Console.WriteLine($"     Posição Rainha {contador}: [{posicaoRainha[0] + 1}, {posicaoRainha[1] + 1}]");
            }
        }

        private void PosicionarRainhasNoTabuleiro(Tabuleiro tabuleiro)
        {
            GeradorTabuleiro gerador = new GeradorTabuleiro();
            gerador.GerarTabuleiro(tabuleiro);

            if (gerador.ResolverNRainhas(tabuleiro, 0))
            {
                ImprimirTabuleiro(tabuleiro);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Solução não encontrada!");
                Console.ResetColor();
            }
        }
    }
}
