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
//       Defines a query to export menusectionitem data to an Excel file. This query 
//       applies advanced filtering options and generates an Excel file with 
//       the specified menusectionitem details.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.DTOs;
using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Mappers;
using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Caching;
using CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Specifications;

namespace CleanArchitecture.Blazor.Application.Features.MenuSectionItems.Queries.Export;

public class ExportMenuSectionItemsQuery : MenuSectionItemAdvancedFilter, IRequest<Result<byte[]>>
{
      public MenuSectionItemAdvancedSpecification Specification => new MenuSectionItemAdvancedSpecification(this);
      public IEnumerable<string>? Tags => MenuSectionItemCacheKey.Tags;
    public override string ToString()
    {
        return $"Listview:{ListView}:{CurrentUser?.UserId}-{LocalTimezoneOffset.TotalHours}, Search:{Keyword}, {OrderBy}, {SortDirection}";
    }
    public string CacheKey => MenuSectionItemCacheKey.GetExportCacheKey($"{this}");
}
    
public class ExportMenuSectionItemsQueryHandler :
         IRequestHandler<ExportMenuSectionItemsQuery, Result<byte[]>>
{
        private readonly IApplicationDbContext _context;
        private readonly IExcelService _excelService;
        private readonly IStringLocalizer<ExportMenuSectionItemsQueryHandler> _localizer;
        private readonly MenuSectionItemDto _dto = new();
        public ExportMenuSectionItemsQueryHandler(
            IApplicationDbContext context,
            IExcelService excelService,
            IStringLocalizer<ExportMenuSectionItemsQueryHandler> localizer
            )
        {
            _context = context;
            _excelService = excelService;
            _localizer = localizer;
        }
        #nullable disable warnings
        public async Task<Result<byte[]>> Handle(ExportMenuSectionItemsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.MenuSectionItems.ApplySpecification(request.Specification)
                       .OrderBy($"{request.OrderBy} {request.SortDirection}")
                       .ProjectTo()
                       .AsNoTracking()
                       .ToListAsync(cancellationToken);
            var result = await _excelService.ExportAsync(data,
                new Dictionary<string, Func<MenuSectionItemDto, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {_localizer[_dto.GetMemberDescription(x=>x.MenuSectionId)],item => item.MenuSectionId}, 
{_localizer[_dto.GetMemberDescription(x=>x.Title)],item => item.Title}, 
{_localizer[_dto.GetMemberDescription(x=>x.Icon)],item => item.Icon}, 
{_localizer[_dto.GetMemberDescription(x=>x.Href)],item => item.Href}, 
{_localizer[_dto.GetMemberDescription(x=>x.Target)],item => item.Target}, 
{_localizer[_dto.GetMemberDescription(x=>x.PageStatus)],item => item.PageStatus.ToString()}, 
{_localizer[_dto.GetMemberDescription(x=>x.IsParent)],item => item.IsParent}, 

                }
                , _localizer[_dto.GetClassDescription()]);
            return await Result<byte[]>.SuccessAsync(result);
        }
}
