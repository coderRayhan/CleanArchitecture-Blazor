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
//       This file defines the validation rules for the AddEditLookupDetailCommand 
//       used to add or edit LookupDetail entities within the CleanArchitecture.Blazor 
//       application. It enforces maximum field lengths and required properties 
//       to maintain data integrity and validation standards.
//     
//     Documentation:
//       https://docs.cleanarchitectureblazor.com/features/lookupdetail
// </auto-generated>
//------------------------------------------------------------------------------

// Usage:
// This validator enforces constraints on the AddEditLookupDetailCommand, such as
// maximum field length for ...

namespace CleanArchitecture.Blazor.Application.Features.LookupDetails.Commands.AddEdit;

public class AddEditLookupDetailCommandValidator : AbstractValidator<AddEditLookupDetailCommand>
{
    public AddEditLookupDetailCommandValidator()
    {
                RuleFor(v => v.LookupId).NotNull(); 
    RuleFor(v => v.Code).MaximumLength(255); 
    RuleFor(v => v.Name).MaximumLength(50).NotEmpty(); 
    RuleFor(v => v.NameBN).MaximumLength(255); 
    RuleFor(v => v.Description).MaximumLength(255); 

     }

}

