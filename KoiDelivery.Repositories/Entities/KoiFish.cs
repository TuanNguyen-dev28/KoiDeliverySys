using System;
using System.Collections.Generic;

namespace KoiDelivery.Repositories.Entities;

public partial class KoiFish
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Color { get; set; }

    public int? SizeCm { get; set; }

    public int? LifespanYears { get; set; }

    public string? CareRequirements { get; set; }

    public string? NotableFeatures { get; set; }
}
