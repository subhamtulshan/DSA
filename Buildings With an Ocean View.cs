/*
There are n buildings in a line. You are given an integer array heights of size n that represents the heights of the buildings in the line.

The ocean is to the right of the buildings. A building has an ocean view if the building can see the ocean without obstructions. Formally, a building has an ocean view if all the buildings to its right have a smaller height.

Return a list of indices (0-indexed) of buildings that have an ocean view, sorted in increasing order.
*/

Solution- Here the idea is to maintian a height variable that store the max height so far, if we get a height greater then this we add to the result and update maxheight.


class Solution {
    public int[] findBuildings(int[] heights) {
        int length = heights.length;
		List<int> buildings = new List<int>();
        int maxHeight = -1;
        for (int i = length - 1; i >= 0; i--) {
            if (heights[i] > maxHeight) 
			{
				buildings.add(i);
				maxHeight=height[i];
            }
        }
        return buildings;
    }
}