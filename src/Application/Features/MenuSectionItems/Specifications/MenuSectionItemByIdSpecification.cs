﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This file is part of the CleanArchitecture.Blazor project.
//     Licensed to the .NET Foundation under the MIT license.
//     See the LICENSE file in the project root for more information.
//
//     Author: neozhu
//     Created Date: 2024-12-09
//     Last Modified: 2024-12-09
//     Description: 
//       Defines a specification for filtering a MenuSectionItem entity by its ID.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Specifications;
#nullable disable warnings
/// <summary>
/// Specification class for filtering MenuSectionItems by their ID.
/// </summary>
public class MenuSectionItemByIdSpecification : Specification<MenuSectionItem>
{
    public MenuSectionItemByIdSpecification(int id)
    {
       Query.Where(q => q.Id == id);
    }
}