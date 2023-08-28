/*
    Autor: Alexandre Dantas de Mendonça
    Data: 28/08/2023
    Objetivo: Montar o algoritmo Quicksort e testar o mesmo.
    Complexidade do algoritmo no pior caso: O(N^2).
*/

#include <iostream>

int partition(int *array, int low, int high) {
    int pivot = array[high];
    int i = low, j;
    for (j = low; j <= high - 1; j++) {
        if (pivot >= array[j]) {
            std::swap(array[j], array[i]);
            i++;
        }
    }
    std::swap(array[i], array[high]);
    return i;
}

void quicksort(int *array, int low, int high) {
    if (low < high) {
        int pi = partition(array, low, high);
        quicksort(array, low, pi - 1);
        quicksort(array, pi + 1, high);
    }
}

int main() {
    int vet[10];
    for (int i = 0; i < 10; i++) vet[i] = 10 - i;
    quicksort(vet, 0, 9);
    for (int i = 0; i < 10; i++) std::cout << " " << vet[i];
    return 0;
}