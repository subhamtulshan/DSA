/*

Best Time to Buy and Sell Stock III
	Find the maximum profit you can achieve. You may complete at most two transactions.
Best Time to Buy and Sell Stock IV
	Find the maximum profit you can achieve. You may complete at most K transactions.
	
*/


Thoughs1 --- Changing the state from/to buy sell nostate

ntuition behind the state diagram:
We begin at state 0, where we can either rest (i.e. do nothing) or buy stock at a given price.

If we choose to rest, we remain in state 0
If we buy, we spend some money (price of the stock on that day) and go to state 1
From state 1, we can once again choose to do nothing or we can sell our stock.

If we choose to rest, we remain in state 1
If we sell, we earn some money (price of the stock on that day) and go to state 2
This completes one transaction for us. Remember, we can only do atmost 2 transactions.

From state 2, we can choose to do nothing or buy more stock.

If we choose to rest, we remain in state 2
If we buy, we go to state 3
From state 3, we can once again choose to do nothing or we can sell our stock for the last time.

If we choose to rest, we remain in state 3
If we sell, we have utilized our allowed transactions and reach the final state 4


Thoughs2

First assume that we have no money, so buy1 means that we have to borrow money from others, we want to borrow less so that we have to make our balance as max as we can(because this is negative).

sell1 means we decide to sell the stock, after selling it we have price[i] money and we have to give back the money we owed, so we have price[i] - |buy1| = prices[i ] + buy1, we want to make this max.

buy2 means we want to buy another stock, we already have sell1 money, so after buying stock2 we have buy2 = sell1 - price[i] money left, we want more money left, so we make it max

sell2 means we want to sell stock2, we can have price[i] money after selling it, and we have buy2 money left before, so sell2 = buy2 + prices[i], we make this max.

So sell2 is the most money we can have.

Hope it is helpful and welcome quesions!

Thought3 --Here, the oneBuy keeps track of the lowest price, and oneBuyOneSell keeps track of the biggest profit we could get.
Then the tricky part comes, how to handle the twoBuy? Suppose in real life, you have bought and sold a stock and made $100 dollar profit. When you want to purchase a stock which costs you $300 dollars, how would you think this? You must think, um, I have made $100 profit, so I think this $300 dollar stock is worth $200 FOR ME since I have hold $100 for free.
There we go, you got the idea how we calculate twoBuy!! We just minimize the cost again!! The twoBuyTwoSell is just making as much profit as possible.
Hope this explanation helps other people to understand this!


Best Time to Buy and Sell Stock III

class Solution {
    public int maxProfit(int[] prices) {
		int buy1sell1 = 0, buy2sell2 = 0, buy1 = Integer.MIN_VALUE, buy2 = Integer.MIN_VALUE;
		for (int i = 0; i < prices.length; i++) {
			buy1 = Math.max(buy1, -prices[i]);
			buy1sell1 = Math.max(buy1sell1, buy1 + prices[i]);
			buy2 = Math.max(buy2, buy1sell1 - prices[i]);
			buy2sell2 = Math.max(buy2sell2, buy2 + prices[i]);
		}
		return buy2sell2;
	}
}


This is amazing! The same concept can be applied to the k transaction problem.

int maxProfit(int k, vector<int>& prices) {
        if (k == 0) return 0;
        vector<int> buy(k, INT_MAX);
        vector<int> profit(k, 0);
        for (int price: prices) {
            for (int i = 0; i < k; ++i) {
                buy[i] = min(buy[i], price - (i > 0 ? profit[i-1] : 0));
                profit[i] = max(profit[i], price - buy[i]);
            }
        }
        
        return profit.back();
    }