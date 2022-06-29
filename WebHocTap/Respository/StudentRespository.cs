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
    public class StudentRespository : IEStudent
    {
        private readonly IMapper stumap;
        private readonly Context con;
        public StudentRespository(Context context, IMapper mapper)
        {
            con = context;
            stumap = mapper;
        }

        public bool Delete(string studentId)
        {
            var DeleteStu = con.Admins.Find(studentId);
            if (DeleteStu == null)
            {
                return false;
            }
            con.Remove(DeleteStu);
            return true;
        }

        public List<StudentDTO> GetAll()
        {
            var allStu = con.Students.ToList();
            return stumap.Map<List<StudentDTO>>(allStu);

        }

        public StudentDTO GetById(string studentId)
        {
            var byid = con.Students.Find(studentId);
            if (byid == null)
            {
                return null;
            }

            return stumap.Map<StudentDTO>(byid);
        }

        public bool Insert(StudentDTO student)
        {
            var insertStu = con.Students.Find(student.studentId);
            if (insertStu == null)
            {
                con.Students.Add(stumap.Map<Student>(student));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(StudentDTO student)
        {
            var UpdateStu = con.Students.Find(student.studentId);
            if (UpdateStu != null)
            {
                con.Students.Update(stumap.Map(student, UpdateStu));
                return true;
            }
            return false;
        }

    }
}
