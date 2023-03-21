using System;
using System.Collections.Generic;

namespace LibraryWebApplication;

public partial class Exercise
{
    public int ExId { get; set; }

    public int? SheduleId { get; set; }

    public string? ExName { get; set; }

    public int? ExDuration { get; set; }

    public int? NumOfSets { get; set; }

    public virtual Shedule? Shedule { get; set; }
}
