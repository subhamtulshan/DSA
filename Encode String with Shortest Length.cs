/*
Encode String with Shortest Length
Given a non-empty string, encode the string such that its encoded length is the shortest.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.

Note:

k will be a positive integer and encoded string will not be empty or have extra space. You may assume that the input string contains only lowercase English letters. The string's length is at most 160. If an encoding process does not make the string shorter, then do not encode it. If there are several solutions, return any of them is fine.

*/


//though process

/*
Here the idea is to take the subtring of all length and the in for each lenght we consider all the subtring . If the length of 
subtring is <=4 then we cant encode it. else what we do is divide the substr in two parts and check if it can give us a smaller
encoded format. if yes then we store it and now we try to cover if those division are also similar so that we can collab them also(2bc2bc)=>4bc ...




public class Solution {

 public String encode(String s) {
    String[][] dp = new String[s.length()][s.length()];
    
    for(int l=0;l<s.length();l++) // taking substr of all length
	{
        for(int i=0;i<s.length()-l;i++) {
            int j = i+l;
            String substr = s.substring(i, j+1); // then taking all the substring in that again
			
            // Checking if string length < 5. In that case, we know that encoding will not help.
            if(j - i < 4) {
                dp[i][j] = substr;
            } else {
                dp[i][j] = substr;
                // Loop for trying all results that we get after dividing the strings into 2 and combine the   results of 2 substrings
                for(int k = i; k<j;k++) {
                    if((dp[i][k] + dp[k+1][j]).length() < dp[i][j].length()){
                        dp[i][j] = dp[i][k] + dp[k+1][j];
                    }
                }
                
                // Loop for checking if string can itself found some pattern in it which could be repeated.
                for(int k=0;k<substr.length();k++) {
                    String repeatStr = substr.substring(0, k+1);
                    if(repeatStr != null 
                       && substr.length()%repeatStr.length() == 0 
                       && substr.replaceAll(repeatStr, "").length() == 0) {
                          String ss = substr.length()/repeatStr.length() + "[" + dp[i][i+k] + "]";
                          if(ss.length() < dp[i][j].length()) {
                            dp[i][j] = ss;
                          }
                     }
                }
            }
        }
    }
    
    return dp[0][s.length()-1];
  }
}