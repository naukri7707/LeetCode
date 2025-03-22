namespace DevEnv;

public class Tester<TCase, TAnswer>
    where TAnswer : IEquatable<TAnswer>
{
    protected event Func<int, string> AC;

    protected event Func<int, TCase, TAnswer, TAnswer, string> WA;

    public Tester(
        Func<int, string>? ac = null,
        Func<int, TCase, TAnswer, TAnswer, string>? wa = null
    )
    {
        AC = ac ?? (caseCount => $"[AC] completed all {caseCount} cases!");
        WA =
            wa
            ?? (
                (caseNum, testCase, answer, result) =>
                    $"[WA] Case {caseNum}: \"{FormatHelper.ToString(testCase)}\" expect {answer} but got {result}."
            );
    }

    private readonly List<(TCase testCase, TAnswer answer)> _tasks = [];

    public Tester<TCase, TAnswer> AddCase(TCase testCase, TAnswer answer)
    {
        _tasks.Add((testCase, answer));
        return this;
    }

    public Tester<TCase, TAnswer> AddCases(
        params IEnumerable<(TCase testCase, TAnswer answer)> tasks
    )
    {
        _tasks.AddRange(tasks);
        return this;
    }

    public void Eval(Func<TCase, TAnswer> func)
    {
        var waCount = 0;
        var caseIndex = -1;
        foreach (var (testCase, answer) in _tasks)
        {
            caseIndex++;
            var res = func(testCase);

            if (!Equals(res, answer))
            {
                waCount++;
                var waMessage = WA.Invoke(caseIndex, testCase, answer, res);
                Console.WriteLine(waMessage);
            }
        }
        if (waCount == 0)
        {
            var acMessage = AC.Invoke(caseIndex + 1);
            Console.WriteLine(acMessage);
        }
    }
}
