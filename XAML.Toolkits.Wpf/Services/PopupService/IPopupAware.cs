﻿using System.ComponentModel;

namespace XAML.Toolkits.Wpf;

/// <summary>
///  an <see langword="interface"/> of <see cref="IPopupAware"/>
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IPopupAware
{
    /// <summary>
    /// popup opened
    /// </summary>
    /// <param name="parameter"></param>
    void Opened(PopupParameter? parameter);

    /// <summary>
    /// popup closed
    /// </summary>
    void Closed();

    /// <summary>
    /// request close <see langword="event"/>
    /// </summary>

    event Action<object>? RequestCloseEvent;
}
