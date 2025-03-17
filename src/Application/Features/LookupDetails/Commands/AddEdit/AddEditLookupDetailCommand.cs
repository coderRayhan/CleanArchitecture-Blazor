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
//       This file defines the command for adding or editing a lookupdetail entity,
//       including validation and mapping operations. It handles domain events
//       and cache invalidation for updated or newly created lookupdetail.
//     
//     Documentation:
//       https://docs.cleanarchitectureblazor.com/features/lookupdetail
// </auto-generated>
//------------------------------------------------------------------------------

// Usage:
// This command can be used to add a new lookupdetail or edit an existing one.
// It handles caching logic and domain event raising automatically.


using CleanArchitecture.Blazor.Application.Features.LookupDetails.Caching;
using CleanArchitecture.Blazor.Application.Features.LookupDetails.DTOs;
using CleanArchitecture.Blazor.Application.Features.LookupDetails.Mappers;
using CleanArchitecture.Blazor.Application.Features.Lookups.DTOs;
using CleanArchitecture.Blazor.Domain.Events.LookupDetails;

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Commands.AddEdit;

public class AddEditLookupDetailCommand: IRequest<Result<int>>
{
      [Description("Id")]
      public int Id { get; set; }
          [Description("Lookup id")]
    public int LookupId {get;set;} 
    [Description("Code")]
    public string? Code {get;set;} 
    [Description("Name")]
    public string Name {get;set;} 
    [Description("Name bn")]
    public string? NameBN {get;set;} 
    [Description("Description")]
    public string? Description {get;set;} 
    [Description("Lookup detail id")]
    public int? LookupDetailId {get;set;} 
    [Description("Is active")]
    public bool IsActive {get;set;} 
    [Description("Lookup")]
    public LookupDto Lookup {get;set;} 
    [Description("Detail")]
    public LookupDetailDto Detail {get;set;} 

}

public class AddEditLookupDetailCommandHandler : IRequestHandler<AddEditLookupDetailCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;
    public AddEditLookupDetailCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Result<int>> Handle(AddEditLookupDetailCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var item = await _context.LookupDetails.FindAsync(request.Id, cancellationToken);
            if (item == null)
            {
                return await Result<int>.FailureAsync($"LookupDetail with id: [{request.Id}] not found.");
            }
            LookupDetailMapper.ApplyChangesFrom(request,item);
			// raise a update domain event
			item.AddDomainEvent(new LookupDetailUpdatedEvent(item));
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(item.Id);
        }
        else
        {
            var item = LookupDetailMapper.FromEditCommand(request);
            // raise a create domain event
			item.AddDomainEvent(new LookupDetailCreatedEvent(item));
            _context.LookupDetails.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(item.Id);
        }
       
    }
}

