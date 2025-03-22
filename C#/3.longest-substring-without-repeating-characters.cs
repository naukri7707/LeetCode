/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 */

// @lc code=start
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        // * 特殊處理字串長度小於 1 導致演算法無法計算的情況
        if (s.Length <= 1)
        {
            return s.Length;
        }

        // 最後出現過的字元及其索引 existChar, existIdx
        var exist = new Dictionary<char, int>
        {
            // 將首個字元直接加入字典，讓後續判斷有個基本依據可以參照
            [s[0]] = 0
        };
        // subString 開始的索引
        var startIdx = 0;
        // 最大 subString 長度
        var maxLength = 1;

        // * 遍歷字串，因為第 1 個字元已經特殊處理過了，所以從第 2 個字元開始
        for (int i = 1; i < s.Length; i++)
        {
            char c = s[i];

            // * 若該字元已經出現過
            if (exist.TryGetValue(c, out var existIdx))
            {
                // * 判斷該 "出現過的字元" 是否已脫離當前判斷的子字串區間
                // 若是則忽略，否則調整子字串起點並嘗試更新最佳紀錄
                var isThrowen = existIdx < startIdx;

                // * 當還在子字串內
                if (!isThrowen)
                {
                    // * 計算長度並嘗試刷新最佳紀錄
                    var length = i - startIdx;
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }

                    // * 將判斷的起始點改為 +1
                    // 例如 "abca..." 的情況，當在計算到第二個 a 時我們後續可能出現的最長不重複子字串只可能是
                    // "bca..." 所以將 index + 1
                    startIdx = existIdx + 1;
                }
            }

            // * 將出現過的字元加入進字典並記錄 (或更新) 其索引
            exist[c] = i;
        }

        // * 處理最後沒有判斷的情況
        var lastLength = s.Length - startIdx;
        if (lastLength > maxLength)
        {
            maxLength = lastLength;
        }

        return maxLength;
    }
}
// @lc code=end
