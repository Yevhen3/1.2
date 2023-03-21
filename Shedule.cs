using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Shedule
{
    public int SheduleId { get; set; }

    public DateTime? Datetime { get; set; }

    public int? RunnerId { get; set; }

    public int? CoachId { get; set; }

    public decimal? AvgPace { get; set; }

    public int? Distant { get; set; }

    public int? Calories { get; set; }

    public int ProgramId { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual ICollection<Exercise> Exercises { get; } = new List<Exercise>();

    public virtual TrainingProgram Program { get; set; } = null!;

    public virtual Runner? Runner { get; set; }
}
