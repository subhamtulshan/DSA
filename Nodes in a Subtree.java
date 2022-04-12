/*
Nodes in a Subtree
You are given a tree that contains N nodes, each containing an
integer u which corresponds to a lowercase character c in the string
s using 1-based indexing. You are required to answer Q queries of
type [u, c], where u is an integer and c is a lowercase letter. The
query result is the number of nodes in the subtree of node u
containing c.

Signature:
int[] countOfNodes(Node root, ArrayList<Query> queries, String s)

Input
A pointer to the root node, an array list containing Q queries of
type [u, c], and a string s

Constraints
N and Q are the integers between 1 and 1,000,000 u is an integer
between 1 and N s is of the length of N, containing only lowercase
letters c is a lowercase letter contained in string s Node 1 is the
root of the tree

Output
An integer array containing the response to each query

Solution
 
 A O(n+m) solution is possible if we use data structure to help.
basic idea:

use Map to store the count of each character under one node
a node's Map is the consolidated result of all its children + itself
once the Map is built, go thru queries and do lookup in the map

The idea is that we create a count map that store the <char,int> map for each node

here is my code:
*/

  private Map<Character, Integer> dfs(Node node, String s, Map<Integer, Map<Character, Integer>> countMap) {
    Map<Character, Integer> charCountMap = new HashMap<>();
    charCountMap.put(s.charAt(node.val - 1), 1);
    
    for (Node child : node.children) {
      for (Map.Entry<Character, Integer> entry : dfs(child, s, countMap).entrySet()) {
        charCountMap.put(entry.getKey(), charCountMap.getOrDefault(entry.getKey(), 0) + entry.getValue());
      }
    }
    
    countMap.put(node.val, charCountMap);
    return charCountMap;
  }

  int[] countOfNodes(Node root, ArrayList<Query> queries, String s) {
    int[] result = new int[queries.size()];
    
    Map<Integer, Map<Character, Integer>> countMap = new HashMap<>();
    dfs(root, s, countMap);
    
    int index = 0;
    for (Query q : queries) {
      result[index++] = countMap.get(q.u).getOrDefault(q.c, 0);
    }
    
    return result;
  }
  
  
  Note
  This is the solution I came up with as well but the reason this is O(n+m) was not quite obvious to me at first since we 
  have to copy the child nodes' hash maps on to the parent it seems like it will take n^2 time if all the nodes have unique 
  chars giving a O(n^2 + m). However, the number of unique chars is bound to 26 so we can have at most 26 unique char child nodes to 
  a parent node due to chars in the string being all lowercase, so worst case is actually O(n*26 + m).
