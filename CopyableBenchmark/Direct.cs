namespace CopyableBenchmark;

public static class Direct
{
    public static void CopyContent(IClassA source, IClassA target)
    {
        target.Property1 = source.Property1;
        target.Property2 = source.Property2;
    }
}