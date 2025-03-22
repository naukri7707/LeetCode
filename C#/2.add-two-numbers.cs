/*
 * @lc app=leetcode id=2 lang=csharp
 *
 * [2] Add Two Numbers
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // * 建立一個 "假節點" 作為根，方便後續計算
        var dummy = new ListNode();
        // * 將 "假節點" 視為 "前一節點" 使首個節點可以正常計算
        var prev = dummy;
        var carry = 0;
        for (; ; )
        {
            var modify = false;
            var sum = carry;
            // * 若 l1 或 l2 存在時，將其累加至 sum 並標註此輪有異動
            if (l1 != null)
            {
                modify = true;
                sum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                modify = true;
                sum += l2.val;
                l2 = l2.next;
            }

            // * 如果沒有任何異動則跳出迴圈
            if (!modify)
            {
                // * 若還有進位，將其特殊處理
                if (carry == 1)
                {
                    prev.next = new ListNode(1);
                }

                break;
            }

            // * 處理進位
            if (sum > 9)
            {
                sum -= 10;
                carry = 1;
            }
            else
            {
                carry = 0;
            }

            // * 建立 "目前節點" 並將其繫結至 "前一節點"
            var current = new ListNode(sum);
            prev.next = current;

            // * 將 "前一節點" 設為 "目前節點" 供下一輪計算
            prev = current;
        }

        return dummy.next;
    }
}
// @lc code=end
