using BLL.Interfaces;
using DAL.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BLLUnitOfWork : IBLLUnitOfWork
    {
        private IUnitOfWork _db { get; set; }
        private CourseService _courseService;
        private LectionService _lectionService;
        private PerformanceService _performanceService;
        private QuestionService _questionService;
        private StudentService _studentService;
        private TeacherService _teacherService;
        private TestService _testService;

        public BLLUnitOfWork(string connectString)
        {
            _db = new UnitOfWork(connectString);
        }
        public ICourseService CourseService
        {
            get
            {
                if (_courseService == null)
                    _courseService = new CourseService(_db);
                return _courseService;
            }
        }
        public ILectionService LectionService
        {
            get
            {
                if (_lectionService == null)
                    _lectionService = new LectionService(_db);
                return _lectionService;
            }
        }

        public IPerformanceService PerformanceService
        {
            get
            {
                if (_performanceService == null)
                    _performanceService = new PerformanceService(_db);
                return _performanceService;
            }
        }

        public IQuestionService QuestionService
        {
            get
            {
                if (_questionService == null)
                    _questionService = new QuestionService(_db);
                return _questionService;
            }
        }

        public IStudentService StudentService
        {
            get
            {
                if (_studentService == null)
                    _studentService = new StudentService(_db);
                return _studentService;
            }
        }

        public ITeacherService TeacherService
        {
            get
            {
                if (_teacherService == null)
                    _teacherService = new TeacherService(_db);
                return _teacherService;
            }
        }

        public ITestService TestService
        {
            get
            {
                if (_testService == null)
                    _testService = new TestService(_db);
                return _testService;
            }
        }
    }
}
