/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 */

// @lc code=start
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var N = nums.Length;
        // * 快取出現的數字及其所引 (existNum, indexOfNum)
        var existNums = new Dictionary<int, int>();

        // * 遍歷所有數字
        for (var i = 0; i < N; i++)
        {
            // * 取得當前數字 x，並計算其與目標數字的差 y
            var x = nums[i];
            var y = target - x;
            // * 判斷 y 是否已經出現過，若有則取得其索引並回傳答案
            if (existNums.ContainsKey(y))
            {
                var yIndex = existNums[y];
                return [i, yIndex];
            }
            // * 將當前數字加入快取
            existNums[x] = i;
        }
        return [];
    }
}
// @lc code=end
