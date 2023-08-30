/*
    Autor: Alexandre Dantas de Mendonça
    Data: 29/08/2023
    Objetivo: Criar um jogo da forca, que utiliza palavras das frases (pérolas) do Kayne West, para rodar no Console.
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
                    string[] word = responseBody.Split(' ');
                    Console.WriteLine("A palavra contém {0} letras", word[0].Length);
                    Console.WriteLine(responseBody);
                }
            }
            httpClient.Dispose();
        }
    }
}