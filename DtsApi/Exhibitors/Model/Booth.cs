namespace DtsApi.Exhibitors.Model
{
    public class Booth
    {
        public BoothType BoothType { get; set; }
        public string BoothNumber { get; set; }
    }

    public enum BoothType
    {
        Booth_10x10,
        Corner_10x10,
        Booth_8x10,
        Corner_8x10,
        Custom,
    }
}
