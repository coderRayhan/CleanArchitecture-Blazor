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
//       Defines a query to retrieve all menusectionitems from the database. The result 
//       is cached to improve performance and reduce database load for repeated 
//       queries.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.DTOs;
using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Mappers;
using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Caching;

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Queries.GetAll;

public class GetAllMenuSectionItemsQuery : IRequest<IEnumerable<MenuSectionItemDto>>
{
   public string CacheKey => MenuSectionItemCacheKey.GetAllCacheKey;
   public IEnumerable<string>? Tags => MenuSectionItemCacheKey.Tags;
}

public class GetAllMenuSectionItemsQueryHandler :
     IRequestHandler<GetAllMenuSectionItemsQuery, IEnumerable<MenuSectionItemDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllMenuSectionItemsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuSectionItemDto>> Handle(GetAllMenuSectionItemsQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.MenuSectionItems.ProjectTo()
                                                .AsNoTracking()
                                                .ToListAsync(cancellationToken);
        return data;
    }
}


