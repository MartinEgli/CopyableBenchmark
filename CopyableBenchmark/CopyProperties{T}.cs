using System.Linq.Expressions;

namespace CopyableBenchmark;

public class CopyProperties<T>
{
    private Action<T, T> _copy;

    public Action<T, T> Action => _copy;

    public void Initialize()
    {
        var sourceType = typeof(T);
        var attributeType = typeof(CopyableAttribute);
        var source = Expression.Parameter(sourceType);
        var target = Expression.Parameter(sourceType);
        var properties = Helpers.GetPublicProperties(sourceType); //.GetProperties();
        var copyables = properties.Where(prop => Attribute.IsDefined(prop, attributeType));

        var expressions = new List<Expression>();
        foreach (var prop in copyables)
        {
            if (!prop.CanRead || !prop.CanWrite)
            {
                continue;
            }

            var getMethod = prop.GetGetMethod();
            if (getMethod == null)
            {
                continue;
            }

            var getCaller = Expression.Call(source, getMethod);
            var setMethod = prop.GetSetMethod();
            if (setMethod == null)
            {
                continue;
            }

            var copyCaller = Expression.Call(target, setMethod, getCaller);
            expressions.Add(copyCaller);
        }

        var body = Expression.Block(expressions);
        _copy = Expression.Lambda<Action<T, T>>(body, source, target).Compile();
    }

    public void CopyFrom(T source, T target)
    {
        _copy(source, target);
    }
}