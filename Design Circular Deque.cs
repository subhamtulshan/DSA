Design your implementation of the circular double-ended queue (deque).

solution : here we keep two dummy nodes head and tail , this save us from alot of null check and its simple Dll operations

class MyCircularDeque {
    int size;
    DoubleListNode tail;
    DoubleListNode head;
    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        tail = new DoubleListNode(-1);
        head = new DoubleListNode(-1);
        tail.pre = head;
        head.next = tail;
        this.size = 0;
    }
    
    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public boolean insertLast(int value) {
        DoubleListNode node = new DoubleListNode(value);
        node.next = tail;
        node.pre = tail.pre;
        tail.pre.next = node;
        tail.pre = node;
        size++;
        return true;
    }
    
    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public boolean insertFront(int value) {
        DoubleListNode node = new DoubleListNode(value);
        node.next = head.next;
        head.next.pre = node;
        head.next = node;
        node.pre = head;
        size++;
        return true;
    }
    
    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public boolean deleteLast() {
        if (size == 0)
            return false;
        tail.pre.pre.next = tail;
        tail.pre = tail.pre.pre;
        size--;
        return true;
    }
    
    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public boolean deleteFront() {
        if (size == 0)
            return false;
        head.next.next.pre = head;
        head.next = head.next.next;
        size--;
        return true;
    }
    
    /** Get the front item from the deque. */
    public int getRear() {
        return tail.pre.val;
    }
    
    /** Get the last item from the deque. */
    public int getFront() {
        return head.next.val;
    }
    
    /** Checks whether the circular deque is empty or not. */
    public boolean isEmpty() {
        return size == 0;
    }
}

class DoubleListNode {
    DoubleListNode pre;
    DoubleListNode next;
    int val;
    public DoubleListNode(int val) {
        this.val = val;
    }
}
