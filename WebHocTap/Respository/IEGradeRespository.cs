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
    public interface IEGradeRespository
    {
        List<GradeDTO> GetAll();
        GradeDTO GetById(int gradeId);
        bool Insert(GradeDTO grade);
        bool Update(GradeDTO grade);
        bool Delete(int gradeId);
        void Save();
    }
}
