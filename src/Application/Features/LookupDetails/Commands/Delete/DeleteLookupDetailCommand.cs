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
//       This file defines the command and its handler for deleting one or more
//       LookupDetail entities from the CleanArchitecture.Blazor application. It
//       implements caching invalidation logic to ensure that data consistency is
//       maintained. Domain events are triggered for deleted entities to support 
//       integration with other parts of the system.
//       for separation of concerns and encapsulation.
//     
//     Documentation:
//       https://docs.cleanarchitectureblazor.com/features/lookupdetail
// </auto-generated>
//------------------------------------------------------------------------------

// Usage:
// This command can be used to delete multiple LookupDetails from the system by specifying
// their IDs. The handler also raises domain events for each deleted lookupdetail to
// notify other bounded contexts and invalidate relevant cache entries.

using CleanArchitecture.Blazor.Application.Features.LookupDetails.Caching;
using CleanArchitecture.Blazor.Domain.Events.LookupDetails;


namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Commands.Delete;

public class DeleteLookupDetailCommand:  IRequest<Result<int>>
{
  public int[] Id {  get; }
  public DeleteLookupDetailCommand(int[] id)
  {
    Id = id;
  }
}

public class DeleteLookupDetailCommandHandler : 
             IRequestHandler<DeleteLookupDetailCommand, Result<int>>

{
    private readonly IApplicationDbContext _context;
    public DeleteLookupDetailCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Result<int>> Handle(DeleteLookupDetailCommand request, CancellationToken cancellationToken)
    {
        var items = await _context.LookupDetails.Where(x=>request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
        foreach (var item in items)
        {
		    // raise a delete domain event
			item.AddDomainEvent(new LookupDetailDeletedEvent(item.Id));
            _context.LookupDetails.Remove(item);
        }
        var result = await _context.SaveChangesAsync(cancellationToken);
        return await Result<int>.SuccessAsync(result);
    }

}

