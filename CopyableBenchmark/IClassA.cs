namespace CopyableBenchmark;

public interface IClassA : IClassB
{
    [Copyable] public int Property2 { get; set; }
    public int Property3 { get; set; }
}