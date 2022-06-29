using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Data;
using WebHocTap.Entity;
using WebHocTap.Respository;
using AutoMapper;
using WebHocTap.DTO;
namespace WebHocTap.Respository
{
    public class LearningOutcomeRespository : IELearningOutcome
    {
        private readonly IMapper map;
        private readonly Context con;
        public LearningOutcomeRespository(Context context, IMapper mapper)
        {
            con = context;
            map = mapper;
        }

        public bool Delete(int Id)
        {
            var Delete = con.LearningOutcomes.Find(Id);
            if (Delete == null)
            {
                return false;
            }
            con.Remove(Delete);
            return true;
        }

        public List<LearningOutcomeDTO> GetAll()
        {
            var all = con.LearningOutcomes.ToList();
            return map.Map<List<LearningOutcomeDTO>>(all);

        }

        public LearningOutcomeDTO GetById(int Id)
        {
            var byid = con.LearningOutcomes.Find(Id);
            if (byid == null)
            {
                return null;
            }

            return map.Map<LearningOutcomeDTO>(byid);
        }

        public bool Insert(LearningOutcomeDTO learningOutcome)
        {
            var insert = con.LearningOutcomes.Find(learningOutcome.Id);
            if (insert == null)
            {
                con.LearningOutcomes.Add(map.Map<LearningOutcome>(learningOutcome));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(LearningOutcomeDTO learningOutcome)
        {
            var Update = con.LearningOutcomes.Find(learningOutcome.Id);
            if (Update != null)
            {
                con.LearningOutcomes.Update(map.Map(learningOutcome, Update));
                return true;
            }
            return false;
        }
    }
}
