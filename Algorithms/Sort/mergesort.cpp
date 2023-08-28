/*
    Autor: Alexandre Dantas de Mendonça
    Data: 28/08/2023
    Objetivo: Montar o algoritmo Mergesort e testar o mesmo.
    Complexidade do Quicksort no pior caso: O(n log n). 
    Observações: Ruim em caso médio.
*/

#include <iostream>

using namespace std;

void Merge(int array[], int left, int mid, int right) {
    int n1 = mid - left + 1;  
    int n2 = right - mid;
    int l[n1], r[n2];
    int i, j;
    for (i = 0; i < n1; i++) l[i] = array[left + i];
    for (j = 0; j < n2; j++) r[j] = array[mid + j + 1];
    i = j = 0;
    int k;
    for (k = left; i < n1 && j < n2; k++) {
        if (l[i] <= r[j]) {
            array[k] = l[i];
            i++;
        }
        else {
            array[k] = r[j];
            j++;
        }
    }
    for (; i < n1; i++, k++) array[k] = l[i];
    for (; j < n2; j++, k++) array[k] = r[j];
}

void MergeSort(int array[], int begin, int end) {
    if (begin < end) {
        int mid = (begin + end)/2;
        MergeSort(array, begin, mid);
        MergeSort(array, mid + 1, end);
        Merge(array, begin, mid, end);
    }
}

int main() {
    int vet[10];
    for (int i = 0; i < 10; i++) vet[i] = 10 - i;
    MergeSort(vet, 0, 9);
    for (int i = 0; i < 10; i++) std::cout << " " << vet[i];
    return 0;
}