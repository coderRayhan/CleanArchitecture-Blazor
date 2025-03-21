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
//       Defines a query to export lookup data to an Excel file. This query 
//       applies advanced filtering options and generates an Excel file with 
//       the specified lookup details.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.Lookups.DTOs;
using CleanArchitecture.Blazor.Application.Features.Lookups.Mappers;
using CleanArchitecture.Blazor.Application.Features.Lookups.Caching;
using CleanArchitecture.Blazor.Application.Features.Lookups.Specifications;

namespace CleanArchitecture.Blazor.Application.Features.Lookups.Queries.Export;

public class ExportLookupsQuery : LookupAdvancedFilter, IRequest<Result<byte[]>>
{
      public LookupAdvancedSpecification Specification => new LookupAdvancedSpecification(this);
    public override string ToString()
    {
        return $"Listview:{ListView}:{CurrentUser?.UserId}-{LocalTimezoneOffset.TotalHours}, Search:{Keyword}, {OrderBy}, {SortDirection}";
    }
}
    
public class ExportLookupsQueryHandler :
         IRequestHandler<ExportLookupsQuery, Result<byte[]>>
{
        private readonly IApplicationDbContext _context;
        private readonly IExcelService _excelService;
        private readonly IStringLocalizer<ExportLookupsQueryHandler> _localizer;
        private readonly LookupDto _dto = new();
        public ExportLookupsQueryHandler(
            IApplicationDbContext context,
            IExcelService excelService,
            IStringLocalizer<ExportLookupsQueryHandler> localizer
            )
        {
            _context = context;
            _excelService = excelService;
            _localizer = localizer;
        }
        #nullable disable warnings
        public async Task<Result<byte[]>> Handle(ExportLookupsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Lookups.ApplySpecification(request.Specification)
                       .OrderBy($"{request.OrderBy} {request.SortDirection}")
                       .ProjectTo()
                       .AsNoTracking()
                       .ToListAsync(cancellationToken);
            var result = await _excelService.ExportAsync(data,
                new Dictionary<string, Func<LookupDto, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {_localizer[_dto.GetMemberDescription(x=>x.Code)],item => item.Code}, 
{_localizer[_dto.GetMemberDescription(x=>x.Name)],item => item.Name}, 
{_localizer[_dto.GetMemberDescription(x=>x.NameBN)],item => item.NameBN}, 
{_localizer[_dto.GetMemberDescription(x=>x.ParentId)],item => item.ParentId}, 
{_localizer[_dto.GetMemberDescription(x=>x.IsActive)],item => item.IsActive}, 
{_localizer[_dto.GetMemberDescription(x=>x.DevCode)],item => item.DevCode?.ToString()}, 

                }
                , _localizer[_dto.GetClassDescription()]);
            return await Result<byte[]>.SuccessAsync(result);
        }
}
