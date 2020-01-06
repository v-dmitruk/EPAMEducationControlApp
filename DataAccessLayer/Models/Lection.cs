using System;

namespace DAL.Models
{
    public class Lection
    {
        public int LectionID { get; }
        public string LectionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LectionBody { get; set; }
        public int MaxMark { get; set; }
        public bool AdditionalMarkIsAvailable { get; set; }
        public Teacher Creator { get; }
        public DateTime CreationDate { get; }
        public Lection(string type, string name, string description, string body, int maxMark, bool availability, Teacher creator)
        {
            LectionType = type;
            Name = name;
            Description = description;
            LectionBody = body;
            MaxMark = maxMark;
            AdditionalMarkIsAvailable = availability;
            Creator = creator;
            CreationDate = DateTime.Now;
        }
    }

}