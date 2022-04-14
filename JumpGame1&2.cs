JUMP GAME 1
You are given an integer array nums. You are initially positioned at the array's first index, 
and each element in the array represents your maximum jump length at that position.
Return true if you can reach the last index, or false otherwise.

Solution is that we calculte the farthest we can reach at any current index and if we are able to cross the N then return true

public boolean canJump(int[] nums) {
    int dis = 0;
    for (int i = 0; i <= dis; i++) {
        dis = Math.max(dis, i + nums[i]);
        if (dis >= nums.length-1) {
            return true;
        }
    }
    return false;
}


Jump Game II

Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
Each element in the array represents your maximum jump length at that position.
Your goal is to reach the last index in the minimum number of jumps.
You can assume that you can always reach the last index.


Solution --The main idea is based on greedy. Let's say the range of the current jump is [curBegin, curEnd], 
curFarthest is the farthest point that all points in [curBegin, curEnd] can reach. 
Once the current point reaches curEnd, then trigger another jump, and set the new curEnd with curFarthest, then keep the above steps, as the following:

public class Solution {
	public int jump(int[] A) 
  {
		int jumps = 0, curEnd = 0, curFarthest = 0;
		for (int i = 0; i < A.length - 1; i++)
    {
			curFarthest = Math.max(curFarthest, i + A[i]); // calculating the farthest we can reach as of now
			if (i == curEnd) // if we have reach the end of current jump.
      {
				jumps++;
				curEnd = curFarthest;

				if (curEnd >= A.length - 1) 
        {
					break;
				}
			}
		}
		return jumps;
	}
}
