/*
Given an array of the revenue on each day, and an array of milestones a company wants to reach, return an array containing the days on which the company reached every milestone.
Signature
int[] getMilestoneDays(int[] revenues, int[] milestones)
Input
revenues is a length-N array representing how much revenue company made on each day (from day 1 to day N). milestones is a length-K array of total revenue milestones.
Output
Return a length-K array where K_i is the day on which company first had milestones[i] total revenue. If the milestone is never met, return -1.
Example
revenues = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
milestones = [100, 200, 500]
output = [4, 6, 10]
Explanation
On days 4, 5, and 6, company has total revenue of $100, $150, and $210 respectively. Day 6 is the first time that the compnay has >= $200 of total revenue.

#Here is one solution ( not very efficient though ):
*/

So we have two solutions

n+ mlogn --- Here create a cummulative revenew array and then do binary search for each milestore in that array
(n + m) + (mlongm) sort milestone or make priorityqueue and run a loop over revenew to create a cummulative sum and keep check the PQ

//Using Priority Queue

int[] getMilestoneDays(int[] revenues, int[] milestones) {
    int i=0,j=0;
    PriorityQueue<int[]> pq = new PriorityQueue<>((a,b) -> a[0] - b[0]);
    for(int x : milestones)
    {
      pq.add(new int[]{x,i});
      i++;
    }
    i = 0;
    int n = revenues.length, m = milestones.length;
    int[] res = new int[m];
    int sum =0;
    while(i < n && !pq.isEmpty())
    {
      sum += revenues[i];
      while(!pq.isEmpty() && sum >= pq.peek()[0])
      {
        res[pq.poll()[1]] = i+1;
      }
      i++;
    }
    while(!pq.isEmpty())
    {
      res[pq.poll()[1]] = -1;
    }
    return res;
  }
  
  
  //using binary search
  
  public class MyClass {
    public static void main(String args[]) 
    {
        int[] revenues = new int[]{1,2,3,4,5};
        int[] milestones =new int[]{0,1, 3, 25}; // output 1 1 2 -1
        int[] res=MyClass.getMilestoneDays(revenues,milestones);
        for (int i=0;i<res.length;i++)
            System.out.print(res[i]+" ");


    }
    public static int search(int[] rev, int val) {
    int left = 0, right = rev.length-1;
    while (left < right) {
      int mid = left + (right - left) / 2;
      if (val == rev[mid]) {
        return mid+1;
      }else if (val > rev[mid]) {
        left = mid+1;
      } else {
        right = mid;
      }
    }
    return left+1;
  }

 public static int[] getMilestoneDays(int[] revenues, int[] milestones) {
    int[] res = new int[milestones.length];
    for (int i = 1; i < revenues.length; i++)
      revenues[i] += revenues[i-1];
    for (int i = 0; i < milestones.length; i++) 
    {
      if(milestones[i]>revenues[revenues.length-1])
      {
        res[i]=-1;
        continue;
      }
      res[i] = search(revenues, milestones[i]);
    }
    return res;
  }
}
