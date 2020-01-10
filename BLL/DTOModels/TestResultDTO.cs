using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class TestResultDTO
    {
        public int TestResultID { get; set; }
        public TestDTO Test { get; set; }
        public StudentDTO Student { get; set; }
        public int Mark { get; set; }
        public DateTime PassDate { get; set; }
        public CourseDTO Course { get; set; }
        public TestResultDTO()
        {

        }
    }
}
