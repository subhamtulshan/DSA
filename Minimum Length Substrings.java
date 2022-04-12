
import java.util.HashMap;
import java.util.Map;

/**
 * Created on:  Sep 07, 2020
 * Questions: https://www.facebookrecruiting.com/portal/coding_practice_question/?problem_id=2237975393164055
 
 Minimum Length Substrings
In Facebook recruting I found this question

You are given two strings s and t. You can select any substring of string s and rearrange the characters of the selected substring. Determine the minimum length of the substring of s such that string t is a substring of the selected substring.
Signature
int minLengthSubstring(String s, String t)
Input
s and t are non-empty strings that contain less than 1,000,000 characters each
Output
Return the minimum length of the substring of s. If it is not possible, return -1

Example
s = "dcbefebce"
t = "fd"'
output = 5
 */
 
 /*
 Solution -- The idea is to use slinding window and keep increasing the end until we cover the entire t and then decrease the start untill we can 
 and keep doing this until end reached the s end
 */
 
 
public class MinimumLengthSubstrings {
    public static void main(String[] args) {
        System.out.println(minLengthSubstring("dcbefebce", "fd") + " = 5");
        System.out.println(minLengthSubstring("bbbbbbbbbbb", "aaaaaa") + " = -1");
        System.out.println(minLengthSubstring("aaaaaaaaa", "aaaaaa") + " = 6");
    }

    static int minLengthSubstring(String s, String t) {
        if (t.length() > s.length()) return -1;
        Map<Character, Integer> target = new HashMap<>(), window = new HashMap<>();
        for (char c : t.toCharArray()) {
            target.put(c, target.getOrDefault(c, 0) + 1);
        }
        int found = 0, result = Integer.MAX_VALUE, p1 = 0, p2 = 0, len = s.length();
        while (p2 < len) {
            char cur = s.charAt(p2);
            window.put(cur, window.getOrDefault(cur, 0) + 1);
            if (window.get(cur).equals(target.get(cur))) found++;
//            When all chars in target is present in the window, then reduce the window scope.
            while (found >= target.size()) {
                result = Math.min(result, p2 - p1 + 1);
                cur = s.charAt(p1);
                window.put(cur, window.get(cur) - 1);
                if (window.get(cur) < target.get(cur)) found--;
                p1++;
            }
            p2++;
        }
        return result == Integer.MAX_VALUE ? -1 : result;
    }
}
