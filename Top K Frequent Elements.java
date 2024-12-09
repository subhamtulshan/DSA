https://leetcode.com/problems/top-k-frequent-elements/description

Approach 2: Quickselect (Hoare's selection algorithm)
Quickselect is a textbook algorithm typically used to solve the problems "find kth something": kth smallest, kth largest, kth most frequent, kth less frequent, etc. Like quicksort, quickselect was developed by Tony Hoare and is also known as Hoare's selection algorithm.
It has O(N) average time complexity and is widely used in practice. It is worth noting that its worst-case time complexity is O(N 
2
 ), although the probability of this worst-case is negligible.
The approach is the same as for quicksort.
One chooses a pivot and defines its position in a sorted array in a linear time using the so-called partition algorithm.
As an output, we have an array where the pivot is in its perfect position in the ascending sorted array, sorted by the frequency. All elements on the left of the pivot are less frequent than the pivot, and all elements on the right are more frequent or have the same frequency.
Hence the array is now split into two parts. If by chance our pivot element took N - kth final position, then k elements on the right are these top k frequent we're looking for. If not, we can choose one more pivot and place it in its perfect position.
diff
If that were a quicksort algorithm, one would have to process both parts of the array. That would result in O(NlogN) time complexity. In this case, there is no need to deal with both parts since one knows in which part to search for N - kth less frequent element, and that reduces the average time complexity to O(N).

Algorithm
The algorithm is quite straightforward :
Build a hash map element -> its frequency and convert its keys into the array unique of unique elements. Note that elements are unique, but their frequencies are not. That means we need a partition algorithm that works fine with duplicates.
Work with unique array.
Use a partition scheme (please check the next section) to place the pivot into its perfect position pivot_index in the sorted array, move less frequent elements to the left of the pivot, and more frequent or of the same frequency - to the right.
Compare pivot_index and N - k.
If pivot_index == N - k, the pivot is N - kth most frequent element, and all elements on the right are more frequent or of the same frequency. Return these top k frequent elements.
Otherwise, choose the side of the array to proceed recursively.
diff
Lomuto's Partition Scheme
There is a zoo of partition algorithms. The most simple one is Lomuto's Partition Scheme, and so is what we will use in this article.
Here is how it works:
Move the pivot at the end of the array using swap.
Set the pointer at the beginning of the array store_index = left.
Iterate over the array and move all less frequent elements to the left swap(store_index, i). Move store_index one step to the right after each swap.
Move the pivot to its final place, and return this index.

Code: 
class Solution {
    int[] unique;
    Map<Integer, Integer> count;

    public void swap(int a, int b) {
        int tmp = unique[a];
        unique[a] = unique[b];
        unique[b] = tmp;
    }

    public int partition(int left, int right, int pivot_index) {
        int pivot_frequency = count.get(unique[pivot_index]);
        // 1. Move pivot to end
        swap(pivot_index, right);
        int store_index = left;

        // 2. Move all less frequent elements to the left
        for (int i = left; i <= right; i++) {
            if (count.get(unique[i]) < pivot_frequency) {
                swap(store_index, i);
                store_index++;
            }
        }

        // 3. Move the pivot to its final place
        swap(store_index, right);

        return store_index;
    }
    
    public void quickselect(int left, int right, int k_smallest) {
        /*
        Sort a list within left..right till kth less frequent element
        takes its place. 
        */

        // base case: the list contains only one element
        if (left == right) return;
        
        //Select a random pivot_index
        Random random_num = new Random();
        int pivot_index = left + random_num.nextInt(right - left); 

        // Find the pivot position in a sorted list
        pivot_index = partition(left, right, pivot_index);

        // If the pivot is in its final sorted position
        if (k_smallest == pivot_index) {
            return;    
        } else if (k_smallest < pivot_index) {
            // go left
            quickselect(left, pivot_index - 1, k_smallest);     
        } else {
            // go right 
            quickselect(pivot_index + 1, right, k_smallest);  
        }
    }
    
    public int[] topKFrequent(int[] nums, int k) {
        // Build hash map: character and how often it appears
        count = new HashMap();
        for (int num: nums) {
            count.put(num, count.getOrDefault(num, 0) + 1);
        }
        
        // Array of unique elements
        int n = count.size();
        unique = new int[n]; 
        int i = 0;
        for (int num: count.keySet()) {
            unique[i] = num;
            i++;
        }
        
        // kth top frequent element is (n - k)th less frequent.
        // Do a partial sort: from less frequent to the most frequent, till
        // (n - k)th less frequent element takes its place (n - k) in a sorted array. 
        // All elements on the left are less frequent.
        // All the elements on the right are more frequent. 
        quickselect(0, n - 1, n - k);
        // Return top k frequent elements
        return Arrays.copyOfRange(unique, n - k, n);
    }
}
