namespace SchoolClearanceWeb.Model
{
    public class ClearanceItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedAt { get; set; }
    }

    public class UpdateClearanceRequest
    {
        public int StudentId { get; set; }
        public int ItemId { get; set; }
        public bool IsCleared { get; set; }
    }
}

public class ClearanceSchedule
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class SetClearanceScheduleRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}