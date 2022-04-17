Mike is a little boy who loves solving math problems. One day he was playing with his mom’s mobile. 
The mobile keypad contains 12 buttons { 10 digits(0-9) and 2 characters(‘*’ and ‘#’) }. Mike wants to know how many different numbers he can generate after 
pressing exactly the 'N' buttons on the keypad. Mike presses the buttons with the following rules


/*
    Time Complexity: O(N)
    Space complexity: O(N)
    
    Where N is the number of buttons to press.
*/

Solution --- Here we the thought is at any point we want to know the number of ways to reach any number with k button press. So we create a dp[count][digitpressed]
So think for 2 button press.

we got to each number and check its adjacents,because if we can reach the adjacent then they can also reach us. So the number of way to reach current digit is
sum of all the way to reach its adjacent in count-1 button press. So 


public class Solution {

    public static final int mod = 1000000007;

    public static int generateNumbers(int n) {

        int[][] keypad = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}, {-1, 0, -1}};
        int[] dr = {0, 0, -1, 0, 1};
        int[] dc = {0, -1, 0, 1, 0};

        // Use long long to avoid int overflow.
        // Stores the total numbers that can be generated.
        long ans = 0;

        long[][] dp = new long[n+1][10];

        for (int i = 0; i < 10; i++)
        {
            dp[1][i] = 1; /// for 1 button press the count is 1 always
        }

        for (int i = 2; i <= n; i++)
        {
            for (int r = 0; r < keypad.length; r++)
            {
                for (int c = 0; c < keypad[0].length; c++)
                {
                    int j = keypad[r][c];
                    if (j != -1)
                    {
                        dp[i][j]=0; 
                        for (int x = 0; x < dr.length; x++) //checking all the adjacent of current digit
                        {
                            int tr = r + dr[x];
                            int tc = c + dc[x];
                            if (tr >= 0 && tr < keypad.length && tc >= 0 && tc < keypad[0].length && keypad[tr][tc] != -1) 
                            {
                                dp[i][j] = (dp[i][j] + dp[(i - 1)][keypad[tr][tc]]) % mod; // if adjacent it valid take its prev count from the dp itself
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            ans = (ans + dp[n][i]) % mod;
        }

        return (int)ans;
    }
}
