There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you 
want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers,
return any of them. If it is impossible to finish all courses, return an empty array.

solution :

public class Solution {
    public int[] findOrder(int numCourses, int[][] prerequisites) {
        //prepare
        List<List<Integer>> graph = new ArrayList<>();
        for(int i = 0; i < numCourses; i++){
            graph.add(new ArrayList<>());
        }

        for(int[] pair : prerequisites){
            graph.get(pair[0]).add(pair[1]);
        }

        Map<Integer, Integer> visited = new HashMap<>();
        //initail visited
        for(int i = 0; i < numCourses; i++){
            visited.put(i, 0);//0 -> unvisited, 1 -> visiting, 2 -> visited
        }

        List<Integer> res = new ArrayList<>();
        for(int i = 0; i < numCourses; i++){
            if(!topoSort(res, graph, visited, i)) return new int[0];
        }

        int[] result = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
        {
            result[i] = res.get(i);
        }
        return result;
    }

    //the return value of this function only contains the ifCycle info and does not interfere dfs process. if there is Cycle, then return false
    private boolean topoSort(List<Integer> res, List<List<Integer>> graph, Map<Integer, Integer> visited, int i){
        int visit = visited.get(i);
        if(visit == 2){//when visit = 2, which means the subtree whose root is i has been dfs traversed and all the nodes in subtree has been put in the result(if we request), so we do not need to traverse it again
            return true;
        }if(visit == 1){
            return false;
        }

        visited.put(i, 1);
        for(int j : graph.get(i)){
            if(!topoSort(res, graph, visited, j)) return false;
        }
        visited.put(i, 2);
        res.add(i);//the only difference with traversing a graph

        return true;
    }
}
