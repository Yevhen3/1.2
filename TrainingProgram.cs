using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class TrainingProgram
{
    public int ProgramId { get; set; }

    public string? ProgramType { get; set; }

    public int? ProgramDuration { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Runner> Runners { get; } = new List<Runner>();

    public virtual ICollection<Shedule> Shedules { get; } = new List<Shedule>();
}
