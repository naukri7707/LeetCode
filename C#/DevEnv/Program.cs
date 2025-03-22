using DevEnv;

Console.WriteLine("--- Test your code here! ---");

var sol = new Solution();
var tester = new Tester<(string, string), int>();

tester
    .AddCase(("Hello", "World"), 10)
    .Eval(testCase => sol.SumOfLengths(testCase.Item1, testCase.Item2));

public class Solution
{
    public int SumOfLengths(string text1, string text2)
    {
        return text1.Length + text2.Length;
    }
}
