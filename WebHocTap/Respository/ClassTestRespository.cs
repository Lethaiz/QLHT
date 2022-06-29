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
    public class ClassTestRespository : IEClassTest
    {
        private readonly IMapper cltestmap;
        private readonly Context con;
        public ClassTestRespository(Context context, IMapper mapper)
        {
            con = context;
            cltestmap = mapper;
        }

        public bool Delete(int classTestId)
        {
            var DeleteClTest = con.Class_Test.Find(classTestId);
            if (DeleteClTest == null)
            {
                return false;
            }
            con.Remove(DeleteClTest);
            return true;
        }

        public List<ClassTestDTO> GetAll()
        {
            var alltest = con.Class_Test.ToList();
            return cltestmap.Map<List<ClassTestDTO>>(alltest);

        }

        public ClassTestDTO GetById(int classTestId)
        {
            var byid = con.Class_Test.Find(classTestId);
            if (byid == null)
            {
                return null;
            }

            return cltestmap.Map<ClassTestDTO>(byid);
        }

        public bool Insert(ClassTestDTO classTest)
        {
            var insert = con.Class_Test.Find(classTest.classTestId);
            if (insert == null)
            {
                con.Class_Test.Add(cltestmap.Map<Class_Test>(classTest));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(ClassTestDTO classTest)
        {
            var Update = con.Class_Test.Find(classTest.classTestId);
            if (Update != null)
            {
                con.Class_Test.Update(cltestmap.Map(classTest, Update));
                return true;
            }
            return false;
        }
    }
}
