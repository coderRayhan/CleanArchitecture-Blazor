using CleanArchitecture.Blazor.Domain.Common.Entities;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class ApplicationInfo : BaseAuditableEntity
{
    public int VersionId { get; set; }
    public int BranchId { get; set; }
    public int ShiftId { get; set; }
    public int ClassId { get; set; }
    public string ApplicationId { get; set; }
    public string Password { get; set; }
    public int StudentTypeId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string FullNameBangla { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string SMSNotificationNo { get; set; }
    public string Nationality { get; set; }
    public string Religion { get; set; }
    public string FatherName { get; set; }
    public string FatherNameBangla { get; set; }
    public string MotherName { get; set; }
    public string MotherNameBangla { get; set; }
    public string PhotoUrl { get; set; }
    public string SignatureUrl { get; set; }
    public bool IsDeleted { get; set; }
}
