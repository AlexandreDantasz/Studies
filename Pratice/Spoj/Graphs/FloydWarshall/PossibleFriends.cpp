#include <iostream>
#define inf 9999 // valor infinito
#define f first 
#define s second

using namespace std;

int main() {
    int casos, i = 0, tam;
    pair <int, int> resposta; // first: id,  second: quantidade de possíveis amigos
    string linha;
    cin >> casos;
    for (i = 0; i < casos; i++) {
        // inicializando a resposta para fazer a busca da
        // maior quantidade de possíveis amigos
        resposta.f = -1;
        resposta.s = -1;
        cin >> linha;
        tam = linha.size(); // descobrindo o M da matriz quadrada (MxM)
        int adj[tam][tam]; // matriz de adjacência
        int amigos[tam] = {0}; // vetor da quantidade de possíveis amigos
        // inserindo a primeira linha na matriz de adjacência
        adj[0][0] = 0;
        for (int j = 1; j < tam; j++) {
            if (linha[j] == 'Y') adj[0][j] = 1;
            else adj[0][j] = inf;
        }
        // inserindo as próximas linhas na matriz de adjacência
        for (int j = 1; j < tam; j++) {
            cin >> linha;
            for (int k = 0; k < tam; k++) {
                if (linha[k] == 'Y') adj[j][k] = 1;
                else if (j == k) adj[j][k] = 0;
                else adj[j][k] = inf;
            }
        }
        // Algoritmo Floyd-Warshall modificado
        for (int k = 0; k < tam; k++) { // k é o vértice intermediário
            for (int j = 0; j < tam; j++) {
                for (int l = 0; l < tam; l++) {
                    if (adj[j][l] == inf && adj[j][k] == 1 && adj[k][l] == 1) {
                        // j e l podem ser amigos através de k
                        amigos[j] += 1;
                        amigos[l] += 1;
                        // evitando que a comparação seja feita novamente
                        adj[j][l] = -1; 
                        adj[l][j] = -1; 
                    }
                }
            }
        }
        // verificação do vetor da quantidade de possíveis amigos
        for (int k = 0; k < tam; k++) {
            if (amigos[k] > resposta.s) {
                resposta.f = k;
                resposta.s = amigos[k];
            }
        }
        cout << resposta.f << ' ' << resposta.s << endl;
    }
    return 0;
}