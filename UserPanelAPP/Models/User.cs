using System;
using System.Collections.Generic;

namespace UserPanelAPP.Models;

public partial class User
{
    public string Tcno { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public bool? Status { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public int Id { get; set; }

    public DateOnly? BirthDate { get; set; }
}
