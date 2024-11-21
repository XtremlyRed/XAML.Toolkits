﻿using System.Windows;

namespace XAML.Toolkits.Wpf;

/// <summary>
/// a class of <see cref="EqualConverter"/>
/// </summary>
/// <seealso cref="CompareConverter" />
public class EqualConverter : CompareConverter
{
    /// <summary>
    /// create a new instance of <see cref="EqualConverter"/>
    /// </summary>
    public EqualConverter()
        : base(CompareMode.Equal) { }
}

/// <summary>
/// a class of <see cref="EqualToVisitilityConverter"/>
/// </summary>
/// <seealso cref="EqualToVisitilityConverter" />
public class EqualToVisitilityConverter : CompareConverter
{
    /// <summary>
    /// create a new instance of <see cref="EqualConverter"/>
    /// </summary>
    public EqualToVisitilityConverter()
        : base(CompareMode.Equal)
    {
        True = Visibility.Visible;
        False = Visibility.Collapsed;
    }
}
