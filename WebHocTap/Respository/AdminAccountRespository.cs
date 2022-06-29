using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Respository;
using AutoMapper;
using WebHocTap.Data;
using WebHocTap.DTO;
using WebHocTap.Entity;


namespace WebHocTap.Respository
{
    public class AdminAccountRespository : IEAdminAccRespository
    {
        private readonly IMapper adaccmap;
        private readonly Context con;

        public AdminAccountRespository(Context context, IMapper mapper)
        {
            con = context;
            adaccmap = mapper;
        }
        public bool Delete(string userName)
        {
            var DeleteAdAcc = con.AdminAccounts.Find(userName);
            if (DeleteAdAcc == null)
            {
                return false;
            }
            con.Remove(DeleteAdAcc);
            return true;
        }

        public List<AdminAccountDTO> GetAll()
        {
            var allAd = con.AdminAccounts.ToList();
            return adaccmap.Map<List<AdminAccountDTO>>(allAd);

        }

        public AdminAccountDTO GetByUser(string userName)
        {
            var byuser = con.AdminAccounts.Find(userName);
            if (byuser == null)
            {
                return null;
            }

            return adaccmap.Map<AdminAccountDTO>(byuser);
        }

        public bool Insert(AdminAccountDTO adminacc)
        {
            var insertAd = con.AdminAccounts.Find(adminacc.userName);
            if (insertAd == null)
            {
                con.AdminAccounts.Add(adaccmap.Map<AdminAccount>(adminacc));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(AdminAccountDTO adminacc)
        {
            var UpdateAd = con.AdminAccounts.Find(adminacc.userName);
            if (UpdateAd != null)
            {
                con.AdminAccounts.Update(adaccmap.Map(adminacc, UpdateAd));
                return true;
            }
            return false;
        }
    }
}
