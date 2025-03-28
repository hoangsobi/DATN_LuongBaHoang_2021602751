using System;
using System.Collections.Generic;

namespace Prj_Ban_Quan_Ao.Models;

public partial class Quyen
{
    public Guid Id { get; set; }

    public string? Ten { get; set; }

    public string? Rout { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? IconClass { get; set; }

    public int? Order { get; set; }

    public virtual ICollection<VaiTroQuyen> VaiTroQuyens { get; set; } = new List<VaiTroQuyen>();
}
