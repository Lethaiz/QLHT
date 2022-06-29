using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.DTO;
using WebHocTap.Entity;
namespace WebHocTap.Respository
{
    public interface IECourseRespository
    {
        List<CourseDTO> GetAll();
        CourseDTO GetById(int courseId);
        bool Insert(CourseDTO course);
        bool Update(CourseDTO course);
        bool Delete(int courseId);
        void Save();
    }
}
