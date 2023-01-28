using System.Reflection;

namespace CopyableBenchmark;

class Helpers
{
    public static PropertyInfo[] GetPublicProperties(Type type)
    {
        var propertyInfos = new List<PropertyInfo>();
        var considered = new List<Type>();
        var queue = new Queue<Type>();
        considered.Add(type);
        queue.Enqueue(type);
        while (queue.Count > 0)
        {
            var subType = queue.Dequeue();
            foreach (var subInterface in subType.GetInterfaces())
            {
                if (considered.Contains(subInterface)) continue;
                considered.Add(subInterface);
                queue.Enqueue(subInterface);
            }

            var typeProperties = subType.GetProperties(
                BindingFlags.FlattenHierarchy
                | BindingFlags.Public
                | BindingFlags.Instance);
            var newPropertyInfos = typeProperties
                .Where(x => !propertyInfos.Contains(x));
            propertyInfos.InsertRange(0, typeProperties);
        }

        return propertyInfos.ToArray();
    }

    public static IEnumerable<T> GetCustomAttributesIncludingBaseInterfaces<T>(PropertyInfo info)
    {
        var attributeType = typeof(T);
        return info.GetCustomAttributes(attributeType, true)
            .Union(info.GetType().GetInterfaces().SelectMany(interfaceType =>
                interfaceType.GetCustomAttributes(attributeType, true)))
            .Cast<T>();
    }

    public static PropertyInfo[] GetPublicProperties2(Type type)
    {
        if (type.IsInterface)
        {
            var propertyInfos = new List<PropertyInfo>();

            var considered = new List<Type>();
            var queue = new Queue<Type>();
            considered.Add(type);
            queue.Enqueue(type);
            while (queue.Count > 0)
            {
                var subType = queue.Dequeue();
                foreach (var subInterface in subType.GetInterfaces())
                {
                    if (considered.Contains(subInterface)) continue;

                    considered.Add(subInterface);
                    queue.Enqueue(subInterface);
                }

                var typeProperties = subType.GetProperties(
                    BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.Instance);

                var newPropertyInfos = typeProperties
                    .Where(x => !propertyInfos.Contains(x));

                propertyInfos.InsertRange(0, typeProperties);
            }

            return propertyInfos.ToArray();
        }

        return type.GetProperties(BindingFlags.FlattenHierarchy
                                  | BindingFlags.Public | BindingFlags.Instance);
    }
}