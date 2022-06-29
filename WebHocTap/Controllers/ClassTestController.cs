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
    public class ClassTestController : ControllerBase
    {
        private IEClassTest _cltest;
        private IMapper cltestmap;

        public ClassTestController(IEClassTest cltest, IMapper mapper)
        {
            cltestmap = mapper;
            _cltest = cltest;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<ClassTestDTO>>> getClasstest()
        {
            var model = _cltest.GetAll();
            if (model == null)
            {
                return new List<ClassTestDTO>();
            }
            return model.ToList();
        }


        //POST
        [HttpPost]
        public ActionResult<bool> AddCLTest(ClassTestDTO model)
        {
            var check = _cltest.Insert(model);
            _cltest.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateCLTest(ClassTestDTO model)
        {
            var check = _cltest.Update(model);
            _cltest.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCLTest(int id)
        {
            var check = _cltest.Delete(id);

            _cltest.Save();
            return check;

        }
    }
}
