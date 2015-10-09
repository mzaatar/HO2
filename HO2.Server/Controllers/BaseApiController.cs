using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Http;
using HO2.Domain.DAL.Common;

namespace HO2.Server.Controllers
{
    public class BaseApiController<T> : ApiController where T : class
    {
        protected IGenericRepository<T> DataStore { get; set; }
        protected string[] Includes { get; set; }

        public BaseApiController(IGenericRepository<T> repo)
        {
            //TODO: USE DEPENDENCY INJECTION FOR DECOUPLING
            this.DataStore = repo; //new GenericRepository<T>();
        }

        // GET api/<controller>
        public virtual IEnumerable<T> Get()
        {
            return DataStore.Get();
        }

        // GET api/<controller>/5
        public virtual T Get(int id)
        {
            return DataStore.GetById(id);
        }

        // POST api/<controller>
        public virtual void Post([FromBody] T value)
        {
            try
            {
                DataStore.Update(value);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>
        public virtual void Put([FromBody] T value)
        {
            DataStore.Insert(value);
        }

        // DELETE api/<controller>/5
        public virtual void Delete(int id)
        {
            DataStore.Delete(id);
        }

        public virtual void Delete([FromBody] T value)
        {
            DataStore.Delete(value);
        }

        protected IEnumerable GetModelErrors()
        {
            return this.ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

    }
}