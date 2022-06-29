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
    public class SubjectRespository : IESubject
    {
        private readonly IMapper map;
        private readonly Context con;
        public SubjectRespository(Context context, IMapper mapper)
        {
            con = context;
            map = mapper;
        }

        public bool Delete(int subjectId)
        {
            var Delete = con.Subjects.Find(subjectId);
            if (Delete == null)
            {
                return false;
            }
            con.Remove(Delete);
            return true;
        }

        public List<SubjectDTO> GetAll()
        {
            var all = con.Subjects.ToList();
            return map.Map<List<SubjectDTO>>(all);

        }

        public SubjectDTO GetById(int subjectId)
        {
            var byid = con.Subjects.Find(subjectId);
            if (byid == null)
            {
                return null;
            }

            return map.Map<SubjectDTO>(byid);
        }

        public bool Insert(SubjectDTO subject)
        {
            var insert = con.Subjects.Find(subject.subjectId);
            if (insert == null)
            {
                con.Subjects.Add(map.Map<Subject>(subject));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(SubjectDTO subject)
        {
            var Update = con.Subjects.Find(subject.subjectId);
            if (Update != null)
            {
                con.Subjects.Update(map.Map(subject, Update));
                return true;
            }
            return false;
        }
    }
}
