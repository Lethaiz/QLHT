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
    public interface IESubject
    {
        List<SubjectDTO> GetAll();
        SubjectDTO GetById(int subjectId);
        bool Insert(SubjectDTO subject);
        bool Update(SubjectDTO subject);
        bool Delete(int subjectId);
        void Save();
    }
}
