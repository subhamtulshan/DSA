/*
Given a string, we can "shift" each of its letter to its successive letter, for example: "abc" -> "bcd". We can keep "shifting" which forms the sequence:

"abc" -> "bcd" -> ... -> "xyz"
Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.

For example, given: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"],
A solution is:

[
  ["abc","bcd","xyz"],
  ["az","ba"],
  ["acef"],
  ["a","z"]
]
*/


soltuion
The key to this problem is how to identify strings that are in the same shifting sequence. There are different ways to encode this.

In the following code, this manner is adopted: for a string s of length n, we encode its shifting feature as "s[1] - s[0], s[2] - s[1], ..., s[n - 1] - s[n - 2],".

Then we build an unordered_map, using the above shifting feature string as key and strings that share the shifting feature as value.
We store all the strings that share the same shifting feature in a vector.

A final note, since the problem statement has given that "az" and "ba" belong to the same shifting sequence. 
So if s[i] - s[i - 1] is negative, we need to add 26 to it to make it positive and give the correct result.


class Solution {

    string getHash(string& s) {
        string key=""; // for char like a the string will be empty and stores like that only in hashmap
        int n = s.size();
        for (int i = 1; i < n; ++i) {
            int diff = s[i]-s[i-1];
            if (diff < 0) diff += 26;
            // change the difference from numbers to lower-case alphabets using 'a' + diff
            key +=diff + '_';
        }
        return key;
    }
    List<List<string>> groupStrings(list<string> strings) {
        HashMap<string, List<string>> map;
        List<List<string>> res;
        for(String s : strings){
            String hash = getHash(s);
            if(map.containsKey(hash)){
                map.get(hash).add(s);
            }else{
                List<String> l = new ArrayList<>();
                l.add(s);
                map.put(hash, l);
            }
        }
       
      for(Map.Entry e : map.entrySet()){
            List<String> l = (List<String>)e.getValue();
            Collections.sort(l); as they have asked for lexographically
            result.add(l);
        }
        return result;    }
};
