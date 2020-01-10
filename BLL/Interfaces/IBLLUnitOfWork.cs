using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface  IBLLUnitOfWork
    {
        ICourseService CourseService { get; }
        ILectionService LectionService { get; }
        IPerformanceService PerformanceService { get; }
        IQuestionService QuestionService { get; }
        IStudentService StudentService { get; }
        ITeacherService TeacherService { get; }
        ITestService TestService { get; }
    }
}
