/*
    Autor: Alexandre Dantas de Mendonça
    Data: 27/08/2023
    Objetivo: Esse programa tem o objetivo de ler 3 notas de um aluno e informar pelo terminal se o aluno passou ou não.
*/

using System;

namespace fundacaoBradescoEx02 {
    class leituraDeNotas {
        static void Main(string [] args) {
            Console.WriteLine("ESSE PROGRAMA INFORMA SE UM ALUNO PASSOU OU NÃO");
            Console.Write("Primeira nota: ");
            float nota1 = float.Parse(Console.ReadLine());
            Console.Write("Segunda nota: ");
            float nota2 = float.Parse(Console.ReadLine());
            Console.Write("Terceira nota: ");
            float nota3 = float.Parse(Console.ReadLine());
            float media = (nota1 + nota2 + nota3) / 3;
            Console.Write("Média: {0:0.0}\nSituação: ", media);
            if (media >= 7.0) {
                Console.Write("Aprovado.");
            }
            else Console.Write("Reprovado.");
        }
    }
}