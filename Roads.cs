
You live in the country with ‘V’ cities that have ‘E’ roads. You are in city ‘S’ with a car having ‘P’ amount of petrol in it.
Roads are bidirectional and consume your petrol. Each road has a description ‘X’, ‘Y’ and ‘Z’, which means city ‘X’ and ‘Y’ 
have a road between them which consumes ‘Z’ amount of petrol.
You want to visit the city ‘D’. Your task is to check if it's possible to visit ‘D’ from ‘S’ using ‘P’ amount of petrol.


Solution -- The idea is to do graph traversal but greedly. ie we will do the bfs but at each point we will pick the vertex which has smaller distance/weight. 
In this way at each point we will get the minimum distance to all the nodes.

/*
	Time Complexity: O((V+E)*log(V))
	Space Complexity: O(V^2). 

	where V and E is the number of vertices and edges in the graph.
*/

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

class The_Comparator implements Comparator<ArrayList<Integer>> {
	public int compare(ArrayList<Integer> str1, ArrayList<Integer> str2) {
		int first_Str;
		int second_Str;
		first_Str = str1.get(0);
		second_Str = str2.get(0);
		if (first_Str > second_Str) 
    {
			return 1;
		} else
    {
			return -1;
		}
	}
}

public class Solution {
	public static int dijkstra(ArrayList<ArrayList<ArrayList<Integer>>> graph, int v, int s, int d) {
		int[] distances = new int[v];
		Arrays.fill(distances, Integer.MAX_VALUE);
		// Distance of source as 0
		distances[s] = 0;
		boolean visited[] = new boolean[v];
		PriorityQueue<ArrayList<Integer>> pq = new PriorityQueue<>(new The_Comparator());
		pq.add(new ArrayList<>(Arrays.asList(distances[s], s)));
		while (!pq.isEmpty()) {
			ArrayList<Integer> front = pq.poll();
			// front pair in min priority queue
			int currentDistance = front.get(0);
			int currVertex = front.get(1);
			// mark currVertex as visited
			visited[currVertex] = true;
			for (int j = 0; j < graph.get(currVertex).size(); j++) 
      {
				if (visited[graph.get(currVertex).get(j).get(0)] == false) 
        {
					if (distances[graph.get(currVertex).get(j).get(0)] > distances[currVertex]+ graph.get(currVertex).get(j).get(1))
          {
						distances[graph.get(currVertex).get(j).get(0)] = distances[currVertex]+ graph.get(currVertex).get(j).get(1);

						ArrayList<Integer> li = new ArrayList<>();
						li.add(distances[graph.get(currVertex).get(j).get(0)]);
						li.add(graph.get(currVertex).get(j).get(0));
						pq.add(li);
					}
				}

			}
		}
		return distances[d];
	}

	public static boolean roadsPossible(int v, int e, int s, int d, int[][] edges, int p) {
		ArrayList<ArrayList<ArrayList<Integer>>> graph = new ArrayList<>(v);

		// Initialization
		for (int i = 0; i < v; i++) {
			ArrayList<ArrayList<Integer>> temp = new ArrayList<>();
			graph.add(temp);
		}

		for (int i = 0; i < e; i++) {
			graph.get(edges[i][0]).add(new ArrayList<>(Arrays.asList(edges[i][1], edges[i][2])));
			graph.get(edges[i][1]).add(new ArrayList<>(Arrays.asList(edges[i][0], edges[i][2])));
		}
		if (dijkstra(graph, v, s, d) <= p) {
			return true;
		} else {
			return false;
		}
	}

}
