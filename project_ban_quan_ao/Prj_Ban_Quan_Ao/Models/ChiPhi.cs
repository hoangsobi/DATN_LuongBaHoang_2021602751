using System;
using System.Collections.Generic;

namespace Prj_Ban_Quan_Ao.Models;

public partial class ChiPhi
{
    public Guid Id { get; set; }

    public string? TenChiPhi { get; set; }

    public string? MucDich { get; set; }

    public double? SoTien { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChi { get; set; }

    public Guid? AccountId { get; set; }

    public virtual Account? Account { get; set; }
}
