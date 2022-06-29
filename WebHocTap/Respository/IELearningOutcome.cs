using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Entity;
using WebHocTap.DTO;
namespace WebHocTap.Respository
{
    public interface IELearningOutcome
    {
        List<LearningOutcomeDTO> GetAll();
        LearningOutcomeDTO GetById(int Id);
        bool Insert(LearningOutcomeDTO learningOutcome);
        bool Update(LearningOutcomeDTO learningOutcome);
        bool Delete(int Id);
        void Save();
    }
}
