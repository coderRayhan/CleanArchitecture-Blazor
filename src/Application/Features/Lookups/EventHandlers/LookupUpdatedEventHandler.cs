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
//       Handles the `LookupUpdatedEvent` which occurs when a new lookup is updated.
//       This event handler can be extended to trigger additional actions, such as 
//       sending notifications or updating other systems.
// </auto-generated>
//------------------------------------------------------------------------------

using CleanArchitecture.Blazor.Domain.Events.Lookups;

namespace CleanArchitecture.Blazor.Application.Features.Lookups.EventHandlers;

    public class LookupUpdatedEventHandler : INotificationHandler<LookupUpdatedEvent>
    {
        private readonly ILogger<LookupUpdatedEventHandler> _logger;

        public LookupUpdatedEventHandler(
            ILogger<LookupUpdatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(LookupUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handled domain event '{EventType}' with notification: {@Notification} ", notification.GetType().Name, notification);
            return Task.CompletedTask;
        }
    }
