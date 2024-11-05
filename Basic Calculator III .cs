/*
Basic Calculator III
The expression string contains only non-negative integers, +, -, *, / operators, open ( and closing parentheses ) and empty spaces.
*/

Approach --Here the idea is whenever we get + - we store the current stack(St) in a stack(stp) with their signand when we get a */ we calculate the value of currect stack(st) and then pop an element from stack (Stp) and then perform the operation


import java.io.*;
import java.util.*;

public class Main {
  static class pair
  {
    Stack <Integer> st ;
    Character sign;

    pair(Stack <Integer> s, Character si)
    {
      st = s;
      sign = si;
    }
  }

  public static void cal(Stack <Integer> st, Character sign, Integer val)
  {
    if (sign == '+')
      st.push(val);
    else if (sign == '-')
      st.push(-val);
    else if (sign == '*')
    {
      int a = st.pop();
      int ans = a * val;
      st.push(ans);
    }
    else if (sign == '/')
    {
      int a = st.pop();
      int ans = a / val;
      st.push(ans);
    }
  }


  public static int calculate(String s) {

    char sign = '+';
    Stack<Integer> st = new Stack<>();
    Stack<pair> stp = new Stack<>();

    for (int i = 0; i < s.length(); i++)
    {
      Character c = s.charAt(i);

      if (Character.isDigit(c))
      {
        int val = 0;
        while (i < s.length() && Character.isDigit(s.charAt(i)))
        {
          val = val * 10 + (s.charAt(i) - '0');
          i++;
        }
        i--;
        cal(st, sign, val);
      }
      else if (s.charAt(i) == '(')
      {
        pair p = new pair(st, sign);
        stp.push(p);
        st = new Stack<>();
        sign = '+';
      }
      else if (s.charAt(i) == ')')
      {
        int val = 0;
        while (st.size() > 0)
          val += st.pop();

        pair p = stp.pop();
        sign = p.sign;
        st = p.st;
        cal(st, sign, val);
      }
      if (s.charAt(i) != ' ')
      {
        sign = c;
      }
    }
    int sum = 0;
    while (st.size() > 0)
      sum += st.pop();
    return sum;
  }

  public static void main(String[] args) throws Exception {
    BufferedReader read = new BufferedReader(new InputStreamReader(System.in));

    int result = calculate(read.readLine());
    System.out.println(result);

  }
}
