using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Application.Features.ApplicationInfos.Commands.AddEdit;
public class AddEditApplicationInfoCommandValidator : AbstractValidator<AddEditApplicationInfoCommand>
{
    public AddEditApplicationInfoCommandValidator()
    {
        RuleFor(e => e.VersionId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0).WithMessage("Version is required");

        RuleFor(e => e.BranchId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0).WithMessage("Branch is required");

        RuleFor(e => e.ClassId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0).WithMessage("Class is required");

        RuleFor(e => e.ShiftId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0).WithMessage("Shift is required");

        RuleFor(e => e.StudentTypeId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0).WithMessage("Student type is required");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Not a valid email");

        RuleFor(e => e.FullName)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(e => e.DateOfBirth)
            .NotEmpty().WithMessage("Name is required")
            .NotNull();

        RuleFor(e => e.Nationality)
            .NotEmpty().WithMessage("Nationality is required");

        RuleFor(e => e.Religion)
            .NotEmpty().WithMessage("Religion is required");

        RuleFor(e => e.FatherName)
            .NotEmpty().WithMessage("Father name is required");

        RuleFor(e => e.MotherName)
            .NotEmpty().WithMessage("Mother name is required");

        RuleFor(e => e.SMSNotificationNo)
            .NotEmpty().WithMessage("Phone number is required");
    }
}
