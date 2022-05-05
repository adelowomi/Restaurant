namespace Restaurant.Models
{
    public class Schedule
    {
        public string Day { get; set; }
        public List<FormatedOpening> Openings { get; set; } 
        public bool ClosedAllDay { get; set; }
    }

    public class FormatedOpening
    {
        public string Type { get; set; }
        public string Time { get; set; }
    }
}