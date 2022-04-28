
/*
You need to construct a binary tree from a string consisting of parenthesis and integers.

The whole input represents a binary tree. It contains an integer followed by zero, one or two pairs of parenthesis. The integer represents the root's value and a pair of parenthesis contains a child binary tree with the same structure.

You always start to construct the left child node of the parent first if it exists.
*/


// Here the idea is to store the data in stack and when ever we get a new node we store it in the stack adn check if the peek of stack has left or right child then we add it accordingly. and whenever we get ) mean its a end of this subtree hence we pop the peek from stack.

//Here the catch is that we are considering it to be a proper binary tree i.e all left node will be filled then the right node



public class Solution 
{
    public TreeNode str2tree(String s) 
    {
        if(s==null || s.length()==0)
            return null;

        Stack<TreeNode> st = new Stack<TreeNode>();
        int idx=0;

        while(idx<s.length())
        {
            char c = s.charAt(idx);

            if(Character.isDigit(c) || c=='-')
            {
                int numstart=idx;
                int numend=idx+1;
                while(numend<s.length() && Character.isDigit(s.charAt(numend)))
                    numend++;
                
                int nodeVal= Integer.parseInt(s.substring(numstart,numend));
                TreeNode node = new TreeNode(nodeVal);

                if(!st.empty())
                {
                    TreeNode root = st.peek();
                    if(root.left==null)
                    {
                        root.left=node;
                    }
                    else
                    {
                        root.right=node;
                    }
                }
                st.add(node);
                idx=numend;
            }
            else if(c=='(')
            {
                idx++;
            }
            else
            {
                st.pop();
                idx++;
            }
        }
    return st.pop();
    }
}



//Approach 2 -- only if interviewer dont agree with the previous one.. This will create any kinda tree. 
what we are doing is whenevere we get a number we create a node and then check the next char after that if its ( then we create a left and 
then we again check for ( 


/**
 * Definition of TreeNode:
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left, right;
 *     public TreeNode(int val) {
 *         this.val = val;
 *         this.left = this.right = null;
 *     }
 * }
 */

public class Solution {
    /**
     * @param s: a string
     * @return: return a TreeNode
     */
    int idx = 0;

    public TreeNode str2tree(String s) {
        // write your code here
        int len = s.length();
        if (len == 0 || idx >= len)
            return null;
        int sig = 1, k = 0;
        if (s.charAt(idx) == '-') {
            sig = -1;
            ++idx;
        }
        while (idx < len && s.charAt(idx) >= '0' && s.charAt(idx) <= '9') {
            k = k * 10 + s.charAt(idx) - '0';
            ++idx;
        }
        TreeNode root = new TreeNode(sig * k);
        if (idx >= len || s.charAt(idx) == ')') {
            ++idx;
            return root;
        }
        ++idx;
        root.left = str2tree(s);
        if (idx >= len || s.charAt(idx) == ')') {
            ++idx;
            return root;
        }
        ++idx;
        root.right = str2tree(s);
        if (idx >= len || s.charAt(idx) == ')') {
            ++idx;
            return root;
        }
        return root;
    }
}
