using System;
using System.Collections.Generic;

namespace Prj_Ban_Quan_Ao.Models;

public partial class VaiTroQuyen
{
    public Guid Id { get; set; }

    public Guid? VaiTroId { get; set; }

    public Guid? QuyenId { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual Quyen? Quyen { get; set; }

    public virtual VaiTro? VaiTro { get; set; }
}
