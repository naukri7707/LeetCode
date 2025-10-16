/*
 * @lc app=leetcode id=6 lang=csharp
 *
 * [6] Zigzag Conversion
 */

// @lc code=start
public class Solution
{
    // src: 
    // ABCDEFGHIJ
    // converted:
    // A     G
    // B   F H
    // C E   I
    // D     J
    // 假如轉換字串為 ｜／｜／｜／｜／
    // 將一組 ｜／ 視為一個 step (A~F)
    // - 每個 row 在｜都會有一個元素、除了第一和最後，每個 row 在／都會有一個元素
    // numRows step
    // 1       1
    // 2       2
    // 3       3+1
    // 4       4+2
    // 5       5+3
    // - 可推算出每個 step 會有 numRows + Max(numRows - 2, 0) 
    public string Convert(string s, int numRows)
    {
        var convertedSb = new StringBuilder();

        for (int row = 0; row < numRows; row++)
        {
            var step = numRows + Math.Max(numRows - 2, 0);

            if (row == 0 || row == numRows - 1)
            {
                for (int i = 0; i < s.Length; i += step)
                {
                    if (!TryGetChar(s, i + row, out var c))
                    {
                        continue;
                    }
                    convertedSb.Append(c);
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i += step)
                {
                    if (!TryGetChar(s, i + row, out var c))
                    {
                        continue;
                    }
                    convertedSb.Append(c);

                    // 推算該 step 的鏈條在 row 的位置
                    if (!TryGetChar(s, i + step - row, out var z))
                    {
                        continue;
                    }
                    convertedSb.Append(z);
                }
            }
        }

        return convertedSb.ToString();
    }

    private bool TryGetChar(string src, int index, out char c)
    {
        if (index < 0 || index >= src.Length)
        {
            c = default;
            return false;
        }

        c = src[index];
        return true;
    }
}
// @lc code=end

