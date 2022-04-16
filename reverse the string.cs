
//Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Solution -- The idea is that we will loop through the word and for each word we find i as start and make j as end then we reverse it , we skip the " ".
Here the Time Complexity is o(2n) because we are reading each word two times once to find the entire word and then to reverse it.

public class Solution {
    public String reverseWords(String s) {
        char[] ca = s.toCharArray();
        for (int i = 0; i < ca.length; i++) {
            if (ca[i] != ' ') {   // when i is a non-space
                int j = i;
                while (j + 1 < ca.length && ca[j + 1] != ' ') { j++; } // move j to the end of the word
                reverse(ca, i, j);
                i = j;
            }
        }
        return new String(ca);
    }

    private void reverse(char[] ca, int i, int j) {
        for (; i < j; i++, j--) {
            char tmp = ca[i];
            ca[i] = ca[j];
            ca[j] = tmp;
        }
    }
}



Given an input string s, reverse the order of the words.
A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.
Return a string of the words in reverse order concatenated by a single space.
Input: s = "the sky is blue"
Output: "blue is sky the"


How solution is working-

__abc__def__(input)
__fed__cba__(reverse entire string)
__def__abc__(reverse each word)
def_abc (removing space)

public class Solution {
  
  public String reverseWords(String s) {
    if (s == null) return null;
    
    char[] a = s.toCharArray();
    int n = a.length;
    
    // step 1. reverse the whole string
    reverse(a, 0, n - 1);
    // step 2. reverse each word
    reverseWords(a, n);
    // step 3. clean up spaces
    return cleanSpaces(a, n);
  }
  
  void reverseWords(char[] a, int n) {
    int i = 0, j = 0;
      
    while (i < n) {
      while (i < j || i < n && a[i] == ' ') i++; // skip spaces
      while (j < i || j < n && a[j] != ' ') j++; // skip non spaces
      reverse(a, i, j - 1);                      // reverse the word
    }
  }
  
  // trim leading, trailing and multiple spaces
  String cleanSpaces(char[] a, int n) {
    int i = 0, j = 0; // i is the actual position of char and j traverse the array
      
    while (j < n) {
      while (j < n && a[j] == ' ') j++;             // skip spaces at the start 
      while (j < n && a[j] != ' ') a[i++] = a[j++]; // then shift the non space to the proper position using i
      while (j < n && a[j] == ' ') j++;             // skip the middle space or trailing space
      if (j < n) a[i++] = ' ';                      // if the previous were trailing then no need to add space else add a space
    }
    return new String(a).substring(0, i);
  }
  
  // reverse a[] from a[i] to a[j]
  private void reverse(char[] a, int i, int j) {
    while (i < j) {
      char t = a[i];
      a[i++] = a[j];
      a[j--] = t;
    }
  }
  
}
