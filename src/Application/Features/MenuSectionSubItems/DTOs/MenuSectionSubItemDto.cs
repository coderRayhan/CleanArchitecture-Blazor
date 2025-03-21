﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This file is part of the CleanArchitecture.Blazor project.
//     Licensed to the .NET Foundation under one or more agreements.
//     The .NET Foundation licenses this file to you under the MIT license.
//     See the LICENSE file in the project root for more information.
//
//     Author: neozhu
//     Created Date: 2024-12-11
//     Last Modified: 2024-12-11
//     Description: 
//       This file defines the Data Transfer Object (DTO) for the MenuSectionSubItem entity 
//       used within the CleanArchitecture.Blazor application. The MenuSectionSubItemDto is 
//       responsible for transferring data between layers while maintaining the 
//       structure and format required by application features like commands, queries, 
//       and views.
//     
//     Documentation:
//       https://docs.cleanarchitectureblazor.com/features/menusectionsubitem
// </auto-generated>
//------------------------------------------------------------------------------

// Usage:
// The `MenuSectionSubItemDto` class is used to represent menusectionsubitem data throughout the CleanArchitecture.Blazor
// application, providing a well-defined contract for passing menusectionsubitem information between different 
// layers and services. Each property includes a description for better understandability during 
// serialization and documentation generation.

using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.DTOs;

[Description("MenuSectionSubItems")]
public class MenuSectionSubItemDto
{
    [Description("Id")]
    public int Id { get; set; }
    [Description("Menu section item")]
    public int MenuSectionItemId { get; set; }
    [Description("Title")]
    public string? Title { get; set; }
    [Description("Href")]
    public string? Href { get; set; }
    [Description("Roles")]
    public string[] Roles { get; set; }
    [Description("Page status")]
    public PageStatus PageStatus { get; set; } = PageStatus.Completed;
    [Description("Target")]
    public string? Target { get; set; }
    [Description("Serial Number")]
    public int SerialNo { get; set; }
    [Description("Menu section item")]
    public MenuSectionItemDto MenuSectionItem { get; set; } = new();


}

