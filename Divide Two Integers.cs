Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 
would be truncated to -2.
Return the quotient after dividing dividend by divisor.


Solution: here the though is to think in the perspective of 2^i . So we come from the big number ie 2^31 and then keep reducing i
until we get a number lesss then the divident

3*2^0 + 3*2^1+ 3*2^2 ... 

10/3 --- we get that when i=1 so we subtract 10-3*2^1 =4 and res=2
         again 4-3*2^0=1 and res=2+1=3

class Solution {
    public int divide(int A, int B) {
        if (A == 1 << 31 && B == -1) return (1 << 31) - 1;
        int a = Math.abs(A), b = Math.abs(B), res = 0;
        for (int x = 31; x >= 0; x--)
        {
            System.out.println((a >>> x) +" "+ a +" "+x+" "+b);
            if ((a >>> x) - b >= 0) 
            {
                res += 1 << x;
                a -= b << x;
            }
        }
        return (A > 0) == (B > 0) ? res : -res;
    }
}
