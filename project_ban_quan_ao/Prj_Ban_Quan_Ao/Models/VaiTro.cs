using System;
using System.Collections.Generic;

namespace Prj_Ban_Quan_Ao.Models;

public partial class VaiTro
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<VaiTroQuyen> VaiTroQuyens { get; set; } = new List<VaiTroQuyen>();
}
