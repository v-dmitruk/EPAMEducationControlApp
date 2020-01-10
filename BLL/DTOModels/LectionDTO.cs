using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class LectionDTO
    {
        public int LectionID { get; set; }
        public string LectionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LectionBody { get; set; }
        public int MaxMark { get; set; }
        public bool AdditionalMarkIsAvailable { get; set; }
        public TeacherDTO Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public DateTime? Date { get; set; }
        public LectionDTO()
        {

        }
    }
}
