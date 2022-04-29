

Solution: Here the idea is to do bfs and try to detect cycle in the graph.

public class Solution {
        public boolean canFinish(int numCourses, int[][] prerequisites) {
            ArrayList[] graph = new ArrayList[numCourses];
            for(int i=0;i<numCourses;i++)
                graph[i] = new ArrayList();
            boolean[] visited = new boolean[numCourses];
            for(int i=0; i<prerequisites.length;i++)
            {
                graph[prerequisites[i][1]].add(prerequisites[i][0]);
            }

            for(int i=0; i<numCourses; i++)
            {
                if(!dfs(graph,visited,i))
                    return false;
            }
            return true;
        }

        private boolean dfs(ArrayList[] graph, boolean[] visited, int course){
            if(visited[course])
                return false;
            if(graph[course].size()==0) // if some course is done we dont want to visit again and do dfs there
                return true;
            
            visited[course] = true;;
            for(int i=0; i<graph[course].size();i++){
                if(!dfs(graph,visited,(int)graph[course].get(i)))
                    return false;
            }
            visited[course] = false;
            graph[course].clear(); // making sure this is not visited again
            return true;
        }
    }
