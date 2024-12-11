Approach: Union Find
Intuition
We can treat the 2D grid as an undirected graph. A land cell corresponds to a node in the graph, and there is an edge between two horizontally or vertically adjacent land cells.

Let's see what forms an island in such a graph. So, we begin at any node and proceed to its neighbors, i.e., all nodes one edge away. From the nodes 1 edge away, we move to their neighbors, i.e., all the nodes 2 edges away from the starting node, and so on. If we keep traversing until we can't anymore, all the nodes that are visited in this traversal together form an island.

In such a graph, a connected component forms one island. Our task now becomes to count the number of connected components formed after converting a cell into land for every cell mentioned in positions. A union-find data structure is a good approach to efficiently determining the number of connected components in a graph.

A disjoint-set data structure, also called a union–find data structure or merge–find set, is a data structure that stores a collection of disjoint (non-overlapping) sets. Equivalently, it stores a partition of a set into disjoint subsets. It provides operations for adding new sets, merging sets (replacing them by their union), and finding a representative member of a set. It implements two useful operations:

Find: Determine which subset a particular element is in. This can be used to determine if two elements are in the same subset.
Union: Join two subsets into a single subset.
If you are new to Union-Find, we suggest you read our Leetcode Explore Card. We will not talk about implementation details in this article, but only about the interface to the data structure.

We first perform a linear mapping to convert a 2D grid to a linear array. We map a cell (x, y) in the grid to point = x * n + y, where n is the number of columns.

To our union-find data structure, we add a data member count that stores the number of connected components (or disjoint sets) present in the graph. We also include an addLand method, which takes an index corresponding to a square as a parameter and adds it as a node in the graph. It also increases count by 1 because we added a new node that creates a new component in the graph.

We also include an isLand method, which returns a boolean indicating whether there is land at a point given as a parameter. It does so by checking the parent of the point. If the point has a valid parent, it is a valid node, and thus it is land. Otherwise, if the point does not have a valid parent, it is water.

The numberOfIslands method is also added, which returns count, i.e., the number of connected components present in the graph.

To solve this problem, we declare an instance of union-find UnionFind(m * n) and then iterate over every position in positions. We perform a linear mapping of position to convert a 2D cell to a linear point. Let's call this linear point landPosition.

We perform addLand(landPosition) to add a node corresponding to landPosition. We then iterate over all four neighbors of position. We convert every neighbor to a linear index neighborPosition. If there is land at neighborPosition, which is checked using the isLand method, we perform a union of neighborPosition and landPosition. In the union method, if two nodes belong to different sets (or components), we merge them, which reduces the number of connected components by 1. Hence, in the union method, we decrement count by 1 if the given nodes belong to different components.

Finally, for each position, we add numberOfIslands as the answer to a list of integers.

COde 
class UnionFind {
    int[] parent;
    int[] rank;
    int count;

    public UnionFind(int size) {
        parent = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
            parent[i] = -1;
        count = 0;
    }

    public void addLand(int x) {
        if (parent[x] >= 0)
            return;
        parent[x] = x;
        count++;
    }

    public boolean isLand(int x) {
        if (parent[x] >= 0) {
            return true;
        } else {
            return false;
        }
    }

    int numberOfIslands() {
        return count;
    }

    public int find(int x) {
        if (parent[x] != x)
            parent[x] = find(parent[x]);
        return parent[x];
    }

    public void union(int x, int y) {
        int xset = find(x), yset = find(y);
        if (xset == yset) {
            return;
        } else if (rank[xset] < rank[yset]) {
            parent[xset] = yset;
        } else if (rank[xset] > rank[yset]) {
            parent[yset] = xset;
        } else {
            parent[yset] = xset;
            rank[xset]++;
        }
        count--;
    }
}

class Solution {
    public List<Integer> numIslands2(int m, int n, int[][] positions) {
        int x[] = { -1, 1, 0, 0 };
        int y[] = { 0, 0, -1, 1 };
        UnionFind dsu = new UnionFind(m * n);
        List<Integer> answer = new ArrayList<>();

        for (int[] position : positions) {
            int landPosition = position[0] * n + position[1];
            dsu.addLand(landPosition);

            for (int i = 0; i < 4; i++) {
                int neighborX = position[0] + x[i];
                int neighborY = position[1] + y[i];
                int neighborPosition = neighborX * n + neighborY;
                // If neighborX and neighborY correspond to a point in the grid and there is a
                // land at that point, then merge it with the current land.
                if (neighborX >= 0 && neighborX < m && neighborY >= 0 && neighborY < n &&
                        dsu.isLand(neighborPosition)) {
                    dsu.union(landPosition, neighborPosition);
                }
            }
            answer.add(dsu.numberOfIslands());
        }
        return answer;
    }
}
