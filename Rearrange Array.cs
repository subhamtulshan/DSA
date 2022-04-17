/*
You're given an array ARR[] of size N, where every element belongs to the range 0 to N-1. 
Your task is to rearrange the given array so that ARR[i] becomes ARR[ARR[i]] and make sure that this task is done with O(1) extra space.
*/


As we are not allowed to use any extra space, we need to find an array element that can store two values at the same time. 
To do so, we increment every element at the ith index by (arr[arr[i]]%N)*N. Now after this increment every element is now holding two values,
the old value and the new value. The old value can be obtained by arr[i]%N and the new value can be obtained by arr[i]/N. Let us understand how this is achieved.

Suppose you have two elements X and Y that are present in the given array.
Since the array elements are less than N, both X and Y will also be less than N.
So now if we increment X by Y*N, the element then becomes X+Y*N. Now if we perform the operation (X+Y*N)%N, we get X and when we perform the operation (X+Y*N)/N, we get Y.
Example: X=4, Y=3, N=5
X+Y*N = 4 + 3*5 = 19
Now, 19%5 = 4(which is X) and 19/5 = 3(which is Y).
 

Now let’s see how to reach the solution to our problem.

We will start by traversing the array from start to end.
At every index i, we increment the current element by (arr[arr[i]]%N)*N.
Now traverse the array again from start to end.
Now since we need the new value for every index i, we divide the ith element by n i.e arr[i]/n and then print this element.

/*
    Time Complexity: O(N)
    Space Complexity: O(1),

    where N is the size of the array.
*/

public class Solution {

    public static void rearrangeArray(int arr[], int n) {
        // Increasing the elements by (arr[arr[i]]%n)*n
        for (int i = 0; i < n; i++) {
            arr[i] += (arr[arr[i]] % n) * n;
        }

        // Dividing the elements by n
        for (int i = 0; i < n; i++) {
            arr[i] /= n;
        }

    }

}
