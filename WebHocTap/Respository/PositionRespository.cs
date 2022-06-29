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
    public class PositionRespository : IEPositionRespository
    {
        private readonly IMapper posmap;
        private readonly Context con;

        public PositionRespository(Context context, IMapper mapper)
        {
            con = context;
            posmap = mapper;
        }

        public bool Delete(int positionId)
        {
            var DeletePos = con.Positions.Find(positionId);
            if (DeletePos == null)
            {
                return false;
            }
            con.Remove(DeletePos);
            return true;
        }

        public List<PositionDTO> GetAll()
        {
            var allPos = con.Positions.ToList();
            return posmap.Map<List<PositionDTO>>(allPos);
        }

        public PositionDTO GetById(int positionId)
        {
            var byid = con.Positions.Find(positionId);
            if (byid == null)
            {
                return null;
            }

            return posmap.Map<PositionDTO>(byid);
        }

        public bool Insert(PositionDTO position)
        {
            var insertGra = con.Positions.Find(position.positionId);
            if (insertGra == null)
            {
                con.Positions.Add(posmap.Map<Position>(position));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(PositionDTO position)
        {
            var Updatepos = con.Positions.Find(position.positionId);
            if (Updatepos != null)
            {
                con.Positions.Update(posmap.Map(position, Updatepos));
                return true;
            }
            return false;
        }
    }
}
