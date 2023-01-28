namespace CopyableBenchmark;

public class CopyableVisitor2
{
    public CopyableVisitor2(object source, object target)
    {
        foreach (var propertyInfo in Helpers.GetPublicProperties(target.GetType()))
        {

            var value = propertyInfo.GetValue(source);
            propertyInfo.SetValue(target, value);

        }
    }
}