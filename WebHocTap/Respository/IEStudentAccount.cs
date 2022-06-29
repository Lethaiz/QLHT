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
    public interface IEStudentAccount
    {
        List<StudentAccountDTO> GetAll();
        StudentAccountDTO GetById(string userName);
        bool Insert(StudentAccountDTO student);
        bool Update(StudentAccountDTO student);
        bool Delete(string userName);
        void Save();
    }
}
