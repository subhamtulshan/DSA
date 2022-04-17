You are given N activities with their start time Start[] and finish time Finish[]. 
You need to tell the maximum number of activities a single person can perform.

OR

There are some spherical balloons taped onto a flat wall that represents the XY-plane. 
The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] denotes a balloon whose horizontal diameter 
stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.
Arrows can be shot up directly vertically (in the positive y-direction) from different points along the x-axis. 
A balloon with xstart and xend is burst by an arrow shot at x if xstart <= x <= xend. There is no limit to the number of arrows that can be shot. 
A shot arrow keeps traveling up infinitely, bursting any balloons in its path.
Given the array points, return the minimum number of arrows that must be shot to burst all balloons.

 

//Solution -- Here the idea is that we will sort the interval in increasin oreder of end time and then keep selecting the activicy if possible. ie
if the end time is smaller then the next start time.

/*
    Time Complexity: O(N * logN)
    Space Complexity: O(N)

    Where N is the number of activities.
*/

import java.util.List;
import java.util.ArrayList;
import javafx.util.Pair;
import java.util.Comparator;
public class Solution {
    public static int maximumActivities(List<Integer> start, List<Integer> finish) {
        int n = start.size();
        List<Pair<Integer, Integer>> activity = new ArrayList<Pair<Integer, Integer>>();

        for (int i = 0; i < n; i++){   
            Pair <Integer, Integer> temp =  new Pair <Integer, Integer> (finish.get(i), start.get(i)); 
            activity.add(temp);
        }

        // Sort the meetings according to their Finishing Time.
        activity.sort(new Comparator<Pair<Integer, Integer>>() {    
	        @Override
	        public int compare(Pair<Integer, Integer> o1, Pair<Integer, Integer> o2) {
                return o1.getKey().compareTo(o2.getKey());  
	        }               
	    });

        int maxActivity = 1;
        int currentTime = activity.get(0).getKey();

        for(Pair<Integer, Integer> p: activity) {
            // Find the next meeting available.
            if (p.getValue() >= currentTime) {
                maxActivity++;
                currentTime = p.getKey();
            }
        }
        return maxActivity;
    }

}


