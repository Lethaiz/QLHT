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
    public class StudentAccRespository : IEStudentAccount
    {
        private readonly IMapper stuaccmap;
        private readonly Context con;

        public StudentAccRespository(Context context, IMapper mapper)
        {
            con = context;
            stuaccmap = mapper;
        }

        public bool Delete(string userName)
        {
            var DeleteStuAcc = con.StudentAccounts.Find(userName);
            if (DeleteStuAcc == null)
            {
                return false;
            }
            con.Remove(DeleteStuAcc);
            return true;
        }

        public List<StudentAccountDTO> GetAll()
        {
            var allStu = con.StudentAccounts.ToList();
            return stuaccmap.Map<List<StudentAccountDTO>>(allStu);

        }

        public StudentAccountDTO GetById(string userName)
        {
            var byuser = con.StudentAccounts.Find(userName);
            if (byuser == null)
            {
                return null;
            }

            return stuaccmap.Map<StudentAccountDTO>(byuser);
        }

        public bool Insert(StudentAccountDTO stuacc)
        {
            var insertAd = con.StudentAccounts.Find(stuacc.userName);
            if (insertAd == null)
            {
                con.StudentAccounts.Add(stuaccmap.Map<StudentAccount>(stuacc));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(StudentAccountDTO stuacc)
        {
            var UpdateAd = con.StudentAccounts.Find(stuacc.userName);
            if (UpdateAd != null)
            {
                con.StudentAccounts.Update(stuaccmap.Map(stuacc, UpdateAd));
                return true;
            }
            return false;
        }
    }
}
