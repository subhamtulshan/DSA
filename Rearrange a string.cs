/*
Given a string containing uppercase alphabets and integer digits 
(from 0 to 9), the task is to print the alphabets in the lexicographical order followed by the sum of digits.

Input: S = "AC2BEW3"
Output: "ABCEW5"
Explanation: 2 + 3 = 5 and we print all
alphabets in the lexicographical order. 
*/

Solution--

class Solution
{
    public String arrangeString(String s)
        {
            int[] c= new int[26];
            int sum=0;
            String res="";
            for(Integer i=0;i<s.length();i++)
            {
                if(!Character.isDigit(s.charAt(i)))
                {
                    c[s.charAt(i)-'A']++;
                }
                else
                    sum+=Integer.parseInt(String.valueOf(s.charAt(i)));
            }
            for(int i=0;i<26;i++)
            {
                while(c[i]>0)
                {
                    res+=(char)(i+'A');
                    c[i]--;
                }
            }
            res+=sum==0?"":sum;
            return res;
            
        }
}
