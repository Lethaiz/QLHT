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
    public class StudentTestRespository : IEStudentTest
    {
        private readonly IMapper map;
        private readonly Context con;
        public StudentTestRespository(Context context, IMapper mapper)
        {
            con = context;
            map = mapper;
        }

        public bool Delete(int studentTestId)
        {
            var Delete = con.Student_Test.Find(studentTestId);
            if (Delete == null)
            {
                return false;
            }
            con.Remove(Delete);
            return true;
        }

        public List<StudentTestDTO> GetAll()
        {
            var all = con.Student_Test.ToList();
            return map.Map<List<StudentTestDTO>>(all);

        }

        public StudentTestDTO GetById(int studentTestId)
        {
            var byid = con.Student_Test.Find(studentTestId);
            if (byid == null)
            {
                return null;
            }

            return map.Map<StudentTestDTO>(byid);
        }

        public bool Insert(StudentTestDTO studentTest)
        {
            var insert = con.Student_Test.Find(studentTest.studentTestId);
            if (insert == null)
            {
                con.Student_Test.Add(map.Map<Student_Test>(studentTest));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(StudentTestDTO studentTest)
        {
            var Update = con.Student_Test.Find(studentTest.studentTestId);
            if (Update != null)
            {
                con.Student_Test.Update(map.Map(studentTest, Update));
                return true;
            }
            return false;
        }
    }
}
