



public class Solution 
{
    /**
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
		if(visited.containsKey(c))
			return visited.get(c);
		
		visited.put(c,true);
        if(adj.containsKey(c))
        {
            for(Character cc :adj.get(c))
            {
                if(cc !=null && dfs(cc))
                    return true;
            }
        }
        visited.put(c,false);
		res.append(c);
        return false;
    }
}