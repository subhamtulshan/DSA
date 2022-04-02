/*Description
Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.
*/

Approach 1 -- the idea is to do inorder traversal and keep adding the data to the list till we reach k, and then we will compare the value of the curr node with the node as the start of the list(queue). Because the start of queue is the smallest value.
O(N)
O(K)


public class Solution {
    public List<Integer> closestKValues(TreeNode root, double target, int k) 
	{
        LinkedList<Integer> list = new LinkedList<>(); //used as queue
		inorder(TreeNode root, double target, int k,LinkedList<Integer> list);
		return res;
    }
	inorder(TreeNode root, double target, int k,LinkedList<Integer> list)
		{
			if(root==null)
				return;
			inorder(TreeNode root.left, double target, int k,LinkedList<Integer> list);
				if(list.size() < k)
				{
					list.offer(node.val);
				}else
				{
					if(Math.abs(list.peek() - target) > Math.abs(node.val - target)){
						list.poll();
						list.offer(node.val);
					}else{
						return;
					}
				}
				node = node.right;
			inorder(TreeNode root.right, double target, int k,LinkedList<Integer> list);

		}
}



Approach2- here the idea is that we will use the concept of predecessor and successor where we will keep two stack storing the predecessor and successor of the target. we can say its more like creating a partition as we do in quicksort



public List<Integer> closestKValues(TreeNode root, double target, int k) {
    List<Integer> list = new ArrayList<>();
    Stack<TreeNode> pred = new Stack<>(), succ = new Stack<>();
    initStack(pred, succ, root, target);
    while(k-- > 0){
		//this is just take the data from the stack and compare and add them to the result
        if(succ.isEmpty() || !pred.isEmpty() && target - pred.peek().val < succ.peek().val - target){
            list.add(pred.peek().val);
            getPredecessor(pred);
        }
        else{
            list.add(succ.peek().val);
            getSuccessor(succ);
        }
    }
    return list;
}


//this method just fill the initial succ and pred stack. Here the reason of going left/right in a opposite way is because we know that if we go to the same direction then we will get all the successor/predecessor because of bst property
private void initStack(Stack<TreeNode> pred, Stack<TreeNode> succ, TreeNode root, double target){
    while(root != null){
        if(root.val <= target){
            pred.push(root);
            root = root.right;
        }
        else{
            succ.push(root);
            root = root.left;
        }
    }
}

// once we use a pred val then the next pred will lie on the left of that node to the extrime right(ie the next small value then this curr value)

private void getPredecessor(Stack<TreeNode> st){
    TreeNode node = st.pop();
    if(node.left != null){
        st.push(node.left);
        while(st.peek().right != null)  st.push(st.peek().right);
    }
}

// once we use a succ val then the next succ will lie on the right of that node to the extrime left(ie the next large value then this curr value)

private void getSuccessor(Stack<TreeNode> st){
    TreeNode node = st.pop();
    if(node.right != null){
        st.push(node.right);
        while(st.peek().left != null)   st.push(st.peek().left);
    }
}