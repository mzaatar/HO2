
using HO2.Domain.DAL;
using HO2.Domain.Models;

namespace HO2Server.Tests.ObjectMothers
{
    public class MatesBuilder
    {
        Mate _mate = new Mate();
        IHO2Context _dbContext;
       
        public MatesBuilder(IHO2Context dbContext)
        {
            _mate = new Mate();
            _dbContext = dbContext;
        }
        public MatesBuilder WithDefault()
        {
            return this
                .WithId(1)
                .WithFristName("Mohamed")
                .WithLastName("Zaatar")
                .WithEmail("Mohamed.zaatar@readify.net");
        }

        public MatesBuilder WithId(int id)
        {
            this._mate.MateId = id;
            return this;
        }

        public MatesBuilder WithEmail(string email)
        {
            this._mate.Email = email;
            return this;
        }

        public MatesBuilder WithFristName(string firstName)
        {
            this._mate.FirstName = firstName;
            return this;
        }

        public MatesBuilder WithLastName(string lasttName)
        {
            this._mate.LastName = lasttName;
            return this;
        }

        public Mate Build(bool saveIntoDb = false)
        {
            if (saveIntoDb)
            {
                _dbContext.Set<Mate>().Add(_mate);
                _dbContext.Save();
            }
            return _mate;
        }
    }
}
