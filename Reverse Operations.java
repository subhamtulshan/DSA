/*
Reverse Operations

You are given a singly-linked list that contains N integers. A subpart of the list is a contiguous set of even elements, bordered either by the end of the list or an odd element. For example, if the list is [1, 2, 8, 9, 12, 16], the subparts of the list are [2, 8] and [12, 16].
Then, for each subpart, the order of the elements is reversed. In the example, this would result in the new list, [1, 8, 2, 9, 16, 12].
The goal of this question is: given a resulting list, determine the original order of the elements.
Implementation detail:
You must use the following definition for elements in the linked list:

class Node {
    int data;
    Node next;
}
Signature
Node reverse(Node head)
Constraints
1 <= N <= 1000, where N is the size of the list
1 <= Li <= 10^9, where Li is the ith element of the list
Example
Input:
N = 6
list = [1, 2, 8, 9, 12, 16]
Output:
[1, 8, 2, 9, 16, 12]
*/

Solution-- Here the idea is that we will use a dummy node and then the similar concept of prev and curr . we will keep moving them forward until we get a even node
and once we get a even node then we will use a new function to reeverse all the node of this even subpart and then return the head in tha save prev/curr way



  // Returns the last odd node as new head after reverse.
  // 2 -> 4 -> 6 -> 7
  // 6 -> 4 -> 2 -> 7
  // to reverse the even subpart
  Node reverseEvens(Node head) {
    Node prev = null;
    Node curr = head;
    
    while (curr != null && curr.data % 2 == 0) {
      Node t = curr.next;  
      curr.next = prev;     
      
      prev = curr;
      curr = t;
    }
    
    head.next = curr;
    return prev;
  }
  Node reverse(Node head) {
    Node dummy = new Node(0);
    dummy.next = head;
    
    Node prev = dummy;
    Node curr = head;
    
    while (curr != null) {
      if (curr.data % 2 == 0) {
        prev.next = reverseOdds(curr);
      }
      
      prev = curr;
      curr = curr.next;
    }
    
    return dummy.next;
  }
