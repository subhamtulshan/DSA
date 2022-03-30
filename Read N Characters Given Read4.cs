/*
Given a file and assume that you can only read the file using a given method read4, implement a method to read_n_characters.
Method read4:
The API read4reads 4 consecutive characters from the file, then writes those characters into the buffer arraybuf.
The return value is the number of actual characters read.
Note that read4()has its own file pointer, much likeFILE *fpin C.
*/


public class Solution extends Reader4 {
    /**
     * @param buf destination buffer
     * @param n maximum number of characters to read
     * @return the number of characters read
     */
	
    public int read(char[] buf, int n) {

    char[] buf4 = new char[4];  //Store our read chars from Read4
    int total = 0;

    while(total < n){
	
        // Read and store characters in Temp. Count will store total chars read from Read4
        int count = read4(temp);

        // Even if we read 4 chars from Read4, we don't want to exceed N and only want to read chars till N.
		//n=18 , we read 4*4 =16 char , next time when we read it will be 20 but we want to real only n(18)-total(16)=2 char only
        count = Math.min(count, n-total);

        // Transfer all the characters read from Read4 to our buffer
        for(int i = 0;  i < count; i++){
            buf[total] = temp[i];
            total++;
        }

        // EOF. Done. We can't read more characters.
        if(count < 4) break;
    }
    return total;
}
}