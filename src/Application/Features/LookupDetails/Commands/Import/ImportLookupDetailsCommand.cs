﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This file is part of the CleanArchitecture.Blazor project.
//     Licensed to the .NET Foundation under one or more agreements.
//     The .NET Foundation licenses this file to you under the MIT license.
//     See the LICENSE file in the project root for more information.
//
//     Author: neozhu
//     Created Date: 2025-01-06
//     Last Modified: 2025-01-06
//     Description: 
//       This file defines the command, handler, and associated logic for importing 
//       lookupdetails from an Excel file into the CleanArchitecture.Blazor application. 
//       The import process supports validating data and ensuring no duplicates are 
//       inserted. Additionally, a command for creating a lookupdetail template file is provided 
//       to facilitate bulk data entry for end users.
//     
//     Documentation:
//       https://docs.cleanarchitectureblazor.com/features/lookupdetail
// </auto-generated>
//------------------------------------------------------------------------------

// Usage:
// - Use `ImportLookupDetailsCommand` to import lookupdetails from an Excel file, ensuring proper validation
//   and avoiding duplicates.
// - Use `CreateLookupDetailsTemplateCommand` to generate an Excel template for entering lookupdetail data 
//   that can be later imported using the import command.

using CleanArchitecture.Blazor.Application.Features.LookupDetails.DTOs;
using CleanArchitecture.Blazor.Application.Features.LookupDetails.Caching;
using CleanArchitecture.Blazor.Application.Features.LookupDetails.Mappers;

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Commands.Import;

    public class ImportLookupDetailsCommand: IRequest<Result<int>>
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public ImportLookupDetailsCommand(string fileName,byte[] data)
        {
           FileName = fileName;
           Data = data;
        }
    }
    public record class CreateLookupDetailsTemplateCommand : IRequest<Result<byte[]>>
    {
 
    }

    public class ImportLookupDetailsCommandHandler : 
                 IRequestHandler<CreateLookupDetailsTemplateCommand, Result<byte[]>>,
                 IRequestHandler<ImportLookupDetailsCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStringLocalizer<ImportLookupDetailsCommandHandler> _localizer;
        private readonly IExcelService _excelService;
        private readonly LookupDetailDto _dto = new();

        public ImportLookupDetailsCommandHandler(
            IApplicationDbContext context,
            IExcelService excelService,
            IStringLocalizer<ImportLookupDetailsCommandHandler> localizer)
        {
            _context = context;
            _localizer = localizer;
            _excelService = excelService;
        }
        #nullable disable warnings
        public async Task<Result<int>> Handle(ImportLookupDetailsCommand request, CancellationToken cancellationToken)
        {

           var result = await _excelService.ImportAsync(request.Data, mappers: new Dictionary<string, Func<DataRow, LookupDetailDto, object?>>
            {
                { _localizer[_dto.GetMemberDescription(x=>x.LookupId)], (row, item) => item.LookupId =Convert.ToInt32(row[_localizer[_dto.GetMemberDescription(x=>x.LookupId)]]) }, 
{ _localizer[_dto.GetMemberDescription(x=>x.Code)], (row, item) => item.Code = row[_localizer[_dto.GetMemberDescription(x=>x.Code)]].ToString() }, 
{ _localizer[_dto.GetMemberDescription(x=>x.Name)], (row, item) => item.Name = row[_localizer[_dto.GetMemberDescription(x=>x.Name)]].ToString() }, 
{ _localizer[_dto.GetMemberDescription(x=>x.NameBN)], (row, item) => item.NameBN = row[_localizer[_dto.GetMemberDescription(x=>x.NameBN)]].ToString() }, 
{ _localizer[_dto.GetMemberDescription(x=>x.Description)], (row, item) => item.Description = row[_localizer[_dto.GetMemberDescription(x=>x.Description)]].ToString() }, 
{ _localizer[_dto.GetMemberDescription(x=>x.LookupDetailId)], (row, item) => item.LookupDetailId =Convert.ToInt32(row[_localizer[_dto.GetMemberDescription(x=>x.LookupDetailId)]]) }, 
{ _localizer[_dto.GetMemberDescription(x=>x.IsActive)], (row, item) => item.IsActive =Convert.ToBoolean(row[_localizer[_dto.GetMemberDescription(x=>x.IsActive)]]) }, 

            }, _localizer[_dto.GetClassDescription()]);
            if (result.Succeeded && result.Data is not null)
            {
                foreach (var dto in result.Data)
                {
                    var exists = await _context.LookupDetails.AnyAsync(x => x.Name == dto.Name, cancellationToken);
                    if (!exists)
                    {
                        var item = LookupDetailMapper.FromDto(dto);
                        // add create domain events if this entity implement the IHasDomainEvent interface
				        // item.AddDomainEvent(new LookupDetailCreatedEvent(item));
                        await _context.LookupDetails.AddAsync(item, cancellationToken);
                    }
                 }
                 await _context.SaveChangesAsync(cancellationToken);
                 return await Result<int>.SuccessAsync(result.Data.Count());
           }
           else
           {
               return await Result<int>.FailureAsync(result.Errors);
           }
        }
        public async Task<Result<byte[]>> Handle(CreateLookupDetailsTemplateCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement ImportLookupDetailsCommandHandler method 
            var fields = new string[] {
                   // TODO: Define the fields that should be generate in the template, for example:
                   _localizer[_dto.GetMemberDescription(x=>x.LookupId)], 
_localizer[_dto.GetMemberDescription(x=>x.Code)], 
_localizer[_dto.GetMemberDescription(x=>x.Name)], 
_localizer[_dto.GetMemberDescription(x=>x.NameBN)], 
_localizer[_dto.GetMemberDescription(x=>x.Description)], 
_localizer[_dto.GetMemberDescription(x=>x.LookupDetailId)], 
_localizer[_dto.GetMemberDescription(x=>x.IsActive)], 

                };
            var result = await _excelService.CreateTemplateAsync(fields, _localizer[_dto.GetClassDescription()]);
            return await Result<byte[]>.SuccessAsync(result);
        }
    }

