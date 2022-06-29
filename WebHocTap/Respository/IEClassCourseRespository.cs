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
    public interface IEClassCourseRespository
    {
        List<Class_CourseDTO> GetAll();
        Class_CourseDTO GetById(int lassCourseId);
        bool Insert(Class_CourseDTO class_Course);
        bool Update(Class_CourseDTO class_Course);
        bool Delete(int lassCourseId);
        void Save();
    }
}
