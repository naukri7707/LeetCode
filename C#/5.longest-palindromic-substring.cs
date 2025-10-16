/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        var longestLength = 0;
        var longestLeftIndex = 0;
        var longestRightIndex = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // rightOffset = 0 為基數迴文 e.g. "cabac"
            // rightOffset = 1 為偶數迴文 e.g. "cabbac"
            // 由於存在類似 "aaaaa" 這種情況所以不能用 s[i] == s[i+1] 剪枝，否則在這個 case 會得到 "aaaa"
            for (var rightOffset = 0; rightOffset < 2; rightOffset++)
            {
                var leftIndex = i;
                var rightIndex = i + rightOffset;

                // 判斷左右起始字元是否不同或溢位
                if (!TryGetChar(s, leftIndex, rightIndex, out char startLeft, out char startRight) || startLeft != startRight)
                {
                    continue;
                }

                // 擴張子字串
                while (TryGetChar(s, leftIndex - 1, rightIndex + 1, out char left, out char right) && left == right)
                {
                    leftIndex--;
                    rightIndex++;
                }

                // 更新最佳匹配
                var length = rightIndex - leftIndex + 1;
                if (length > longestLength)
                {
                    longestLength = length;
                    longestLeftIndex = leftIndex;
                    longestRightIndex = rightIndex;
                }
            }
        }

        // 回傳最佳子字串
        return s.Substring(longestLeftIndex, longestLength);
    }

    private bool TryGetChar(string src, int leftIndex, int rightIndex, out char left, out char right)
    {
        if (leftIndex < 0 || rightIndex >= src.Length)
        {
            left = default;
            right = default;
            return false;
        }

        left = src[leftIndex];
        right = src[rightIndex];
        return true;
    }
}
// @lc code=end

