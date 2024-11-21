using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace XAML.Toolkits.Core;

/// <summary>
/// <see langword="class"/> analyzer
/// </summary>
public class ClassAnalyzer
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    static ConcurrentDictionary<Type, object> fieldsAttributeMaps = new();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    static ConcurrentDictionary<Type, object> propertiesAttributeMaps = new();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Type type;

    /// <summary>
    ///
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public ClassAnalyzer(Type type)
    {
        this.type = type ?? throw new ArgumentNullException(nameof(type));

        var pubProperties = type.GetProperties(Public | Instance);

        var pubFields = type.GetFields(Public | Instance);

        FieldInfos = new ReadOnlyCollection<FieldInfo>(pubFields);

        Properties = new ReadOnlyCollection<PropertyInfo>(pubProperties);
    }

    /// <summary>
    /// all   fieldInfos
    /// </summary>
    public readonly IReadOnlyList<FieldInfo> FieldInfos;

    /// <summary>
    /// all   property infos
    /// </summary>
    public readonly IReadOnlyList<PropertyInfo> Properties;

    /// <summary>
    /// get <see langword="field"/> <typeparamref name="Attribute"/> <see cref="IDictionary{T, Attr}"/>
    /// </summary>
    /// <typeparam name="Attribute"></typeparam>
    /// <returns></returns>
    public IDictionary<FieldInfo, Attribute> GetFieldAttributes<Attribute>()
        where Attribute : System.Attribute
    {
        if (fieldsAttributeMaps.TryGetValue(type, out var value) && value is ReadOnlyDictionary<FieldInfo, Attribute> target)
        {
            return target;
        }

        lock (fieldsAttributeMaps)
        {
            if (fieldsAttributeMaps.TryGetValue(type, out var value2) && value2 is ReadOnlyDictionary<FieldInfo, Attribute> target2)
            {
                return target2;
            }

            var dict = FieldInfos.ToDictionary(i => i!, i => i.GetCustomAttribute<Attribute>())!;

            fieldsAttributeMaps[type] = target2 = new ReadOnlyDictionary<FieldInfo, Attribute>(dict!);

            return target2;
        }
    }

    /// <summary>
    /// get <see langword="property"/> <typeparamref name="Attribute"/> <see cref="IDictionary{T, Attr}"/>
    /// </summary>
    /// <typeparam name="Attribute"></typeparam>
    /// <returns></returns>
    public IDictionary<PropertyInfo, Attribute> GetPropertyAttributes<Attribute>()
        where Attribute : System.Attribute
    {
        if (propertiesAttributeMaps.TryGetValue(type, out var value) && value is ReadOnlyDictionary<PropertyInfo, Attribute> target)
        {
            return target;
        }

        lock (propertiesAttributeMaps)
        {
            if (propertiesAttributeMaps.TryGetValue(type, out var value2) && value2 is ReadOnlyDictionary<PropertyInfo, Attribute> target2)
            {
                return target2;
            }

            var dict = Properties.ToDictionary(i => i!, i => i.GetCustomAttribute<Attribute>())!;

            propertiesAttributeMaps[type] = target2 = new ReadOnlyDictionary<PropertyInfo, Attribute>(dict!);

            return target2;
        }
    }
}
