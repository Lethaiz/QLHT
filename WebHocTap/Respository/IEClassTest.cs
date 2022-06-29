using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Entity;
using WebHocTap.DTO;
namespace WebHocTap.Respository
{
    public interface IEClassTest
    {
        List<ClassTestDTO> GetAll();
        ClassTestDTO GetById(int classTestId);
        bool Insert(ClassTestDTO classTest);
        bool Update(ClassTestDTO classTest);
        bool Delete(int classTestId);
        void Save();
    }
}
