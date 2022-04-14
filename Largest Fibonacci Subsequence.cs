/*
Largest Fibonacci Subsequence
Given an array with positive integers,
the task is to find the largest subsequence from the array which contains only Fibonacci numbers.
Example 1:
Input : arr[] = {1, 4, 3, 9, 10, 13, 7}
Output : subset[] = {1, 3, 13}
The output three numbers are Fibonacci
numbers.

*/

Soltution
Find max in the array
Generate Fibonacci numbers till the max and store it in hash table.
Traverse array again if the number is present in hash table then add it to the result.


class Solution{

    List<int> findFibSubset(int arr[], int n) 
    {
      int max=arr[0];
      for(int i=1;i<n;i++)
        max=Math.max(max,arr[i]);
    
    
        int a = 0, b = 1;
        HashSet<int> hash;
        hash.insert(a);
        hash.insert(b);
        while (b < max) 
        {
            int c = a + b;
            a = b;
            b = c;
            hash.insert(b);
        }
    
        List<int> r;
        for (int i = 0; i < n; i++)
            if (hash.contains(arr[i])) 
              r.Add(arr[i]);
        return r;
    }
};
