/*
Given an unsorted array of integers, sort the array into a wave like array. An array ‘arr[0..n-1]’ is sorted in wave form if arr[0] <= arr[1] => arr[2] <= arr[3] => arr[4] <= …..
*/

public static void WiggleSort(int [] arr)
{
	for(int i=0;i<arr.Length-1;i++)
	{
		if(i%2==0)
		{
			if(arr[i]>arr[i+1])
			{
				swap(arr,i,i+1);
			}
		}
		else
		{
			if(&& arr[i]<arr[i+1])
			{
				swap(arr,i,i+1);

			}
		}
	}
}
public static swap(int[] arr,int a,int b)
{
	int temp=arr[a];
	arr[a]=arr[b];
	arr[b]=temp;
}
