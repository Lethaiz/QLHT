using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public class LearningOutcomeController : ControllerBase
    {
        private IELearningOutcome _outcome;
        private IMapper map;

        public LearningOutcomeController(IELearningOutcome outcome, IMapper mapper)
        {
            map = mapper;
            _outcome = outcome;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<List<LearningOutcomeDTO>>> getsub()
        {
            var model = _outcome.GetAll();
            if (model == null)
            {
                return new List<LearningOutcomeDTO>();
            }
            return model.ToList();
        }


        //POST
        [HttpPost]
        public ActionResult<bool> AddSub(LearningOutcomeDTO model)
        {
            var check = _outcome.Insert(model);
            _outcome.Save();
            return check;

        }

        //PUT
        [HttpPut]
        public ActionResult<bool> UpdateTest(LearningOutcomeDTO model)
        {
            var check = _outcome.Update(model);
            _outcome.Save();
            return check;

        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTest(int id)
        {
            var check = _outcome.Delete(id);

            _outcome.Save();
            return check;

        }
    }
}
