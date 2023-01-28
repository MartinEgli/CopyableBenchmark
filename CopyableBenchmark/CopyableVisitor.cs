namespace CopyableBenchmark;

public static class CopyableVisitor
{
    public static void CopyContent(object source, object target)
    {
        foreach (var propertyInfo in Helpers.GetPublicProperties(target.GetType()))
        {
                
            var value = propertyInfo.GetValue(source);
            propertyInfo.SetValue(target, value);
                
        }
    }
}