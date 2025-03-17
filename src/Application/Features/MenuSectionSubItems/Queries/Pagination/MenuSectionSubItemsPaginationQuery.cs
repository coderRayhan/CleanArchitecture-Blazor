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
//       Defines a query for retrieving menusectionsubitems with pagination and filtering 
//       options. The result is cached to enhance performance for repeated queries.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.DTOs;
using CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.Mappers;
using CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.Specifications;

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionSubItems.Queries.Pagination;

public class MenuSectionSubItemsWithPaginationQuery : MenuSectionSubItemAdvancedFilter, IRequest<PaginatedData<MenuSectionSubItemDto>>
{
    public override string ToString()
    {
        return $"Listview:{ListView}:{CurrentUser?.UserId}-{LocalTimezoneOffset.TotalHours}, Search:{Keyword}, {OrderBy}, {SortDirection}, {PageNumber}, {PageSize}";
    }
    public MenuSectionSubItemAdvancedSpecification Specification => new MenuSectionSubItemAdvancedSpecification(this);
}
    
public class MenuSectionSubItemsWithPaginationQueryHandler :
         IRequestHandler<MenuSectionSubItemsWithPaginationQuery, PaginatedData<MenuSectionSubItemDto>>
{
        private readonly IApplicationDbContext _context;

        public MenuSectionSubItemsWithPaginationQueryHandler(
            IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedData<MenuSectionSubItemDto>> Handle(MenuSectionSubItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
           var data = await _context.MenuSectionSubItems.Include(x => x.MenuSectionItem).ThenInclude(x => x.MenuSection).OrderBy($"{request.OrderBy} {request.SortDirection}")
                                                   .ProjectToPaginatedDataAsync(request.Specification, 
                                                                                request.PageNumber, 
                                                                                request.PageSize, 
                                                                                MenuSectionSubItemMapper.ToDto, 
                                                                                cancellationToken);
            return data;
        }
}