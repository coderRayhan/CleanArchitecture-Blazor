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
//       Defines static methods and properties for managing cache keys and expiration 
//       settings for LookupDetail-related data. This includes creating unique cache keys for 
//       various lookupdetail queries (such as getting all lookupdetails, lookupdetails by ID, etc.), 
//       managing the cache expiration tokens to control cache validity, and providing a 
//       mechanism to refresh cached data in a thread-safe manner.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Caching;
/// <summary>
/// Static class for managing cache keys and expiration for LookupDetail-related data.
/// </summary>
public static class LookupDetailCacheKey
{
    public const string GetAllCacheKey = "all-LookupDetails";
    public static string GetPaginationCacheKey(string parameters) {
        return $"LookupDetailCacheKey:LookupDetailsWithPaginationQuery,{parameters}";
    }
    public static string GetExportCacheKey(string parameters) {
        return $"LookupDetailCacheKey:ExportCacheKey,{parameters}";
    }
    public static string GetByNameCacheKey(string parameters) {
        return $"LookupDetailCacheKey:GetByNameCacheKey,{parameters}";
    }
    public static string GetByIdCacheKey(string parameters) {
        return $"LookupDetailCacheKey:GetByIdCacheKey,{parameters}";
    }
    public static IEnumerable<string>? Tags => new string[] { "lookupdetail" };
    public static void Refresh()
    {
        FusionCacheFactory.RemoveByTags(Tags);
    }
}

