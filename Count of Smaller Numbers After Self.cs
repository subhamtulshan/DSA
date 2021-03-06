/*
You are given an integer array nums and you have to return a new counts array. 
The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].
Example 1:

Input: nums = [5,2,6,1]
Output: [2,1,1,0]
Explanation:
To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
*/

Solution -- Here the idea is to do merge sort but not the numbers direct but on the index. we will do regular merge sort and while merging
we will see how many elements we have taken from the right and that are the jumps we have made for the left element and we will store it

Use the idea of merge sort. Key algorithm:
ex:
index: 0, 1
left: 2, 5
right: 1, 6
Each time we choose a left to the merged array. We want to know how many numbers from array right are moved before this number.
For example we take 1 from right array and merge sort it first. Then it’s 2 from left array. 
We find that there are j numbers moved before this left[i], in this case j == 1.
So the array smaller[original index of 2] += j.
Then we take 5 from array left. We also know that j numbers moved before this 5.
smaller[original index of 6] += j.

Solution :

public class Solution {
    class Pair {
        int index;
        int val;
        public Pair(int index, int val) {
            this.index = index;
            this.val = val;
        }
    }
    public List<Integer> countSmaller(int[] nums) 
    {
        List<Integer> res = new ArrayList<>();
        if (nums == null || nums.length == 0) 
        {
            return res;
        }
        Pair[] arr = new Pair[nums.length];
        Integer[] smaller = new Integer[nums.length];
        Arrays.fill(smaller, 0);
        for (int i = 0; i < nums.length; i++)
        {
            arr[i] = new Pair(i, nums[i]);
        }
        mergeSort(arr, smaller);
        res.addAll(Arrays.asList(smaller));
        return res;
    }
    private Pair[] mergeSort(Pair[] arr, Integer[] smaller) {
        if (arr.length <= 1) {
            return arr;
        }
        int mid = arr.length / 2;
        Pair[] left = mergeSort(Arrays.copyOfRange(arr, 0, mid), smaller);
        Pair[] right = mergeSort(Arrays.copyOfRange(arr, mid, arr.length), smaller);
        for (int i = 0, j = 0; i < left.length || j < right.length;) 
        {
            if (j == right.length || i < left.length && left[i].val <= right[j].val) 
            {
                arr[i + j] = left[i];
                smaller[left[i].index] += j;
                i++;
            } else
            {
                arr[i + j] = right[j];
                j++;
            }
        }
        return arr;
    }
}
