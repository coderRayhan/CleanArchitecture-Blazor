﻿using System.ComponentModel;

namespace CleanArchitecture.Blazor.Domain.Common.Enums;
public enum PageStatus
{
    [Description("Coming Soon")] ComingSoon,
    [Description("WIP")] Wip,
    [Description("New")] New,
    [Description("Completed")] Completed
}
