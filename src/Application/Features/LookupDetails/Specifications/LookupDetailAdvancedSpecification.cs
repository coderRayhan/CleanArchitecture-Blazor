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
//       Defines a specification for applying advanced filtering options to the 
//       LookupDetail entity, supporting different views and keyword-based searches.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Domain.Entities.Common;

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Specifications;
#nullable disable warnings
/// <summary>
/// Specification class for advanced filtering of LookupDetails.
/// </summary>
public class LookupDetailAdvancedSpecification : Specification<LookupDetail>
{
    public string StringSpecification { get; set; }
    public LookupDetailAdvancedSpecification(LookupDetailAdvancedFilter filter)
    {
        DateTime today = DateTime.UtcNow;
        var todayrange = today.GetDateRange(LookupDetailListView.TODAY.ToString(), filter.LocalTimezoneOffset);
        var last30daysrange = today.GetDateRange(LookupDetailListView.LAST_30_DAYS.ToString(),filter.LocalTimezoneOffset);

        Query.Where(q => q.Name != null)
             .Where(filter.Keyword,!string.IsNullOrEmpty(filter.Keyword))
             .Where(q => q.CreatedBy == filter.CurrentUser.UserId, filter.ListView == LookupDetailListView.My && filter.CurrentUser is not null)
             .Where(x => x.Created >= todayrange.Start && x.Created < todayrange.End.AddDays(1), filter.ListView == LookupDetailListView.TODAY)
             .Where(x => x.Created >= last30daysrange.Start, filter.ListView == LookupDetailListView.LAST_30_DAYS);

        StringSpecification = this.WhereExpressions.ToString();
       
    }
}
