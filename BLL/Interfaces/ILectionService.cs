using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILectionService
    {
        IEnumerable<LectionDTO> GetAll();
        IEnumerable<LectionDTO> GetByName(string name);
        IEnumerable<LectionResultDTO> GetAllArchieved();
        IEnumerable<LectionResultDTO> GetArchievedByDate(int userID, DateTime date);
        IEnumerable<LectionResultDTO> GetArchievedByName(int userID, string name);
        IEnumerable<LectionDTO> GetAllActive(int userID);
        IEnumerable<LectionDTO> GetActiveByDate(int userID, DateTime date);
        IEnumerable<LectionDTO> GetActiveByName(int userID, string name);
        void EditLection(LectionDTO lection);
        void DeleteScheduledLection(LectionDTO lection, CourseDTO course);//or lectionID??
        void CreateLection(LectionDTO lection);
        void DeleteLection(LectionDTO lection);//or lectionID?
        void EditArchievedLection(LectionResultDTO lectionResult);
        LectionDTO GetByID(int lectionID);
    }
}
