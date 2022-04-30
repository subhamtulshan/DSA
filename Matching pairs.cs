This question is from Facebook recruiting portal for practice.

Given two strings s and t of length N, find the maximum number of possible matching pairs in strings s and t after swapping exactly two characters within s.

A swap is switching s[i] and s[j], where s[i] and s[j] denotes the character that is present at the ith and jth index of s, respectively. The matching pairs of the two strings are defined as the number of indices for which s[i] and t[i] are equal. This means you must swap two characters at different indices.

Signature
int matchingPairs(String s, String t)

Input
s and t are strings of length N
N is between 2 and 1,000,000

Output
Return an integer denoting the maximum number of matching pairs

Ex 1
s = "abcd"
t = "adcb"
output = 4

Solution: here the idea is that we will two set of matched and unmatched char and then handle few edge cases


int matchingPairs(String s, String t) {
        Set<String> unMatched = new HashSet<String>();
        Set<Character> matched = new HashSet<Character>();
        int count = 0;
        boolean isDup = false;
       //here we are forming the two set and also keep track of the count of match char
        for(int i=0;i<s.length();i++) 
        {
            if(s.charAt(i) == t.charAt(i)) 
            {
                count++;
                // if its matched and also occured earlier then its duplication.
                if(matched.contains(s.charAt(i))) 
                {
                    isDup = true;
                }
                matched.add(s.charAt(i));
            } else 
            {
                unMatched.add(s.charAt(i) + "" + t.charAt(i));
            }
        }

        //if all char are matched then if there is duplication swap then else we need to swap any two char which will reduce the count
        if(count == s.length()) {
            return isDup ? count :  count - 2;
        }
        
        // if only one char is not matched
        if(count == s.length() - 1) 
        {
            //pulled the only unmatched char
            String onlyUnmatched = (String)unMatched.toArray()[0];
            //if it contain duplication swap then or if matched char contain this unmatched char. its like fill then hole and create in another place
            if(isDup || matched.contains(onlyUnmatched.charAt(0)) || matched.contains(onlyUnmatched.charAt(1)))
                return count;
            return count - 1; // if not then we will need to create a new hole by swaping
        }
        // this is like we have more then one unmatched char and we are trying to see if swaping any two can help us
        for(String um:unMatched)
        {
            // goes through all the unmatchd char and see if the unmatched char contain the reverse so that we can swap and coorect then 
            if(unMatched.contains(um.charAt(1)+""+um.charAt(0))) {
                return count + 2;
            }
        }

        Set<Character> unMatchedS = new HashSet<>();
        Set<Character> unMatchedT = new HashSet<>();
        // this is like we have more then one unmatched char and we can cannot swap two char to coorect then hence we try to find if any 
        //one matches then lets coorect that one hole and return
        for(String um : unMatched) 
        {
            if(unMatchedS.contains(um.charAt(1)) || unMatchedT.contains(um.charAt(0))) 
            {
                return count + 1;
            }
           unMatchedS.add(um.charAt(0));
           unMatchedT.add(um.charAt(1));
        }
        return count;
    }
