/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 */

// @lc code=start
using System.Text;

public class Solution
{
    public int Reverse(int x)
    {
        // 處理負號
        var isNegative = x < 0;
        if (isNegative)
        {
            x = -x;
        }

        // 反轉數字
        var sb = new StringBuilder();
        while (x > 0)
        {
            var digit = x % 10;

            if (digit == 0 && sb.Length == 0)
            {
                // 前導零不處理
            }
            else
            {
                sb.Append(digit);
            }

            x /= 10;
        }

        // 合併並轉型
        if (int.TryParse(sb.ToString(), out var result))
        {
            return isNegative ? -result : result;
        }
        else // 轉型失敗 (溢位, 2147483648)
        {
            return 0;
        }
    }
}
// @lc code=end

