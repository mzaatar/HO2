using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HO2Server.Models.Business;

namespace HO2Server.Tests.ObjectMothers
{
    public class MatesBuilder
    {
        Mate _mate = new Mate();

        public MatesBuilder withDefault()
        {
            return this
                .withId(1)
                .withFristName("Moahmed")
                .withLastName("Zaatar")
                .withEmail("Mohamed.zaatar@gmail.com");
        }

        public MatesBuilder withId(int id)
        {
            this._mate.MateId = id;
            return this;
        }

        public MatesBuilder withEmail(string email)
        {
            this._mate.Email = email;
            return this;
        }

        public MatesBuilder withFristName(string firstName)
        {
            this._mate.FirstName = firstName;
            return this;
        }

        public MatesBuilder withLastName(string lasttName)
        {
            this._mate.LastName = lasttName;
            return this;
        }

        public Mate build()
        {
            return _mate;
        }
    }
}
