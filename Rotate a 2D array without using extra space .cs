/*
Given a N x N 2D matrix Arr representing an image. Rotate the image by 90 degrees (anti-clockwise). You need to do this in place. 
Note that if you end up using an additional array, you will only receive partial score.
*/



Solution ---Approach: To solve the question without any extra space, rotate the array in form of squares, dividing the matrix into squares or cycles. 
For example, 
A 4 X 4 matrix will have 2 cycles. The first cycle is formed by its 1st row, last column, last row and 1st column. 
The second cycle is formed by 2nd row, second-last column, second-last row and 2nd column. 
The idea is for each square cycle, swap the elements involved with the corresponding cell in the matrix in anti-clockwise direction
i.e. from top to left, left to bottom, bottom to right and from right to top one at a time using nothing but a temporary variable to achieve this.

First Cycle (Involves Red Elements)
 1  2  3 4 

 5  6  7 8 

 9 10 11 12 

 13 14 15 16 

Moving first group of four elements (First elements of 1st row, last row, 1st column and last column) of first cycle in counter clockwise) 

 4  2  3 16

 5  6  7 8 

 9 10 11 12 

 1 14  15 13 
 
 
 Algo --
There is N/2 squares or cycles in a matrix of side N. Process a square one at a time. 
Run a loop to traverse the matrix a cycle at a time, i.e loop from 0 to N/2 - 1, loop counter is i
Consider elements in group of 4 in current square, rotate the 4 elements at a time. So the number of such groups in a cycle is N - 2*i.
So run a loop in each cycle from x to N - x - 1, loop counter is y
The elements in the current group is (x, y), (y, N-1-x), (N-1-x, N-1-y), (N-1-y, x), 
now rotate the these 4 elements, i.e (x, y) <- (y, N-1-x), (y, N-1-x)<- (N-1-x, N-1-y), (N-1-x, N-1-y)<- (N-1-y, x), (N-1-y, x)<- (x, y)
Print the matrix.


 static void rotateMatrix(int N,
                             int[, ] mat)
    {
        // Consider all
        // squares one by one
        for (int x = 0; x < N / 2; x++) {
            // Consider elements
            // in group of 4 in
            // current square
            for (int y = x; y < N - x - 1; y++) {
                // store current cell
                // in temp variable
                int temp = mat[x, y];

                // move values from
                // right to top
                mat[x, y] = mat[y, N - 1 - x];

                // move values from
                // bottom to right
                mat[y, N - 1 - x] = mat[N - 1 - x,
                                        N - 1 - y];

                // move values from
                // left to bottom
                mat[N - 1 - x,
                    N - 1 - y]
                    = mat[N - 1 - y, x];

                // assign temp to left
                mat[N - 1 - y, x] = temp;
            }
        }
    }
