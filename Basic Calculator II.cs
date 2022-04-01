/*
Basic Calculator II
The expression string contains only non-negative integers, +, -, *, / operators and empty spaces. The integer division should truncate toward zero.
*/

Approach --Here the idea is whenever we get + - we store the number in a stack with their sign and when we get a */ we pop a element from stack and do the operation with the currect element.


import java.io.*;
import java.util.*;

public class Main {
  public static int calculate(String s) {

    int sign='+';int sum=0;     
    Stack<Integer> st = new Stack<>();
    
    for(int i=0;i<s.length();i++)
    {
        Character c= s.charAt(i);
        
        if(Character.isDigit(c))
        {
            int val =0;
            while(i<s.length() && Character.isDigit(s.charAt(i)))
            {
                val=val*10 + (s.charAt(i)-'0');
                i++;
            }
            i--;
            if(sign=='+')
                st.push(val);
            else if(sign=='-')
                st.push(-val);
            else if(sign=='*')
            {
                int a=st.pop();
                int ans =a*val;
                st.push(ans);
            }  
            else if(sign=='/')
            {
                int a=st.pop();
                int ans =a/val;
                st.push(ans);
            }  
        }
        if(s.charAt(i)!=' ')
        {
            sign=c;
        }
    }
    
    while(st.size()!=0)
        sum+=st.pop();
    return sum;
  }

  public static void main(String[] args) throws Exception {
    BufferedReader read = new BufferedReader(new InputStreamReader(System.in));

    int result = calculate(read.readLine());
    System.out.println(result);

  }
}
