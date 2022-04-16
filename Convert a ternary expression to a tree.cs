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


Node ternaryToTree(String exp) {
        Stack stack = new Stack();
        Node node = new Node();
        stack.push(node);
        for(int i = 0; i < exp.length(); i++) {
                char c = exp.charAt(i);
                if(c == '?') {
                        stack.peek().left = new Node();
                        stack.push(stack.peek().left);
                } else if(c == ':') {
                        stack.pop();
                         //String input = "a?b?c?d:e:f?g:h:i?j:k" use this to clearify ,dont create the entire string , but create till f atleast 
                         while (stack.peek().right != null) 
                         {
                          stack.pop();
                         }
                        stack.peek().right = new Node();
                        stack.push(stack.peek().right);
                } else {
                        stack.peek().val = c;
                }
        }
        return node;
}
