using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using WebHocTap.Data;
using WebHocTap.Entity;
using WebHocTap.Respository;
using AutoMapper;
using WebHocTap.DTO;
namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCategoryController : ControllerBase
    {
        private IETestCate _testcate;
        private IMapper testcatemap;

        public TestCategoryController(IETestCate testcate, IMapper mapper)
        {
            testcatemap = mapper;
            _testcate = testcate;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<TestCateDTO>>> gettestcate()
        {
            var model = _testcate.GetAll();
            if (model == null)
            {
                return new List<TestCateDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddAdmin(TestCateDTO model)
        {
            var check = _testcate.Insert(model);
            _testcate.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateTestcate(TestCateDTO model)
        {
            var check = _testcate.Update(model);
            _testcate.Save();
            return check;

        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTestcate(int id)
        {
            var check = _testcate.Delete(id);

            _testcate.Save();
            return check;

        }
    }
}
