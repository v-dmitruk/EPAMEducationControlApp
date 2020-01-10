using AutoMapper;
using BLL.DTOModels;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        Mapper map = new Mapper(MapperProfile.Configured());
        IUnitOfWork db { get; set; }
        public QuestionService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void AddQuestion(QuestionDTO question)
        {
            Question newQuestion = map.Map<Question>(question);
            db.Questions.Add(newQuestion);
            db.Save();
        }

        public void DeleteQuestion(QuestionDTO question)
        {
            db.Questions.Delete(question.QuestionID);
            db.Save();
        }

        public void EditQuestion(QuestionDTO question)
        {
            Question editedQuestion = db.Questions.Get(question.QuestionID);
            map.Map(question, editedQuestion);
            db.Questions.Update(editedQuestion);
            db.Save();
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            IEnumerable<Question> questions = db.Questions.GetAll();
            IEnumerable<QuestionDTO> result = map.Map<IEnumerable<QuestionDTO>>(questions);
            return result;
        }

        public IEnumerable<QuestionDTO> GetByCreatorID(int creatorID)
        {
            IEnumerable<Question> questions = db.Questions.Find(x => x.Creator.TeacherID == creatorID);
            IEnumerable<QuestionDTO> result = map.Map<IEnumerable<QuestionDTO>>(questions);
            return result;
        }

        public QuestionDTO GetByID(int questionID)
        {
            Question question = db.Questions.Get(questionID);
            QuestionDTO result = map.Map<QuestionDTO>(question);
            return result;
        }
    }
}
