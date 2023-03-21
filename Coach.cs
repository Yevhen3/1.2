using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Coach
{
    public int CoachId { get; set; }

    public string? CoachName { get; set; }

    public DateTime? CoachBirthDay { get; set; }

    public virtual ICollection<Runner> Runners { get; } = new List<Runner>();

    public virtual ICollection<Shedule> Shedules { get; } = new List<Shedule>();
}
