/*
354. Russian Doll Envelopes

You are given a 2D array of integers envelopes where envelopes[i] = [wi, hi] represents the width and the height of an envelope.

One envelope can fit into another if and only if both the width and height of one envelope are greater than the other envelope's width and height.

Return the maximum number of envelopes you can Russian doll (i.e., put one inside the other).

Note: You cannot rotate an envelope.
*/


Solution ---
Sort the array. Ascend on width and descend on height if width are same.
Find the longest increasing subsequence based on height.
Since the width is increasing, we only need to consider height.
[3, 4] cannot contains [3, 3], so we need to put [3, 4] before [3, 3] when sorting otherwise it will be counted as an increasing number if the order is [3, 3], [3, 4]




class Solution {
    public int maxEnvelopes(int[][] envelopes) {
    if(envelopes == null || envelopes.length == 0 
       || envelopes[0] == null || envelopes[0].length != 2)
        return 0;
    Arrays.sort(envelopes, new Comparator<int[]>(){
        public int compare(int[] arr1, int[] arr2){
            if(arr1[0] == arr2[0])
                return arr2[1] - arr1[1];
            else
                return arr1[0] - arr2[0];
       } 
    });
    
        return LIS(envelopes);
    
}

// this is a binary seach way of finding the LIS --- > Here what we do is we find the index of 
point where it has to be put and then increase the lenght if we reach the max lenght . so whenever we get a element smaller we put it in its proper index 
and then try to find the next greater number. Here the cache is even if some number is smaller but dont form LIS still we have increase the len	
for the earlier smaller number which for the LIS so not a issue
    
    public static int LIS(int[][]envelopes)
    {
        int dp[] = new int[envelopes.length];
        int len = 0;
        for(int[] envelope : envelopes)
        {
                int index = Arrays.binarySearch(dp, 0, len, envelope[1]);
                if(index < 0)
                    index = -(index + 1);
                dp[index] = envelope[1];
                if(index == len)
                    len++;
        }
        return len;
    }
}


/// Binary seach logic take from here if interviewer asked to write it

 int maxEnvelopes(vector<pair<int, int>>& envelopes) {
        int N = envelopes.size();
        vector<int> candidates;
        sort(envelopes.begin(), envelopes.end(), cmp);
		
		
		//from here
        for (int i = 0; i < N; i++) {
            int lo = 0, hi = candidates.size() - 1;
            while (lo <= hi) {
                int mid = lo + (hi - lo)/2;
                if (envelopes[i].second > envelopes[candidates[mid]].second)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            if (lo == candidates.size())
                candidates.push_back(i);
            else
                candidates[lo] = i;
        }
        return candidates.size();
    }