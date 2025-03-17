using CleanArchitecture.Blazor.Application.Features.ApplicationInfos.Commands.AddEdit;
using CleanArchitecture.Blazor.Application.Features.ApplicationInfos.DTOs;
using CleanArchitecture.Blazor.Application.Features.Products.Commands.AddEdit;
using CleanArchitecture.Blazor.Application.Features.Products.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.ApplicationInfos.Mappers;

#pragma warning disable RMG020
#pragma warning disable RMG012
[Mapper]
public static partial class ApplicationInfoMapper
{
    public static partial ApplicationInfoDto ToDto(ApplicationInfo product);
    public static partial ApplicationInfo FromDto(ApplicationInfoDto dto);
    public static partial ApplicationInfo FromEditCommand(AddEditApplicationInfoCommand command);
    public static partial void ApplyChangesFrom(AddEditApplicationInfoCommand command, ApplicationInfo product);
    [MapperIgnoreSource(nameof(ApplicationInfoDto.Id))]
    public static partial AddEditApplicationInfoCommand CloneFromDto(ApplicationInfoDto dto);
    public static partial AddEditApplicationInfoCommand ToEditCommand(ApplicationInfoDto dto);
    public static partial IQueryable<ApplicationInfoDto> ProjectTo(this IQueryable<ApplicationInfo> q);
}
