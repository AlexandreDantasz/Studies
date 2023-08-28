/*
    Autor: Alexandre Dantas de Mendonça
    Data: 27/08/2023
    Objetivo: Esse código, que é um exercício do curso de C# fornecido pela Fundação Bradesco, tem
    a finalidade ler o nome e a idade do usuário, além disso, deve mostrar essas informações no terminal.
*/

using System;

namespace FundacaoBradescoEx01 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Qual o seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine("Quantos anos você tem?");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Seu nome é {0} e sua idade é {1} anos", nome, idade);
        }
    }
}