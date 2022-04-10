import java.util.Arrays;

/**
 * Created on:  Sep 07, 2020
 * Questions: https://www.facebookrecruiting.com/portal/coding_practice_question/?problem_id=838749853303393
 
Given a sequence of n integers arr, determine the lexicographically smallest sequence which may be obtained from it after performing at most k element swaps, each involving a pair of consecutive elements in the sequence.
Note: A list x is lexicographically smaller than a different equal-length list y if and only if, for the earliest index at which the two lists differ, x's element at that index is smaller than y's element at that index.

Example 1
n = 3
k = 2
arr = [5, 3, 1]
output = [1, 5, 3]
We can swap the 2nd and 3rd elements, followed by the 1st and 2nd elements, to end up with the sequence [1, 5, 3]. This is the lexicographically smallest sequence achievable after at most 2 swaps.
Example 2
n = 5
k = 3
arr = [8, 9, 11, 2, 1]
output = [2, 8, 9, 11, 1]
We can swap [11, 2], followed by [9, 2], then [8, 2].
 
 */
 
 
 Solution -- This is very similar to bubble sort where we are allowed only k swaps. So what we do is like we start from 0 index(p1) and search for smallest number upto k
 if any number is found then we bring the number to current index by swapping . We continue this tilll k get to 0
 
 Time o(n2)
 
 
public class ElementSwapping {
    public static void main(String[] args) {
        System.out.println(Arrays.toString(findMinArray(new int[]{5, 3, 1}, 2)));
        System.out.println(Arrays.toString(findMinArray(new int[]{8, 9, 11, 2, 1}, 3)));
    }

    static void swap(int[] arr, int a, int b) {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    static int[] findMinArray(int[] arr, int k) {
        int p1 = 0, len = arr.length;
        while (k > 0) {
            // Find the smallest index from p1 to end.
            int val = arr[p1], idx = p1;
            for (int j = p1 + 1; j < len && j <= p1 + k; j++) {
                if (arr[j] < val) {
                    idx = j;
                    val = arr[j];
                }
            }
            if (idx != p1) {
                while (idx > p1) {
                    swap(arr, idx--, idx);
                    k--;
                }
            }
            p1++;
            if (p1 == len) break;
        }
        return arr;
    }
}
