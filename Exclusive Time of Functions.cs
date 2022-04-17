This time we are executing a program containing ‘N’ functions on a single-threaded CPU. Each function has a unique ‘ID’ between 0 and (N-1) 
and each time it starts or ends, we write a log with the ID, whether it started or ended, and the TIMESTAMP.You are given a 2D array of integers 
containing information about ‘L’ logs where ith column represents the ith log message. Each column contains 3 rows to describe the ith log where

Input: n = 2, logs = ["0:start:0","1:start:2","1:end:5","0:end:6"]
Output: [3,4]
Explanation:
Function 0 starts at the beginning of time 0, then it executes 2 for units of time and reaches the end of time 1.
Function 1 starts at the beginning of time 2, executes for 4 units of time, and ends at the end of time 5.
Function 0 resumes execution at the beginning of time 6 and executes for 1 unit of time.
So function 0 spends 2 + 1 = 3 units of total time executing, and function 1 spends 4 units of total time executing.


Solution --- Here the idea is to use a stack and for each function we calculate its excution time and then notify the parent that for this amount of duration I have 
run so dont include in your time. To do this we use a stack , whenever its a start we push it to stack , and for end we pop and then calculate the duration and 
add this duration to the childexecutiontime of parent.

keep in mind if a function s1 starts after s2 then s1 has to end before thing of normal funtion call stack. s2 calls s1 so s1 has to end before s2

class Solution {
    public int[] exclusiveTime(int n, List<String> logs) {
        Deque<Log> stack = new ArrayDeque<>();
        int[] result = new int[n];
        int duration = 0;
        for (String content : logs) {
            Log log = new Log(content);
            if (log.isStart) {
                stack.push(log);
            } else {
                Log top = stack.pop();
                result[top.id] += (log.time - top.time + 1 - top.subDuration);
                if (!stack.isEmpty()) {
                    stack.peek().subDuration += (log.time - top.time + 1);
                }
            }
        }
        
        return result;
    }
    
    public static class Log {
        public int id;
        public boolean isStart;
        public int time;
        public int subDuration; // for any func this is the duration its childs has executed
        
        public Log(String content) {
            String[] strs = content.split(":");
            id = Integer.valueOf(strs[0]);
            isStart = strs[1].equals("start");
            time = Integer.valueOf(strs[2]);
            subDuration = 0;
        }
    }
}
