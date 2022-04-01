/*

Insert a node in a sorted circular linkList*/

Approach-- Here the idea is that we will given some head so we will check if the new node value lie in range[curr,curr.next] both included because of repeated value case.
other case is like the value is greater/smaller then all the value. then it will be inserted at the end of the circular list


class solution
{
	public Node insert(Node head,int value)
	{
		Node node = new Node(value,node);
		
		if(head==null)
			return node;
			
		Node curr=head;
		while(curr.next!=head)
		{
			int currV=curr.data;
			int nextV=curr.next.data;
			
			if(value>=currV && nextV>=currV)
				break;
			else if(currV>nextV)//End of the LL
			{
				if(value>=currV && value>=nextV) //Largest number
					break;
				if(value<=currV && value<=nextV) //smallest number
					break;	
			}
			curr=curr.next;
		}
		
		Node temp=curr.next;
		node.next =temp;
		curr.next=node;	
		return head;
	}
}