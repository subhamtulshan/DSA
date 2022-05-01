
Solution:Here the idea is that we will keep three array prefix ,left,right
prefix(w) -- it store the sum of k size subarray at each index
left -- it store the start index from left of max subarray of size k
right-- it store the start index from right of max subarray of size k

class Solution {
    public int[] maxSumOfThreeSubarrays(int[] nums, int k) 
    {
        //W is an array of sums of windows
        int[] W = new int[nums.length - k + 1];
        int currSum = 0;
        for (int i = 0; i < nums.length; i++) 
        {
            //adding the numbers and then subtract the earlier numbers once we have reached >K
            currSum += nums[i];
            if (i >= k) {
                currSum -= nums[i - k];
            }
            //storing the first subarray sum to 0th index
            if (i >= k - 1) {
                W[i - k + 1] = currSum;
            }
        }

        int[] left = new int[W.length];
        int best = 0;
        for (int i = 0; i < W.length; i++) 
        {
            if (W[i] > W[best]) 
                best = i;
            left[i] = best;
        }

        int[] right = new int[W.length];
        best = W.length - 1;
        for (int i = W.length - 1; i >= 0; i--) 
        {
            if (W[i] >= W[best]) 
              best = i;
            right[i] = best;
        }
        
        int max= intmin;
        int[] ans = new int[]{-1, -1, -1};
        for (int j = k; j < W.length - k; j++) 
        {
            int leftIndex = left[j - k], rightIndex = right[j + k];
            if (ans[0] == -1 || W[leftIndex] + W[j] + W[rightIndex] > W[ans[0]] + W[ans[1]] + W[ans[2]]) 
            {
                max=W[leftIndex] + W[j] + W[rightIndex]; // if asked to return the max sum also
                ans[0] = leftIndex;
                ans[1] = j;
                ans[2] = rightIndex;
            }
        }
        return ans;
    }
}
