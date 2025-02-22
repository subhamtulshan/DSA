Given two strings s and t, return the number of distinct subsequences of s which equals t.

The test cases are generated so that the answer fits on a 32-bit signed integer.

Example 1:

Input: s = "rabbbit", t = "rabbit"
Output: 3
Explanation:
As shown below, there are 3 ways you can generate "rabbit" from s.
rabbbit
rabbbit
rabbbit



Solution
This is one of the best problems for illustrating the transition from a recursive solution to an iterative one and finally, to a space optimized iterative solution. Trust me, you're going to have a lot of fun solving this problem and this is the kind of problem that an interviewer may ask in an interview to grill the candidate on the various aspects of optimization. Start with the recursive solution and then drill your way through to an iterative solution with a highly reduced space complexity. Without further ado, let's look at the solutions.

Approach 1: Recursion + Memoization
Intuition
This problem is all about the "choice" you make in picking out the subsequences. Before we solve this problem, let's think about a much simpler version first. Say the problem statement simply asked us to find if there's a subsequence in S that equals T. This is a way easier problem to solve than the one at hand. However, the thought process for this version is what will lead us to solve the real problem as well. So, let's think a bit about how, in the simplest manner will we solve this version of the problem?


Well the simplest way to solve this would be to match one character at a time, right? We will maintain two indices one each for iterating the characters in the two strings. At every step, we will check if the current character in the string S equals the current character in the string T. If it does, then we will progress both the indices.


However, if it does not, then we need to explore more characters to find the match in the string S. Thus, we will only progress the index iterating over the string S with the intention that maybe the next character will lead us to a match and so on.


Once the last character in the string T gets a match in the string S, we will return true representing that we have found a subsequence in S that equals T. What we're gonna look at in our solution here is just an extension of this simple algorithm. The original problem asks us the number of matched subsequences. That basically means that our algorithm will have to explore all possible subsequences and count the ones that match the string T. That's a brute force way of solving this and one that won't pass the time limits since there are 2 
N
  subsequences in a string of length N.

As mentioned before, the algorithm will be following the same ideology as before. We will be using a couple of indices to match one character at a time. Let's look at the two different scenarios again that we could possibly encounter and also look at what we have to do differently this time around.

The first scenario is where the current characters do not match. In this case, we don't have any choice but to move on one step further in the string S in the hopes of a potential match. If we talk in terms of indices i and j where i represents the current character in string S while j is for the current character in string T, then it would mean that we have to move from (i, j) to (i + 1, j).


The second scenario is a bit more interesting. Suppose the two characters match up. Now, in this case we can simply move one character each in both the strings i.e. (i + 1, j + 1) which is what we did for our simpler version of this problem. However, we need to find all possible subsequence matches, right? So, it's possible that we find the same character as i, at another index down the line, and from that point on we are able to find the remainder of the string T as well? Let's look at s = rabbbit and t = rabit.

Here, when we match the character b at indices i = 2 and j = 2, we can clearly see that the rest of string T i.e. it is present at the end of string S. This is one subsequence. However, if we reject the b at i = 2 and instead move one step forward, we see another b at i = 3 (and at i = 4) which we can use as the match for the corresponding b in string T. For our problem, we need to consider all three of them to get the answer.

So, as mentioned before, one choice in this scenario, when we have a character match is to move one step forward in both the strings i.e. (i + 1, j + 1). The other choice is to reject the character in S as if a mismatch and move one step forward i.e. (i + 1, j). Both options can lead to matching subsequences and we need to take note of both of them.


Whenever we have choices in a problem, it could be a good idea to fall back on a recursive approach for the solution. A recursive solution makes the most sense when a problem can be broken down into subproblems and solutions to subproblems can be used to solve the top level problem. Well, for our problem, a substring is our subproblem because i represents that we have already processed 0⋯i−1 characters in string S. Similarly, j represents that we have processed 0⋯j−1 characters in string T.

Every recursive approach needs some variables that help define the state of the recursion. In our case, we have been talking about these two indices that will help us iterate over our strings one character at a time. Hence, i and j together will define the state of our recursion.

Since we've defined the state of our recursion function, we know what the inputs would be. Now, we need to think about what this function would return and how that would tie up with the input we are providing. The return value is not that hard to figure out really. Given two indices i and j, our function would return the number of distinct subsequences in the substring s[i⋯M] that equal the substring t[j⋯N] where M and N represent the lengths of the two string respectively.

It's time to bring some concreteness to the choices that we have been talking about in the previous few paragraphs. So, given the two indices i and j, we need to compare the characters in the corresponding strings and see if they match or not.

If the characters match, then we have two possible branches where the recursion can go. func(i + 1, j) is where we ignore the current match in string S and move forward. func(i + 1, j + 1) is where we move forward in both the strings. Both of these contribute to the overall answer for this scenario as explained before. Thus, we have the following recursive relation:

