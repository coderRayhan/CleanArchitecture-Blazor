﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This file is part of the CleanArchitecture.Blazor project.
//     Licensed to the .NET Foundation under the MIT license.
//     See the LICENSE file in the project root for more information.
//
//     Author: neozhu
//     Created Date: 2024-12-11
//     Last Modified: 2024-12-11
//     Description: 
//       Defines the available views for filtering menusectionsubitems and provides advanced 
//       filtering options for menusectionsubitem lists. This includes pagination and various 
//       filters such as view types and user-specific filters.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.Specifications;

#nullable disable warnings
/// <summary>
/// Specifies the different views available for the MenuSectionSubItem list.
/// </summary>
public enum MenuSectionSubItemListView
{
    [Description("All")]
    All,
    [Description("My")]
    My,
    [Description("Created Toady")]
    TODAY,
    [Description("Created within the last 30 days")]
    LAST_30_DAYS
}
/// <summary>
/// A class for applying advanced filtering options to MenuSectionSubItem lists.
/// </summary>
public class MenuSectionSubItemAdvancedFilter: PaginationFilter
{
    public TimeSpan LocalTimezoneOffset { get; set; }
    public MenuSectionSubItemListView ListView { get; set; } = MenuSectionSubItemListView.All;
    public UserProfile? CurrentUser { get; set; }
}