using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Common.Interfaces.Contracts;
using CleanArchitecture.Blazor.Application.Features.ApplicationInfos.Mappers;

namespace CleanArchitecture.Blazor.Application.Features.ApplicationInfos.Commands.AddEdit;
public class AddEditApplicationInfoCommand : ICommand<int>
{
    public int Id { get; set; }
    public int VersionId { get; set; }
    public int BranchId { get; set; }
    public int ShiftId { get; set; }
    public int ClassId { get; set; }
    public string ApplicationId { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int StudentTypeId { get; set; }
    public string Email { get; set; } = string.Empty;
    [Required]
    public string FullName { get; set; } = string.Empty;
    public string? FullNameBangla { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string SMSNotificationNo { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Religion { get; set; } = string.Empty;
    public string FatherName { get; set; } = string.Empty;
    public string? FatherNameBangla { get; set; }
    public string MotherName { get; set; } = string.Empty;
    public string? MotherNameBangla { get; set; }
    public string? PhotoUrl { get; set; }
    public string? SignatureUrl { get; set; }
    public bool IsDeleted { get; set; }
}

internal sealed class AddEditApplicationInfoCommandHandler : ICommandHandler<AddEditApplicationInfoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddEditApplicationInfoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(AddEditApplicationInfoCommand request, CancellationToken cancellationToken)
    {
        if(request.Id > 0)
        {
            var item = await _context.ApplicationInfos.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item == null)
            {
                return await Result<int>.FailureAsync($"Application info with id: [{request.Id}] not found");
            }
            ApplicationInfoMapper.ApplyChangesFrom(request, item);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(item.Id);
        }
        else
        {
            var item = ApplicationInfoMapper.FromEditCommand(request);
            _context.ApplicationInfos.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(item.Id);
        }
    }
}
