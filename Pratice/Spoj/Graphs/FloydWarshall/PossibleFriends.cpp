#include <iostream>
#define inf 9999

using namespace std;

int main() {
    int casos, i = 0, tam;
    string linha;
    cin >> casos;
    for (i = 0; i < casos; i++) {
        cin >> linha;
        tam = linha.size();
        int adj[tam][tam] = {inf};
        for (int j = 0; j < tam; j++) {
            if (linha[j] == 'Y') adj[0][j] = 1;
            else adj[0][j] = 0; 
            // precisa ser inf se linha e coluna forem diferentes
        }
        for (int j = 1; j < tam; j++) {
            cin >> linha;
            for (int k = 0; k < tam; k++) {
                if (linha[k] == 'Y') adj[j][k] = 1;
                else adj[j][k] = 0;
            }
        }
        // Algoritmo Floyd-Warshall
        for (int k = 0; k < tam; k++) {
            for (int j = 0; j < tam; j++) {
                for (int l = 0; l < tam; l++) {
                    adj[j][l] = min(adj[j][l], adj[j][k] + adj[k][l]);
                }
            }
        }
    }
    return 0;
}