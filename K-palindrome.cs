/*
Given a string, find out if the string is K-Palindrome or not. A K-palindrome string transforms into a palindrome on removing at most k characters from it.
Examples: 
 

Input : String - abcdecba, k = 1
Output : Yes
String can become palindrome by removing
1 character i.e. either d or e
*/

Solution -- Here the idea is that we find the longest common subsequence of string s and reverse of it. If the length of s - LCS<=k then true else 
we cant make k palidrome

Idea for LCS --- Create a Dp table 
If last characters of both sequences match (or X[m-1] == Y[n-1]) then 
L(X[0..m-1], Y[0..n-1]) = 1 + L(X[0..m-2], Y[0..n-2])

If last characters of both sequences do not match (or X[m-1] != Y[n-1]) then 
L(X[0..m-1], Y[0..n-1]) = MAX ( L(X[0..m-2], Y[0..n-1]), L(X[0..m-1], Y[0..n-2]) )


static int lcs( char[] X, char[] Y, int m, int n )
    {
        int [,]L = new int[m+1,n+1];
     
        /* Following steps build L[m+1][n+1] in bottom up fashion. Note that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] */
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0) // if any one is zero then lcs will be zero
                    L[i, j] = 0;
                else if (X[i - 1] == Y[j - 1]) // if  curr char matches then it will be 1++ last chars
                    L[i, j] = L[i - 1, j - 1] + 1;
                else
                    L[i, j] = max(L[i - 1, j], L[i, j - 1]); // if they dont match then max of including either one of them
            }
        }
        return L[m, n];
    }
    
    
    static bool isKPalindrome(String str, int k)
    {
        int n = str.Length;
 
        // Find reverse of String
        str = reverse(str);
 
        // find longest palindromic
        // subsequence of given String
        int lps = lcs(str, str, n, n);
 
        // If the difference between longest
        // palindromic subsequence and the
        // original String is less than equal
        // to k, then the String is k-palindrome
        return (n - lps <= k);
    }
