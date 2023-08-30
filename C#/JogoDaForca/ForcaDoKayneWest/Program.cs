/*
    Autor: Alexandre Dantas de Mendonça
    Data: 29/08/2023
    Objetivo: Criar um jogo da forca, que utiliza palavras das frases (pérolas) do Kayne West, para rodar no Console.
    Observações: Fazer uma "interface gráfica" para as palavras e um contador de tentativas.
*/

using System;
using System.Net.Http;

namespace ForcaDoKayneWest {
    class JogoDaForca {
        static bool menu() {
            Console.Write("Digite:\n1 - Para Jogar\n2 - Para sair\nResposta: ");
            int resposta = int.Parse(Console.ReadLine());
            return resposta == 1;
        }

        static int theBigOne(string[] search) {
            int index = 0, size = search.Length, best = search[0].Length;
            for (int i = 0; i < size; i++) {
                if (search[i].Length > best) {
                    index = i;
                    best = search[i].Length;
                } 
            }
            return index;
        }

        static async Task Main(string[] args) {
            Console.WriteLine("Esse Jogo da forca é feito com as frases do Kayne West!");
            Console.WriteLine("Vamos te dar a primeira palavra de uma frase\nSeu objetivo é acertar a palavra com até 10 tentativas!");
            Console.WriteLine("Observação: As frases ainda estão em inglês!");
            HttpClient httpClient = new HttpClient();
            string apiUrl = "https://api.kanye.rest/text";
            while (menu()) {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode) {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    string [] dictionary = responseBody.Split(' ');
                    int wordIndex = theBigOne(dictionary);
                    Console.WriteLine("A palavra contém {0} letras", dictionary[wordIndex].Length);
                    string WordInterface = "";
                    for (int i = 0; i < dictionary[wordIndex].Length; i++) WordInterface += '_';
                    int tentativas = 0;
                    while (tentativas != -1 && tentativas < 10) {
                        Console.WriteLine("Tentativas: {0}", tentativas);
                        Console.WriteLine("Palavra: {0}", WordInterface);
                        Console.Write("Digite a letra: ");
                    }
                    Console.WriteLine(responseBody);
                }
            }
            httpClient.Dispose();
        }
    }
}