/*
You are given a shcedule of tasks to work on. Each tasks has a start and an end time [start, end] where end > start. Find out for the given schedule:

in what intervals you are working (at least 1 task ongoing)
in what intervals you are multitasking (at least 2 tasks ongoing)
In other words, find union and intersection of a list of intervals. The input is sorted by start time.

Example:
Input: [[1, 10], [2, 6], [9, 12], [14, 16], [16, 17]]

Output union: [[1, 12], [14, 17]]
Explanation: We just need to merge overlapping intervals https://leetcode.com/problems/merge-intervals

Output intersection: [[2, 6], [9, 10]]
*/

Solution 1 --- here we will try to find both the union and intersection  diffenently


public static void main(String args[]) 
{
        Interval arr[]=new Interval[4];
        arr[0]=new Interval(6,8);
        arr[1]=new Interval(1,9);
        arr[2]=new Interval(2,4);
        arr[3]=new Interval(4,7);
        return getunion(arr);
		return getIntersection(arr);
}

     
    // Function that takes a set of intervals, merges overlapping intervals and prints the result
    public static int[[] getunion(Interval arr[])
    {  
		int index = 0; // Stores index of last element
        // in output array (modified arr[])
   
        // Traverse all input Intervals
        for (int i=1; i<arr.length; i++)
        {
            // If this is not first Interval and overlaps
            // with the previous one
            if (arr[index].end >=  arr[i].start)
            {
                   // Merge previous and current Intervals
                arr[index].end = Math.max(arr[index].end, arr[i].end);
            }
            else {
                index++;
                arr[index] = arr[i];
            }   
        }
         
        return arr;
    }
 
 public static int[] getIntersection(intervals[])
 {
    
	if(intervals==null || intervals.length==0)
		return [];
    List<interval> ans = new List<>();

    interval prev = intervals[0]

    for(int i=1;i<intervals.length;i++)
	{
		int prev_start=prev[0];
		int prev_stop=prev[1];
		
		lo = Math.max(intervals[i][0], prev_start);
        hi = math.min(intervals[i][1], prev_stop);
		
		 if (lo < hi)# intersection found
		 {
			if(ans!=null && ans.getLast()[1]==lo)# merge intersection with previous intersection if needed
				ans.getLast()[1]==hi;
			else
				ans.add(new interval(lo,hi));
			
			prev=new interval(hi,max(stop,prevstop));# important part taking only the remaining after the intersection
			prev=new interval(hi,max(stop,prevstop));# important part taking only the remaining after the intersection
		 }
		 else
			prev=interval[i];
    return ans

	}
}



 Solution 2---- Here we will try to get both the union and intersection and the same time 
 using the concept of last working end time and last multitask end time
 
 
 
 
    /**
     * The problem we're trying to solve is that although the start-times are sorted, we can't assume that the end-times are sorted too.
     * Fortunately, we don't need to know all the end-times in order, because we don't need to know when concurrency drops from 4 tasks to 3 tasks, or goes up from 5 to 6.
     * All we care about is when concurrency changes between 0, 1 and 2 tasks.
     * That means that as we iterate over the tasks, we only need to keep track of the last end-time we've encountered, and (if we're currently nested) the second-to-last.
     * @param intervals
     */
    void workingMultiTaskingLinear(final List<Interval> intervals) {

        System.out.println("\nworkingMultiTaskingLinear: ");
        Solution result = new Solution();

        /**
         * This will hold a interval i was working
         */
        LinkedList<Interval> working = new LinkedList<>();

        /**
         * This will hold at what interval i was multitasking
         */
        LinkedList<Interval> multiTasking = new LinkedList<>();

        /**
         * This two will just be holding the end time of working and multitasking.
         * AS i've no task right now so its -1
         */
        int lastWorkingEndTime = -1;
        int lastMultiTaskingEndTime = -1;


        for (final Interval interval : intervals) {


            /**
             * 1. Do we have any task right now?  working.isEmpty() : No then take a task and update my endTime
             * 2. Am i doing multitask? Is this new task come before I finished the last task? lastWorkingEndTime < interval.start ; if yes it means i'm multitasking
             */
            if (working.isEmpty() || lastWorkingEndTime < interval.start) {
                working.add(new Interval(interval.start, interval.end));
                lastWorkingEndTime = working.getLast().end;

            } else {

                /**
                 * Since this new task come before i finished the last task?, then i'm multi-tasking for sure
                 */
                if ( lastWorkingEndTime> interval.start ) {

                    /**
                     * 1. Do i have any interval i was multi tasking ? multiTasking.isEmpty(); if not then add the current task as my multi tasking becuase we identify that i'm doing multitask
                     * 2. Is the new task start after my last multi task time ? lastMultiTaskingEndTime < interval.start means i've must started another multi task at different interval
                     */
                    if (multiTasking.isEmpty() || lastMultiTaskingEndTime < interval.start) {
                        //Intersection of intervals

                        int start = interval.start; //Note when i stared the new multi task work
                        int end = Math.min(interval.end, lastWorkingEndTime); //since i'm doing multi tasking, then the end time should be within my last working task (then only i'm doing multi task)

                        multiTasking.add(new Interval(start, end));

                        lastMultiTaskingEndTime = end;


                    } else if (lastMultiTaskingEndTime < interval.end) {

                        //Intersection of intervals
                        int end = Math.min(interval.end, lastWorkingEndTime);


                        multiTasking.getLast().end = end;
                        lastMultiTaskingEndTime = end;
                    }

                }

                //Find till what time i'm doing the task; Union of intervals
                working.getLast().end = Math.max(lastWorkingEndTime, interval.end);
                lastWorkingEndTime = working.getLast().end;
            }
        }


        result.working = working;
        result.multiTasking = multiTasking;

        System.out.println(result);


    }