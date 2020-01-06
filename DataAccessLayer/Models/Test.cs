using System;

namespace DAL.Models
{
    public class Test
    {
        public int TestID { get; }
        public Teacher Creator { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; }
        public int MaxMark { get; set; }
        public int Duration { get; set; }
        public Test(Teacher creator, string name, string description, int maxMark, int duration)
        {
            Creator = creator;
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            MaxMark = maxMark;
            Duration = duration;
        }
    }
}