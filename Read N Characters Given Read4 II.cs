/*
Description
The API: int read4(char *buf) reads 4 characters at a time from a file.

The return value is the actual number of characters read. For example, it returns 3 if there is only 3 characters left in the file.

By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.
*/


public class Solution extends Reader4 {
    /**
     * @param buf destination buffer
     * @param n maximum number of characters to read
     * @return the number of characters read
     */
	private char[] buf4=new char[4];
	int readpos=0; 				//it defines the position from where we can read from the buf4 i.e from the file
	int writepos=0; 			//this defined the number of char we have to read 
    public int read(char[] buf, int n) 
	{
        for(int i=0;i<n;i++)
		{
			if(readpos==writepos) 	//this mean we have read all the char in the buf4 so need to load more char from file
			{
				writepost=read4(buf4)
				readpos=0;
				if(writepos==0) 	// no more char to read in the file
					return i;		
			}
			buf[i]=buf4[readpos++]; 
		}
		return n;
    }
}