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
    public class StudentAccountController : ControllerBase
    {
        private IEStudentAccount _StuaccRespo;
        private IMapper stumap;

        public StudentAccountController(IEStudentAccount stuaccrespo, IMapper mapper)
        {
            stumap = mapper;
            _StuaccRespo = stuaccrespo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<StudentAccountDTO>>> getStuAcc()
        {
            var model = _StuaccRespo.GetAll();
            if (model == null)
            {
                return new List<StudentAccountDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddAdmin(StudentAccountDTO model)
        {
            var check = _StuaccRespo.Insert(model);
            _StuaccRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateAdmin(StudentAccountDTO model)
        {
            var check = _StuaccRespo.Update(model);
            _StuaccRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{username}")]
        public ActionResult<bool> DeleteAdmin(string username)
        {
            var check = _StuaccRespo.Delete(username);

            _StuaccRespo.Save();
            return check;

        }
    }
}
