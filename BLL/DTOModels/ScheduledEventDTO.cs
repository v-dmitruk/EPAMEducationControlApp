using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ScheduledEventDTO
    {
        public int ScheduledEventID { get; set; }
        public CourseDTO Course { get; set; }
        public LectionDTO Lection { get; set; }
        public TestDTO Test { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public ScheduledEventDTO()
        {

        }
    }
}
