﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This file is part of the CleanArchitecture.Blazor project.
//     Licensed to the .NET Foundation under the MIT license.
//     See the LICENSE file in the project root for more information.
//
//     Author: neozhu
//     Created Date: 2025-01-06
//     Last Modified: 2025-01-06
//     Description: 
//       Defines a specification for filtering a LookupDetail entity by its ID.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Domain.Entities.Common;

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Specifications;
#nullable disable warnings
/// <summary>
/// Specification class for filtering LookupDetails by their ID.
/// </summary>
public class LookupDetailByIdSpecification : Specification<LookupDetail>
{
    public LookupDetailByIdSpecification(int id)
    {
       Query.Where(q => q.Id == id);
    }
}