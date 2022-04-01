/*
Basic Calculator I
Implement a basic calculator to evaluate a simple expression string.
The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces.
*/

Approach -- The idea is the we use a sum variable that will store the value of currect expression and the stack will keep the previous calculated expression. The sign variable is used to store the sign of the currect value.


3-(4+2)+3

step 1 
sum =3
sign=1
stack[];

step 2 == when we get the (

stack[3,-]
sum=0
sign=1

step 3 --till we get )

stack[3,-]
sum=6
sign=1

step 4 = when we get )

pop from stack sign and digit and merge to sum

stack[]
sum=6*-1 +3 = -3
sign=1




import java.io.*;
import java.util.*;

public class Main {

    public static int calculate(String s)
    {
        Integer sum=0;
        Integer sign=1;
        Stack<Integer> st= new Stack<Integer>();
        
        for(int i=0;i<s.length();i++)
        {
            Character c = s.charAt(i);
            if(Character.isDigit(c))
            {
                int val=0;
                while(i<s.length()-1 && Character.isDigit(s.charAt(i)))
                {
                    val =val*10 + (s.charAt(i)-'0');
                    i++;
                }
                i--; // this is done because we will go one index forward in the whileloop then the forloop will also do i++ hence we will skip a char 
                val=val*sign;
                sum+=val;
                sign=1;
            }
            else if(c=='(')
            {
                st.push(sum);
                st.push(sign);
                sum=0;
                sign=+1;
                
            }
            else if(c==')')
            {
                sum*=st.pop();
                sum+=st.pop();
                
            }
            else if(c=='-')
            {
                sign*=-1;
            }
        }
        
        return sum;
    }

    public static void main(String[] args) throws Exception {
        BufferedReader read = new BufferedReader(new InputStreamReader(System.in));

        int result = calculate(read.readLine());
        System.out.println(result);
        
    }
}