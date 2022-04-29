/*
Suppose we have very large sparse vectors (most of the elements in vector are zeros)
Find a data structure to store them
Compute the Dot Product https://leetcode.com/problems/dot-product-of-two-sparse-vectors/ (premium)
Follow-up:
What if one of the vectors is very small?
*/

//Approach 1 : Here we put both the vector into a hashMap and then for the smaller one we search the index in the other 
//if we found then we product them. But the cache here is sometime the hashfunction might not be best because of lot of element or the hashfunction

class SparseVector 
{
	
	HashMap<int,int> data = new HashMap<int,int>();
	
    SparseVector(List<int> nums) {        
        sz = nums.size();
        for (int i = 0; i < nums.size(); ++ i) {
            if (nums[i] != 0) { // store only non-zero elements
                data[i] = nums[i];
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    int dotProduct(SparseVector vec) {
        int s = 0;
        for (int i = 0; i < sz; ++ i) {
            s += data[i] * vec.data[i];
        }
        return s;
    }
};

//Approach 1 : Here we are kindof using a Tuple or a array of pair<index,value> .
//We create it for both the vector and then use two pointer approach where both are pointing to each array and if the index
//match in both then we add the product , else we increment where the index is lower as they can match in future.


class SparseVector {
public:
    
    vector<pair<int, int>> idx_value_pairs;
    
    SparseVector(vector<int> &nums) {
        for (int i = 0; i < nums.size(); i++) {
            if (nums[i] == 0) continue;
            
            idx_value_pairs.push_back({i, nums[i]});
        }
    }
    
    // Return the dotProduct of two sparse vectors
    int dotProduct(SparseVector& vec) {
        int i = 0, j = 0;
        int result = 0;
        
        while (i < idx_value_pairs.size() && j < vec.idx_value_pairs.size()) {
            if (idx_value_pairs[i].first < vec.idx_value_pairs[j].first) {
                i++;
            } else if (idx_value_pairs[i].first > vec.idx_value_pairs[j].first) {
                j++;
            } else {
                result += (idx_value_pairs[i].second * vec.idx_value_pairs[j].second);
                i++;
                j++;
            }
        }
        
        return result;
    }
};