func(i, j) = func(i + 1, j) + func(i + 1, j + 1)
The second scenario is where the characters don't match. We don't really have any choice here but to move forward in the string S and hope to find the match somewhere later in the string. Hence:

func(i, j) = func(i + 1, j)
The final thing to discuss in our recursion based solution is the base case. There are two scenarios where we would break from our recursion and start to backtrack. We have two different strings of potentially different lengths. When one of them finishes, there's no point in going any further. So, i == M or j == N will form our base case. However, what we return in our base case is what will tie this whole thing together.

If we exhausted the string S, but there are still characters to be considered in string T, that means we ended up rejecting far too many characters and eventually ran out! Here, we return a 0 because now, there's no possibility of a match. However, if we exhausted the string T, then it means we found a subsequence in S that matches T and hence, we return a 1.

Another way of thinking about this scenario is that func(i, N) = 1 because t[N⋯N] is an empty string and s[i⋯M] is non-empty. Every string has a subsequence which equals an empty string. Hence, we return a 1 in this base case.

func recurse(i, j)
{
    if (i == M or j == N)
    {
        return j == N ? 1 : 0
    }
    
    if (s[i] == t[j])
    {
        return recurse(i + 1, j) + recurse(i + 1, j + 1)
    }
    else
    {
        return recurse(i + 1, j)
    }
}

Well that's how our recursion tree looks like based on what we've discussed so far. However, there is a missing part to solution still that is absolutely necessary. If you notice in the image above, we have the nodes (2, 1) repeated! A node repetition in the recursion tree means we are making the same recursive call twice (or N number of times depending on the repetitions). We wouldn't want to do that now, would we? Instead of making these repetitive calls, why not cache the results somewhere and re-use them? That would prune our recursion tree's size so much! This is what we call memoization or simply, caching.

So, we use a dictionary with (i, j) as the key and the result of the function call recurse(i, j) as the value. Whenever we enter a recursive call, we first check for the base cases. If none of the base cases is hit yet, we check if the tuple (i, j) is present in the dictionary or not. If it is, we simply return the value. No need to repeat the calculations that we have already done before.


class Solution {
    // Dictionary that we will use for memoization
    private HashMap<Pair<Integer, Integer>, Integer> memo;

    private int recurse(String s, String t, int i, int j) {
        int M = s.length();
        int N = t.length();

        // Base case
        if (i == M || j == N || M - i < N - j) {
            return j == t.length() ? 1 : 0;
        }

        Pair<Integer, Integer> key = new Pair<Integer, Integer>(i, j);

        // Check to see if the result for this recursive
        // call is already cached
        if (this.memo.containsKey(key)) {
            return this.memo.get(key);
        }

        // Always calculate this result since it's
        // required for both the cases
        int ans = this.recurse(s, t, i + 1, j);

        // If the characters match, then we make another
        // recursion call and add the result to "ans"
        if (s.charAt(i) == t.charAt(j)) {
            ans += this.recurse(s, t, i + 1, j + 1);
        }

        // Cache the result
        this.memo.put(key, ans);
        return ans;
    }

    public int numDistinct(String s, String t) {
        this.memo = new HashMap<Pair<Integer, Integer>, Integer>();
        return this.recurse(s, t, 0, 0);
    }
}




DynamicProgramming

Algorithm
Initialize a 2D array dp of size M×N where M represents the length of string S while N represents the length of string T.

An important thing to remember here is what recurse(i, j) actually represents. It basically represents the number of distinct subsequences in string s[i⋯M] that equals the string t[j⋯N]. This is important because we will have our iterative loops based on this idea itself. This implies that we will first calculate the value of recurse(i, j) before we can find answers for recurse(i - 1, j) or recurse(i, j - 1) or recurse(i - 1, j - 1).

Based on this idea, we will have an outer loop for the index i which will go from M - 1 to 0 and an inner loop for j from N - 1 to 0.

We first handle our recursion's base case in outside of our nested loop and here we initialize the last column and the last row of our dp table.


class Solution {
    public int numDistinct(String s, String t) {
        int M = s.length();
        int N = t.length();

        int[][] dp = new int[M + 1][N + 1];

        // Base case initialization
        for (int j = 0; j <= N; j++) {
            dp[M][j] = 0;
        }

        // Base case initialization
        for (int i = 0; i <= M; i++) {
            dp[i][N] = 1;
        }

        // Iterate over the strings in reverse so as to
        // satisfy the way we've modeled our recursive solution
        for (int i = M - 1; i >= 0; i--) {
            for (int j = N - 1; j >= 0; j--) {
                // Remember, we always need this result
                dp[i][j] = dp[i + 1][j];

                // If the characters match, we add the
                // result of the next recursion call (in this
                // case, the value of a cell in the dp table
                if (s.charAt(i) == t.charAt(j)) {
                    dp[i][j] += dp[i + 1][j + 1];
                }
            }
        }

        return dp[0][0];
    }
}
