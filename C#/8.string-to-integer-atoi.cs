/*
 * @lc app=leetcode id=8 lang=csharp
 *
 * [8] String to Integer (atoi)
 */

// @lc code=start
using System.Text;

public class Solution {
    public int MyAtoi(string s) {
        var pointer = 0;

        // 1. 去除前導空白
        while (pointer < s.Length && s[pointer] == ' ')
        {
            pointer++;
        }

        // 2. 處理正負號
        var isNegative = false;
        if (pointer >= s.Length)
        {
            // 空字串、字串全是空白
            return 0;
        }
        else if (s[pointer] == '-')
        {
            isNegative = true;
            pointer++;
        }
        else if (s[pointer] == '+')
        {
            pointer++;
        }
        else
        {
            // 什麼都不做
        }

        // 3. 讀取數字
        var sb = new StringBuilder();
        while (pointer < s.Length && char.IsDigit(s[pointer]))
        {
            sb.Append(s[pointer]);
            pointer++;
        }

        // 4. 合併並轉型
        if(sb.Length == 0)
        {
            // 沒有讀到任何數字
            return 0;
        }
        else if (int.TryParse(sb.ToString(), out var result))
        {
            return isNegative ? -result : result;
        }
        else // 轉型失敗 (超出 int 範圍)
        {
            return isNegative ? int.MinValue : int.MaxValue;
        }
    }
}
// @lc code=end

