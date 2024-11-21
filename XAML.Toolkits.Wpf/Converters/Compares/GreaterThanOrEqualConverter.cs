using System.Windows;

namespace XAML.Toolkits.Wpf;

/// <summary>
/// a class of <see cref="GreaterThanOrEqualConverter"/>
/// </summary>
/// <seealso cref="CompareConverter" />
public class GreaterThanOrEqualConverter : CompareConverter
{
    /// <summary>
    /// create a new instance of <see cref="GreaterThanOrEqualConverter"/>
    /// </summary>
    public GreaterThanOrEqualConverter()
        : base(CompareMode.GreaterThanOrEqual) { }
}
