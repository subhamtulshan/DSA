/*
You likely know that different currencies have coins and bills of different denominations. In some currencies, it's actually impossible to receive change for a given amount of money. For example, Canada has given up the 1-cent penny. If you're owed 94 cents in Canada, a shopkeeper will graciously supply you with 95 cents instead since there exists a 5-cent coin.
Given a list of the available denominations, determine if it's possible to receive exact change for an amount of money targetMoney. Both the denominations and target amount will be given in generic units of that currency.

Signature
boolean canGetExactChange(int targetMoney, int[] denominations)

Input
1 ≤ |denominations| ≤ 100
1 ≤ denominations[i] ≤ 10,000
1 ≤ targetMoney ≤ 1,000,000

Output
Return true if it's possible to receive exactly targetMoney given the available denominations, and false if not.

Example 1
denominations = [5, 10, 25, 100, 200]
targetMoney = 94
output = false
Every denomination is a multiple of 5, so you can't receive exactly 94 units of money in this currency.

Example 2
denominations = [4, 17, 29]
targetMoney = 75
output = true
You can make 75 units with the denominations [17, 29, 29].

*/

Solution -- this is as same as coin change problem ie given all the currencies we want to find if we will be able to return the target value.

The idea is to use dp array that store the minimum coin need to make that target so we will start with 0 and go till the n to find the and.
for any index we will go through all the currencies and check if after adding this can we get the target with less coins.

-- the only difference in this and coin change is here we just want to know if its possible whereas in coin change we want the minimum coins.
so this can be done more easily using the same approach such that anytime we get some target no need to check again we can simply return.


Coin cahnge---
    class Solution {
    public int coinChange(int[] denominations, int targetMoney)
    {
        int[] dp = new int[targetMoney + 1];		
		Arrays.sort(denominations);
		Arrays.fill(dp,Integer.MAX_VALUE-1); // if no way to form then -1;
        dp[0]=0; // no coins needed for making 0;
		for (int amount =0;amount<=targetMoney;amount++)
		{
			for(int j=0;j<denominations.length;j++)
			{
				if(denominations[j]<=amount)
					dp[amount]=Math.min(dp[amount],1+dp[amount-denominations[j]]);
				else
					break; // to use this condition we need to sort
			}
		}
		return dp[targetMoney]==Integer.MAX_VALUE-1?-1:dp[targetMoney];
    }
}

This same can be modified to get this currency problem done


    class Solution {
    public int coinChange(int[] denominations, int targetMoney)
    {
        boolean[] dp = new boolean[targetMoney + 1];		
		Arrays.sort(denominations);
        dp[0]=true; // no coins needed for making 0;
		for (int amount =0;amount<=targetMoney;amount++)
		{
			if(dp[amount])
				continue;
			for(int j=0;j<denominations.length;j++)
			{
				if(denominations[j]<=amount)
					dp[amount]=dp[amount] || dp[amount-denominations[j]]);
				else
					break; // to use this condition we need to sort
			}
		}
		return dp[targetMoney];
    }
}