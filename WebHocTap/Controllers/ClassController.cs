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
    public class ClassController : ControllerBase
    {
        private IEClassRespository _ClassRespo;
        private IMapper admap;

        public ClassController(IEClassRespository classrespo, IMapper mapper)
        {
            admap = mapper;
            _ClassRespo = classrespo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<ClassDTO>>> getClassALL()
        {
            var model = _ClassRespo.GetAll();
            if (model == null)
            {
                return new List<ClassDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddClass(ClassDTO model)
        {
            var check = _ClassRespo.Insert(model);
            _ClassRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateAdmin(ClassDTO model)
        {
            var check = _ClassRespo.Update(model);
            _ClassRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteAdmin(string id)
        {
            var check = _ClassRespo.Delete(id);

            _ClassRespo.Save();
            return check;

        }
    }
}
