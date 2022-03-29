/*
Problem: 
We are given a list schedule of employees, which represents the working time for each employee.

Each employee has a list of non-overlapping Intervals, and these intervals are in sorted order.

Return the list of finite intervals representing common, positive-length free time for all employees, also in sorted order.
*/


// Solution 1: Here the idea is to collab all the intervals sort then and then find the non overlapping index

/**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */
class Solution {
    public List<Interval> employeeFreeTime(List<List<Interval>> avails) {
        List<Interval> result = new ArrayList<>();
        List<Interval> timeLine = new ArrayList<>();
        avails.forEach(e -> timeLine.addAll(e));
        Collections.sort(timeLine, ((a, b) -> a.start - b.start));

        Interval temp = timeLine.get(0);
        for (Interval each : timeLine) {
            if (temp.end < each.start) {
                result.add(new Interval(temp.end, each.start));
                temp = each;
            } else {
                temp = temp.end < each.end ? each : temp;
            }
        }
        return result;
    }
}
O(ClogC) -- c is the total number of interval given

/*Solution 2: Here the idea is to use a min Heap that will store the employee who has minimum start time.
Say we are at some time where no employee is working. That work-free period will last until the next time some employee has to work.
 
We take the first interval of each employee and insert it in a Min Heap. This Min Heap can always give us the interval with the smallest start time. Once we have the smallest start-time interval,

Whenever we take an interval out of the Min Heap, we can insert the next interval of the same employee. This also means that we need to know which interval belongs to which employee.
*/


/**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */
class Solution {
    public List<Interval> employeeFreeTime(List<List<Interval>> avails) {
        List<Interval> result = new ArrayList();
		//define a prioity queue that will keep the index of emp and their intervalindex in startTime sorted
        PriorityQueue<EmployeeInterval> heap = new PriorityQueue<EmployeeInterval>((a, b) ->
            avails.get(a.employeeIndex).get(a.intervalIndex).start -
            avails.get(b.employeeIndex).get(b.intervalIndex).start);
        int ei = 0, time =1; // this is the minimum time for any interval to handle when we have all time starting at 2 else use intmax here
		
	// We store all the emp first index and also keep track of the mim time where none of emp had any work	
     for (List<Interval> employee: avails) {
            heap.offer(new EmployeeInterval(ei++, 0));
            time = Math.min(time, employee.get(0).start);
        }
		
	//Here we keep polling from queue and check the mim start time from heap if there is gap then we have a result and then go for the next index
      while (!heap.isEmpty()) {
            EmployeeInterval job = heap.poll();
            Interval iv = avails.get(job.employeeIndex).get(job.intervalIndex);
            if (time < iv.start)
                result.add(new Interval(time, iv.start));
            time = Math.max(time, iv.end);
            if (++job.intervalIndex < avails.get(job.employeeIndex).size())
                heap.offer(job);
        }
        return result;
    }
}
class EmployeeInterval{
    
    // index of the list containing working hours of this employee    
    // index of the interval in the employee list 
    
    int employeeIndex, intervalIndex; 
    
    EmployeeInterval(int e, int i) {
        employeeIndex = e;
        intervalIndex = i;
    }
}