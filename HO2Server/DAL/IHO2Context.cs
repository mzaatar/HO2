using System.Data.Entity;
using HO2Server.Models.Business;

namespace HO2Server.DAL
{
    public interface IHO2Context
    {
     
        IDbSet<FriendGroup> Groups { get; set; }
        IDbSet<Mate> Mates { get; set; }
        IDbSet<Vote> Votes { get; set; }
        IDbSet<Place> Places { get; set; }

        int SaveChanges();

    }
}