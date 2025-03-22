/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var numCount = nums1.Length + nums2.Length;
        var largeMedianIndex = numCount / 2;
        var smallMedianIndex = numCount % 2 == 0 ? largeMedianIndex - 1 : largeMedianIndex;
        var pointer1 = 0;
        var pointer2 = 0;

        int GetNext()
        {
            if (pointer1 < nums1.Length)
            {
                // * 都在範圍內
                if (pointer2 < nums2.Length)
                {
                    var num1 = nums1[pointer1];
                    var num2 = nums2[pointer2];
                    // 比較並取出較小的元素
                    if (num1 < num2)
                    {
                        pointer1++;
                        return num1;
                    }
                    else
                    {
                        pointer2++;
                        return num2;
                    }
                }
                // * pointer2 脫離範圍
                else
                {
                    // 取出 nums1
                    return nums1[pointer1++];
                }
            }
            else
            {
                // * pointer1 脫離範圍
                if (pointer2 < nums2.Length)
                {
                    // 取出 nums2
                    return nums2[pointer2++];
                }
                // * 都在範圍外
                else
                {
                    throw null;
                }
            }
        }

        for (var i = 0; i < smallMedianIndex; i++)
        {
            _ = GetNext();
        }

        var ans = (smallMedianIndex == largeMedianIndex) switch
        {
            true => GetNext(),
            false => (GetNext() + GetNext()) / 2.0,
        };

        return ans;
    }
}
// @lc code=end
