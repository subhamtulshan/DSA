Convert a ternary expression to a tree
For example:

a?b:c

  a
 / \
b   c 

a?b?c:d:e
    a 
   / \ 
  b   e
 / \
c   d

a?b:c?d:e
   a
  / \
 b   c
    / \
   d   e


!I start with a stack data structure with an empty node in it and iterated through the expression once. For every character, I follow this rule.
1. if '?', peek at the top of stack and initialize left node. Push left node to stack
2. if ':', pop the top node in the stack, then peek at the top. Initialize right node and push right node to stack
3. if character, peek at top node and set value to that node


using System;
using System.Collections.Generic;

// Definition of a TreeNode
public class TreeNode
{
    public char Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(char value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class TernaryExpressionTree
{
    public TreeNode ConvertToTree(string expression)
    {
        if (string.IsNullOrEmpty(expression))
            return null;

        // Stack to hold the nodes
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        // Create the root node
        TreeNode root = new TreeNode(expression[0]);
        stack.Push(root);

        // Iterate over the expression
        for (int i = 1; i < expression.Length; i++)
        {
            if (expression[i] == '?')
            {
                // Next character is part of the true expression
                i++;
                TreeNode node = new TreeNode(expression[i]);
                stack.Peek().Left = node;  // Attach as the left child
                stack.Push(node);  // Push onto the stack
            }
            else if (expression[i] == ':')
            {
                // Next character is part of the false expression
                i++;
                TreeNode node = new TreeNode(expression[i]);
                stack.Pop();  // Pop the last node since we're done with the true expression
                while (stack.Count > 0 && stack.Peek().Right != null)
                {
                    stack.Pop();  // Ensure we pop nodes that already have both children
                }
                if (stack.Count > 0)
                {
                    stack.Peek().Right = node;  // Attach as the right child
                }
                stack.Push(node);  // Push onto the stack
            }
        }

        return root;
    }

    // Helper function to print the tree (for debugging)
    public void PrintTree(TreeNode root, string indent = "", bool isLeft = true)
    {
        if (root != null)
        {
            Console.WriteLine(indent + (isLeft ? "└── " : "┌── ") + root.Value);
            PrintTree(root.Left, indent + (isLeft ? "    " : "│   "), true);
            PrintTree(root.Right, indent + (isLeft ? "    " : "│   "), false);
        }
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        string expression = "a?b?c?d:e:f?g:h:i?j:k";
        TernaryExpressionTree treeBuilder = new TernaryExpressionTree();
        TreeNode root = treeBuilder.ConvertToTree(expression);

        // Print the tree to verify the structure
        treeBuilder.PrintTree(root);
    }
}
