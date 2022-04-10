import java.util.HashMap;
import java.util.Map;

/**
 * Created on:  Jul 22, 2020
 * Questions: https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
 Given a string, find the length of the longest possible substring in it that has atmost K distinct characters. If there is no possible substring then print -1.
You can assume that K is less than or equal to the length of the given string.
 
 */
public class LongestSubstringWithAtMostKDistinctCharacters {
    public static void main(String[] args) {
//        System.out.println(lengthOfLongestSubstringKDistinct("eceba",2));
        System.out.println(lengthOfLongestSubstringKDistinct("bacc", 2));
    }

    //      0   1   2   3   4
//      e   c   e   b   a
//              1       2
//    map = {[e:1],[b:1],[a:1]}
//    max = 3

Solution -- here the idea is simple where you use sliding window technique . You create a window unless you get k distinct char and once it cross k then you start 
decreasing size from front and keep doing it. While doing we keep track of max length

    public static int lengthOfLongestSubstringKDistinct(String s, int k) {
        Map<Character, Integer> map = new HashMap<>();
        int max = 0, p1 = 0, p2 = 0;
        while (p2 < s.length()) {
            char cur = s.charAt(p2++);
            while (map.size() > k && p1 < p2) {
                char c2 = s.charAt(p1++);
                int val = map.get(c2);
                if (val-- > 1) map.put(c2, val);
                else map.remove(c2);
            }
            map.put(cur, map.getOrDefault(cur, 0) + 1);
            if (map.size() <= k) max = Math.max(max, p2 - p1);
        }
//        if (map.size() <= k) max = Math.max(max, p2 - p1 + 1);
        return max;
    }
}
