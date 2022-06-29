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
    public class TestRespository : IETest
    {
        private readonly IMapper testmap;
        private readonly Context con;
        public TestRespository(Context context, IMapper mapper)
        {
            con = context;
            testmap = mapper;
        }

        public bool Delete(int testId)
        {
            var DeleteTest = con.Tests.Find(testId);
            if (DeleteTest == null)
            {
                return false;
            }
            con.Remove(DeleteTest);
            return true;
        }

        public List<TestDTO> GetAll()
        {
            var alltest = con.Tests.ToList();
            return testmap.Map<List<TestDTO>>(alltest);

        }

        public TestDTO GetById(int testId)
        {
            var byid = con.Tests.Find(testId);
            if (byid == null)
            {
                return null;
            }

            return testmap.Map<TestDTO>(byid);
        }

        public bool Insert(TestDTO test)
        {
            var insert = con.Tests.Find(test.testId);
            if (insert == null)
            {
                con.Tests.Add(testmap.Map<Test>(test));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(TestDTO test)
        {
            var Update = con.Tests.Find(test.testId);
            if (Update != null)
            {
                con.Tests.Update(testmap.Map(test, Update));
                return true;
            }
            return false;
        }
    }
}
