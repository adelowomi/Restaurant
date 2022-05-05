namespace Restaurant.Models
{
    public class Opening
    {
        public double Value { get; set; }
        public string? Type { get; set; }
    }

    public enum OpeningType
    {
        open,
        close
    }
}