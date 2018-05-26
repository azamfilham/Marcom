using Marcom.Repository;
using Marcom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marcom.API.Controllers
{
    public class T_PromotionItemFilesController : ApiController
    {
        // GET: api/T_PromotionItemFiles
        public IEnumerable<T_PromotionItemFileViewModel> Get()
        {
            return T_PromotionItemFileRepo.Get();
        }

        // GET: api/T_PromotionItemFiles/5
        public T_PromotionItemFileViewModel Get(int id)
        {
            return T_PromotionItemFileRepo.GetById(id);
        }

        // POST: api/T_PromotionItemFiles
        public Responses Post([FromBody]T_PromotionItemFileViewModel entity)
        {
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = T_PromotionItemFileRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // PUT: api/T_PromotionItemFiles/5
        public Responses Put(int id, [FromBody]T_PromotionItemFileViewModel entity)
        {
            entity.Id = id;
            Responses result = new Responses();
            if (ModelState.IsValid)
            {
                result = T_PromotionItemFileRepo.Update(entity);
            }
            else
            {
                result.Success = false;
            }
            return result;
        }

        // DELETE: api/T_PromotionItemFiles/5
        public Responses Delete(int id)
        {
            return T_PromotionItemFileRepo.Delete(id);
        }

        [HttpPost]
        public async Task<string> Upload()
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            // extract file name and file contents
            var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters
                .FirstOrDefault(p => p.Name.ToLower() == "filename");
            string fileName = (fileNameParam == null) ? "" : fileNameParam.Value.Trim('"');
            byte[] file = await provider.Contents[0].ReadAsByteArrayAsync();

            // Here you can use EF with an entity with a byte[] property, or
            // an stored procedure with a varbinary parameter to insert the
            // data into the DB

            var result
                = string.Format("Received '{0}' with length: {1}", fileName, file.Length);
            return result;
        }
    }
}
