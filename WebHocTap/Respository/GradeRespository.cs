using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Data;
using WebHocTap.Entity;
using WebHocTap.Respository;
using WebHocTap.DTO;
namespace WebHocTap.Respository
{
    public class GradeRespository : IEGradeRespository
    {

        private readonly IMapper grademap;
        private readonly Context con;

        public GradeRespository(Context context, IMapper mapper)
        {
            con = context;
            grademap = mapper;
        }

        public bool Delete(int gradeId)
        {
            var DeleteGra = con.Grades.Find(gradeId);
            if (DeleteGra == null)
            {
                return false;
            }
            con.Remove(DeleteGra);
            return true;
        }

        public List<GradeDTO> GetAll()
        {
            var allGra = con.Grades.ToList();
            return grademap.Map<List<GradeDTO>>(allGra);
        }

        public GradeDTO GetById(int gradeId)
        {
            var byid = con.Grades.Find(gradeId);
            if (byid == null)
            {
                return null;
            }

            return grademap.Map<GradeDTO>(byid);
        }

        public bool Insert(GradeDTO grade)
        {
            var insertGra = con.Grades.Find(grade.gradeId);
            if (insertGra == null)
            {
                con.Grades.Add(grademap.Map<Grade>(grade));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(GradeDTO grade)
        {
            var UpdateCourse = con.Grades.Find(grade.gradeId);
            if (UpdateCourse != null)
            {
                con.Grades.Update(grademap.Map(grade, UpdateCourse));
                return true;
            }
            return false;
        }
    }
}
