/*
    Autor: Alexandre Dantas de Mendonça
    Data: 29/08/2023
    Objetivo: Criar um jogo da forca, que utiliza palavras das frases (pérolas) do Kayne West, para rodar no Console.
    Observações: Permitir letras maiúsculas e minúsculas, evitar letras repetidas, evitar pontuações.
*/

using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace ForcaDoKayneWest {
    class JogoDaForca {
        static bool Menu() {
            Console.Write("Digite:\n1 - Para Jogar\n2 - Para sair\nResposta: ");
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input)) { //verifica se o usuário digitou alguma coisa
                Console.Write("Digite novamente: ");
                input = Console.ReadLine();
            }
            int resposta = int.Parse(input);
            return resposta == 1;
        }

        static int TheBigOne(string[] search) {
            int index = 0, size = search.Length, best = search[0].Length;
            for (int i = 0; i < size; i++) {
                if (search[i].Length > best) {
                    index = i;
                    best = search[i].Length;
                } 
            }
            return index;
        }
        static string Change(string answer, string compare, char letter, ref int value) {
            string word = "";
            for (int i = 0; i < answer.Length; i++) {
                if (letter != answer[i]) {
                    if (compare[i] == '_') word += '_';
                    else word += compare[i];
                }
                else {
                    value = 1;
                    word += answer[i];
                }
            }
            return word;
        }

        static bool Status(string word) {
            int i;
            for (i = 0; i < word.Length && word[i] != '_'; i++);
            return i < word.Length; 
        }
        static async Task Main(string[] args) {
            Console.WriteLine("Esse Jogo da forca é feito com as frases do Kayne West!");
            Console.WriteLine("Vamos te dar a primeira palavra de uma frase\nSeu objetivo é acertar a palavra com até 10 tentativas!");
            Console.WriteLine("Observação: As frases ainda estão em inglês!");
            HttpClient httpClient = new HttpClient();
            string apiUrl = "https://api.kanye.rest/text";
            while (Menu()) {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode) {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    string [] dictionary = responseBody.Split(' ');
                    int wordIndex = TheBigOne(dictionary);
                    Console.WriteLine("A palavra contém {0} letras", dictionary[wordIndex].Length);
                    string answer = dictionary[wordIndex].ToUpper(); //A palavra será maiúscula para validações
                    string WordInterface = "";
                    for (int i = 0; i < dictionary[wordIndex].Length; i++) WordInterface += '_';
                    int tentativas = 0;
                    while (Status(WordInterface) && tentativas < 10) {
                        Console.WriteLine("Tentativas: {0}", tentativas);
                        Console.WriteLine("Palavra: {0}", WordInterface);
                        Console.Write("Digite a letra: ");
                        string input = Console.ReadLine();
                        while (String.IsNullOrEmpty(input)) { //verifica se o usuário digitou alguma coisa
                            Console.Write("Digite novamente: ");
                            input = Console.ReadLine();
                        }
                        int mudou = 0;
                        input = input.ToUpper(); //Transforma o input em maiúsculo para validações
                        if (input.Length == 1) WordInterface = Change(answer, WordInterface,  input[0], ref mudou);
                        else { //se não for uma letra, verifica se a palavra é a correta
                            if (input == dictionary[wordIndex]) {
                                mudou = 1;
                                WordInterface = dictionary[wordIndex];
                            }
                        }
                        if (mudou == 0) {
                            Console.WriteLine("\nErrou!\n");
                            tentativas++;
                        }
                        else Console.WriteLine("\nAcertou!\n");
                    }
                    Console.WriteLine("\nA Palavra era: {0}", dictionary[wordIndex]);
                    
                    Console.WriteLine(responseBody);
                }
            }
            httpClient.Dispose();
        }
    }
}