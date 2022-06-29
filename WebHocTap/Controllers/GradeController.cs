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
    public class GradeController : ControllerBase
    {
        private IEGradeRespository _GraRespo;
        private IMapper admap;
        public GradeController(IEGradeRespository grarespo, IMapper mapper)
        {
            admap = mapper;
            _GraRespo = grarespo;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<GradeDTO>>> getGrade()
        {
            var model = _GraRespo.GetAll();
            if (model == null)
            {
                return new List<GradeDTO>();
            }
            return model.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<bool> AddGra(GradeDTO model)
        {
            var check = _GraRespo.Insert(model);
            _GraRespo.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateGra(GradeDTO model)
        {
            var check = _GraRespo.Update(model);
            _GraRespo.Save();
            return check;

        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteGra(int id)
        {
            var check = _GraRespo.Delete(id);

            _GraRespo.Save();
            return check;

        }
    }
}
