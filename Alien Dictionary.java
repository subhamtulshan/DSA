



public class Solution 
{
    /**
   TIime Complexity-- Building the graph takes O(n). Topological sort takes O(V + E).
   space -- O(number of words) -- assuming each word can contribute max 1 char
     * @param words: a list of words
     * @return: a String which is correct order
     */
    StringBuilder res=new StringBuilder();  
	HashMap<Character,Boolean> visited = new HashMap<Character,Boolean>();
	HashMap<Character,HashSet<Character>> adj = new HashMap<Character,HashSet<Character>>();
    public String alienOrder(String[] words) 
	{
		for(int i=0;i<words.length-1;i++)
		{
			String w1=words[i];
			String w2=words[i+1];
			int minL=Math.min(w1.length(),w2.length());
			//this check for the condition where two prefix are same but large word occur later 
			if(w1.length()>w2.length() && w1.substring(0,minL)==w2.substring(0,minL))
				return "";
			for(int j=0;j<minL;j++)
			{
				if(w1.charAt(j)!=w2.charAt(j))
				{
                   			adj.putIfAbsent(w1.charAt(j),new HashSet<Character>());
					HashSet<Character> d= adj.get(w1.charAt(j));
                    			d.add(w2.charAt(j));
                    			adj.remove(w1.charAt(j));
                    			adj.put(w1.charAt(j),d);
					break;
				}
			}
		}	
        for(Map.Entry m : adj.entrySet())
        {    
            if(dfs((Character)m.getKey()))
		return "";
        }  	
        System.out.println(res.reverse());
        return res.toString();		
    }
	
	public Boolean dfs(Character c) 
	{
	//if the node is in the hashMap it mean either its been visited(false) or its in the path(true)-> mean there is a cycle
	if(visited.containsKey(c))
		return visited.get(c);
	//Here the true mean the current node is in the path. 
	visited.put(c,true);
	
        if(adj.containsKey(c))
        {
            for(Character cc :adj.get(c))
            {
                if(cc !=null && dfs(cc))
                    return true;
            }
        }
	//here false mean the path is visited and not in the path
        visited.put(c,false);
	//the char is added after all its child are done post order dfs a->b->c and a->c // try this case with normal dfs wrong ans ayega
	res.append(c);
        return false;
    }
}
