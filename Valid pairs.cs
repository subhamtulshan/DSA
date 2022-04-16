You are given an array 'ARR' of 'N' integers and two integers 'K' and 'M'.
You need to return true if the given array can be divided into pairs such that the sum of every pair gives remainder 'M' when divided by 'K'. 
Otherwise, you need to return false.


Solution --- 
Given 2 nums 'a' and 'b':
If a % k == x and b % k == k - x :
then (a + b) is divisible by k
Proof :
a % k == x
b % k == k - x
(a + b) % k = ((a + b)%k)%k = (a%k + b%k)%k = (x + k - x)%k = k%k = 0 
Hence, (a + b) % k == 0 and (a + b) is divisible by k.


/*
    Time Complexity: O(N)
    Space Complexity: O(N)
    
    Where 'N' denotes the length of the array.
*/

import java.util.HashMap;
import java.util.Iterator;

public class Solution 
{
    public static boolean isValidPair(int[] arr, int n, int k, int m) 
	{

        // An odd length array cannot be divided into pairs.
        if (n % 2 == 1) 
            return false;
    
		    Create a frequency array to count occurrences of all remainders when divided by k.
        HashMap<Integer, Integer> map = new HashMap<>();

        for (int i = 0; i < n; i++) 
		    {
            int rem = arr[i] % k;
            if (!map.containsKey(rem)) 
			      {
                map.put(rem, 1);
            } 
			
			      else 
			      {
                map.put(rem, map.get(rem) + 1);
            }
        }

        Iterator<Integer> itr = map.keySet().iterator();
        while (itr.hasNext()) 
		    {
            int rem = itr.next();
			      If current remainder divides m into two halves.
            if (2 * rem == m) 
			      {
                // Then there must be even occurrences of such remainder.
                if (map.get(rem) % 2 == 1) 
				        {
                    return false;
                }
            }  
			    Else number of occurrences of remainder must be equal to number of occurrences of m - remainder.
			
            else 
			      {
                if (!map.get((m - rem + k) % k).equals(map.get(rem))) 
				        {
                    return false;
                }
            }
        }
        return true;
    }
}
