using System;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HO2.Domain.DAL
{
    public interface IHO2Context : IDisposable
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Save();
        DbContextTransaction BeginTransaction();
        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
        Task SaveAsync();


        //IDbSet<FriendGroup> Groups { get; set; }
        //IDbSet<Mate> Mates { get; set; }
        //IDbSet<Vote> Votes { get; set; }
        //IDbSet<Place> Places { get; set; }

        //int SaveChanges();
    }
}