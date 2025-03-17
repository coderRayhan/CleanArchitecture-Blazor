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
//       Defines a query for retrieving lookups with pagination and filtering 
//       options. The result is cached to enhance performance for repeated queries.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.Lookups.DTOs;
using CleanArchitecture.Blazor.Application.Features.Lookups.Caching;
using CleanArchitecture.Blazor.Application.Features.Lookups.Mappers;
using CleanArchitecture.Blazor.Application.Features.Lookups.Specifications;

namespace CleanArchitecture.Blazor.Application.Features.Lookups.Queries.Pagination;

public class LookupsWithPaginationQuery : LookupAdvancedFilter, IRequest<PaginatedData<LookupDto>>
{
    public override string ToString()
    {
        return $"Listview:{ListView}:{CurrentUser?.UserId}-{LocalTimezoneOffset.TotalHours}, Search:{Keyword}, {OrderBy}, {SortDirection}, {PageNumber}, {PageSize}";
    }
    public LookupAdvancedSpecification Specification => new LookupAdvancedSpecification(this);
}

public class LookupsWithPaginationQueryHandler:
         IRequestHandler<LookupsWithPaginationQuery, PaginatedData<LookupDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly ISqlConnectionFactory _sqlConnection;
    public LookupsWithPaginationQueryHandler(
        IApplicationDbContext context, ISqlConnectionFactory sqlConnection)
    {
        _context = context;
        _sqlConnection = sqlConnection;
    }

    public async Task<PaginatedData<LookupDto>> Handle(LookupsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        //var data = await _context.Lookups.OrderBy($"{request.OrderBy} {request.SortDirection}")
        //                                        .ProjectToPaginatedDataAsync(request.Specification,
        //                                                                     request.PageNumber,
        //                                                                     request.PageSize,
        //                                                                     LookupMapper.ToDto,
        //                                                                     cancellationToken);
        //return data;

        var connection = _sqlConnection.GetOpenConnection();
        var sql = $"""
            SELECT
                l.Id AS {nameof(LookupDto.Id)},
                l.Name AS {nameof(LookupDto.Name)},
                l.NameBN AS {nameof(LookupDto.NameBN)},
                l.Code AS {nameof(LookupDto.Code)},
                l.ParentId AS {nameof(LookupDto.ParentId)},
                p.Name AS {nameof(LookupDto.ParentName)},
                l.IsActive {nameof(LookupDto.IsActive)},
                IIF(l.IsActive = 1, 'Active', 'Inactive') AS {nameof(LookupDto.StatusName)},
                CONVERT(DATE, l.Created) AS {nameof(LookupDto.Created)}
            FROM dbo.Lookups AS l
            LEFT JOIN dbo.Lookups AS p ON p.Id = l.ParentId
            """;

        return await PaginatedData<LookupDto>
            .CreateAsync(connection, sql, request, cancellationToken);
    }
}