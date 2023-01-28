using BenchmarkDotNet.Attributes;

namespace CopyableBenchmark;

public class Benchmark
{
    private int _count = 100000;
    private readonly IClassA origin = new ClassA() { Property1 = 1, Property2 = 2, Property3 = 3 };
    private readonly CopyProperties<IClassA> _manager;

    public Benchmark()
    {
        _manager = new CopyProperties<IClassA>();
        _manager.Initialize();
    }

    [Benchmark]
    public IList<IClassA> TestExpression()
    {
        var manager = new CopyProperties<IClassA>();
        manager.Initialize();
        var list = new List<IClassA>(_count);
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            manager.CopyFrom(origin, c2);
            list.Add(c2);
        }

        return list;
    }

    [Benchmark]
    public IList<IClassA> TestReflection()
    {
        var list = new List<IClassA>(_count);
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            CopyableVisitor.CopyContent(origin, c2);
            list.Add(c2);
        }

        return list;
    }

    [Benchmark]
    public IList<IClassA> TestReflection2()
    {
        var list = new List<IClassA>(_count);
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            new CopyableVisitor2(origin, c2);
            list.Add(c2);
        }

        return list;
    }

    [Benchmark]
    public IList<IClassA> TestExpression2()
    {
        var list = new List<IClassA>(_count);
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            _manager.CopyFrom(origin, c2);
            list.Add(c2);
        }

        return list;
    }

    [Benchmark]
    public IList<IClassA> TestExpression3()
    {
        var list = new List<IClassA>(_count);
        var action = _manager.Action;
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            action(origin, c2);
            list.Add(c2);
        }

        return list;
    }

    [Benchmark(Baseline = true)]
    public IList<IClassA> TestDirect()
    {
        var list = new List<IClassA>(_count);
        for (var i = 0; i < _count; i++)
        {
            var c2 = new ClassA();
            Direct.CopyContent(origin, c2);
            list.Add(c2);
        }

        return list;
    }
}