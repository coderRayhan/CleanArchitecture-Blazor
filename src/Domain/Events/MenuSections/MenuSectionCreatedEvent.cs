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
//       Represents a domain event that occurs when a new menusection is created.
//       Used to signal other parts of the system that a new menusection has been added.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchitecture.Blazor.Domain.Events;

    public class MenuSectionCreatedEvent : DomainEvent
    {
        public MenuSectionCreatedEvent(MenuSection item)
        {
            Item = item;
        }

        public MenuSection Item { get; }
    }

