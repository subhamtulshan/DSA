/*

Insert a node in a sorted circular linkList*/

Approach-- Here the idea is that we will given some head so we will check if the new node value lie in range[curr,curr.next] both included because of repeated value case.
other case is like the value is greater/smaller then all the value. then it will be inserted at the end of the circular list


public class Node {
    public int data;
    public Node next;

    public Node(int data) {
        this.data = data;
        this.next = null;
    }
}

public class CircularLinkedList {
    public Node head;

    public CircularLinkedList() {
        head = null;
    }

    public void InsertSorted(int data) {
        Node newNode = new Node(data);

        // Case 1: List is empty, create a single-node circular list
        if (head == null) {
            newNode.next = newNode;
            head = newNode;
            return;
        }

        Node current = head;

        // Case 2: Inserting new node as the smallest element (before head)
        if (data < head.data) {
            // Find the last node in the circular list
            while (current.next != head) {
                current = current.next;
            }

            // Insert newNode before the head and update head
            current.next = newNode;
            newNode.next = head;
            head = newNode; // Update head to the new smallest node
            return;
        }

        // Case 3: Insert in the middle or end of the list
        while (current.next != head && current.next.data < data) {
            current = current.next;
        }

        // Insert newNode between current and current.next
        newNode.next = current.next;
        current.next = newNode;
    }

    public void PrintList() {
        if (head == null) return;

        Node current = head;
        do {
            Console.Write(current.data + " ");
            current = current.next;
        } while (current != head);
        Console.WriteLine();
    }
}

public class Solution {
    public static void Main(string[] args) {
        CircularLinkedList cll = new CircularLinkedList();

        // Insert nodes in sorted order
        cll.InsertSorted(3);
        cll.InsertSorted(1);
        cll.InsertSorted(5);
        cll.InsertSorted(2);

        // Print list
        Console.WriteLine("Sorted Circular Linked List:");
        cll.PrintList();  // Expected output: 1 2 3 5
    }
}
