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
    public class CourseRespository :IECourseRespository
    {
        private readonly IMapper admap;
        private readonly Context con;


        public CourseRespository(Context context,IMapper mapper)
        {
            con = context;
            admap = mapper;
        }

        public bool Delete(int courseId)
        {
            var DeleteCourse = con.Courses.Find(courseId);
            if (DeleteCourse == null)
            {
                return false;
            }
            con.Remove(DeleteCourse);
            return true;
        }

        public List<CourseDTO> GetAll()
        {
            var allCourse = con.Courses.ToList();
            return admap.Map<List<CourseDTO>>(allCourse);
        }

        public CourseDTO GetById(int courseId)
        {
            var byid = con.Courses.Find(courseId);
            if (byid == null)
            {
                return null;
            }

            return admap.Map<CourseDTO>(byid);
        }

        public bool Insert(CourseDTO course)
        {
            var insertCourse = con.Courses.Find(course.courseId);
            if (insertCourse == null)
            {
                con.Courses.Add(admap.Map<Course>(course));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(CourseDTO course)
        {
            var UpdateCourse = con.Courses.Find(course.courseId);
            if (UpdateCourse != null)
            {
                con.Courses.Update(admap.Map(course, UpdateCourse));
                return true;
            }
            return false;
        }
    }
}
