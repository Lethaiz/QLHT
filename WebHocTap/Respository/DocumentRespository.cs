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
    public class DocumentRespository : IEDocumentRespository
    {
        private readonly IMapper docmap;
        private readonly Context con;


        public DocumentRespository(Context context,IMapper mapper)
        {
            con = context;
            docmap = mapper;
        }

        public bool Delete(int docId)
        {
            var DeleteDoc = con.Documents.Find(docId);
            if (DeleteDoc == null)
            {
                return false;
            }
            con.Remove(DeleteDoc);
            return true;
        }

        public List<DocumentDTO> GetAll()
        {
            var allDoc = con.Documents.ToList();
            return docmap.Map<List<DocumentDTO>>(allDoc);
        }

        public DocumentDTO GetById(int docId)
        {
            var byid = con.Documents.Find(docId);
            if (byid == null)
            {
                return null;
            }

            return docmap.Map<DocumentDTO>(byid);
        }

        public bool Insert(DocumentDTO document)
        {
            var insertDoc = con.Documents.Find(document.docId);
            if (insertDoc == null)
            {
                con.Documents.Add(docmap.Map<Document>(document));
                return true;
            }
            return false;
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public bool Update(DocumentDTO document)
        {
            var UpdateCourse = con.Documents.Find(document.docId);
            if (UpdateCourse != null)
            {
                con.Documents.Update(docmap.Map(document, UpdateCourse));
                return true;
            }
            return false;
        }

    }
}
