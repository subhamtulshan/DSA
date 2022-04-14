/*
Given two binary search trees how do we merge everything so it prints inorder. 
How to remove duplicates from a list
*/

Solution --Using Stacks: While inorder traversal, maintain two stacks that will store the current 
smallest element on the top for each tree and on that basis maintain the result array.


Solution Steps

Create two stacks, stack1 and stack2
Iterate until tree1 is not NULL or tree2 is not NULL or stack1 is not empty or stack2 is not empty.
For each iteration:
Push all the left nodes of tree1 inside stack1
Push all the left nodes of tree2 inside stack2
Compare the top of both the stacks, put the smaller one in the result while popping it out from the respective stack and move to its right child.
Return result




// Structure of a BST Node
class Node {
	int val;
	Node left;
	Node right;
	
	public(int a ,Node l,Node r)
	{
		val=a;
		left=l;
		right=r;
	}
};


List<int> mergeTwoBST(Node root1, Node root2)
{
	List<int> res;
	stack<Node> s1, s2;
	while (root1 || root2 || !s1.empty() || !s2.empty()) {
		while (root1) {
			s1.push(root1);
			root1 = root1.left;
		}
		while (root2) {
			s2.push(root2);
			root2 = root2.left;
		}
		
		// Step 3 Case 1:-
		if (s2.empty() || (!s1.empty() && s1.top()->val <= s2.top()->val)) {
			root1 = s1.top();
			s1.pop();
			res.Add(root1.val);
			root1 = root1.right;
		}
		// Step 3 case 2 :-
		else {
			root2 = s2.top();
			s2.pop();
			res.Add(root2.val);
			root2 = root2.right;
		}
	}
	return res;
}

