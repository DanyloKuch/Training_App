using System;


namespace Training_App.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Muscles { get; set; }
        public int CountOfBasicSets { get; set; }
        public int CountOfWurmUpSets { get; set; }
        public int Weight { get; set; }
        public DateTime Duration { get; set; }
        public List<Training> Training { get; set; } = new List<Training>();

    }
}
