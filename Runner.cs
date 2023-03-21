using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Runner
{
    public int RunnerId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? Mobile { get; set; }

    public int? CoachId { get; set; }

    public DateTime? RunnerBirthDay { get; set; }

    public decimal? RunnerWeight { get; set; }

    public int? ProgramId { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual TrainingProgram? Program { get; set; }

    public virtual ICollection<Shedule> Shedules { get; } = new List<Shedule>();
}
