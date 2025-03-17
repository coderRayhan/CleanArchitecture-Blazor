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
//       Defines a query to retrieve a menusection by its ID. The result is cached 
//       to optimize performance for repeated retrievals of the same menusection.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.MenuSections.DTOs;
using CleanArchitecture.Blazor.Application.Features.MenuSections.Caching;
using CleanArchitecture.Blazor.Application.Features.MenuSections.Mappers;
using CleanArchitecture.Blazor.Application.Features.MenuSections.Specifications;

namespace CleanArchitecture.Blazor.Application.Features.MenuSections.Queries.GetById;

public class GetMenuSectionByIdQuery : IRequest<Result<MenuSectionDto>>
{
   public required int Id { get; set; }
}

public class GetMenuSectionByIdQueryHandler :
     IRequestHandler<GetMenuSectionByIdQuery, Result<MenuSectionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMenuSectionByIdQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<MenuSectionDto>> Handle(GetMenuSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.MenuSections.ApplySpecification(new MenuSectionByIdSpecification(request.Id))
                                                .ProjectTo()
                                                .FirstAsync(cancellationToken);
        return await Result<MenuSectionDto>.SuccessAsync(data);
    }
}
