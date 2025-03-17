using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Application.Features.ApplicationInfos.DTOs;
public class ApplicationInfoDto
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
