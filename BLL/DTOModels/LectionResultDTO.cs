using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class LectionResultDTO
    {
        public int LectionResultID { get; set; }
        public LectionDTO Lection { get; set; }
        public StudentDTO Student { get; set; }
        public int Mark { get; set; }
        public int AdditionalMark { get; set; }
        public DateTime Date { get; set; }
        public CourseDTO Course { get; set; }
        public bool IsVisited { get; set; }
        public LectionResultDTO()
        {

        }
    }
}
