using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDTO> GetByCreatorID(int creatorID);
        QuestionDTO GetByID(int questionID);
        IEnumerable<QuestionDTO> GetAll();
        void AddQuestion(QuestionDTO question);
        void DeleteQuestion(QuestionDTO question);
        void EditQuestion(QuestionDTO question);
    }
}
