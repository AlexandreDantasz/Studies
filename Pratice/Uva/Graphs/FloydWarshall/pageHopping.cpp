    #include <iostream>
    #define inf 1000 // valor infinito
    #define v 100 // tamanho máximo da matriz
    using namespace std;

    void floydWarshall(int mat[v][v]) {
        int i, j, k;
        for (k = 0; k < v; k++) {
            for (i = 0; i < v; i++) {
                for (j = 0; j < v; j++) {
                    mat[i][j] = min(mat[i][j], mat[i][k] + mat[k][j]);
                }
            }
        }
    }

    int main() {
        int a, b, casos = 1;
        cin >> a >> b;
        while (a != 0 && b != 0) {
            int adj[v][v];
            // inicializando a matriz
            for (int i = 0; i < v; i++) {
                for (int j = 0; j < v; j++) adj[i][j] = inf;
            }
            for (int i = 0; i < v; i++) adj[i][i] = 0;
            // o peso para cada par de vértices deve ser 1
            // porque o exercício não fornece o peso das arestas
            adj[a-1][b-1] = 1; 
            cin >> a >> b;
            while (a != 0 && b != 0) {
                adj[a-1][b-1] = 1;
                cin >> a >> b;
            }
            int soma = 0;
            float resultado, contador = 0;
            floydWarshall(adj);
            for (int i = 0; i < v; i++) {
                for (int j = 0; j < v; j++) {
                    if (i != j && adj[i][j] != inf) { 
                        // somando o peso de todo menor caminho entre pares de vértices
                        // e contando a quantidade de caminhos possíveis
                        soma += adj[i][j];
                        contador++;
                    }
                }
            }
            resultado = soma/contador; // média dos menores caminhos entre os vértices
            printf("Case %i: average length between pages = %.3f clicks\n", casos, resultado);
            casos++;
            cin >> a >> b;
        }
    }