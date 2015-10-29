using System.Data.Entity;
using System.Linq;
using HO2.Domain.DAL;
using HO2.Domain.DAL.Common;
using HO2.Domain.Models;
using NUnit.Framework;
using Shouldly;

namespace HO2.Server.Tests.DAL
{
    [TestFixture]
    public class GenericRepositoryTest
    {
        private HO2Context _db;
        private DbContextTransaction _transaction;
        private IGenericRepository<Mate> _repository;
            
        [SetUp]
        public void SetUp()
        {
            _db = new HO2Context();
            _repository= new GenericRepository<Mate>(_db);
            _transaction = _db.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Dispose();
            _db.Dispose();
        }

        [Test]
        public void Insert_mate_then_it_should_in_db()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build();

            _repository.Insert(mate);

            // Assert
            _repository.ContextCount().ShouldBe(1);
            _repository.DbSet.Count().ShouldBe(1);

            _repository.DbSet.Single().FirstName.ShouldBe(mate.FirstName);
            _repository.DbSet.Single().LastName.ShouldBe(mate.LastName);
            _repository.DbSet.Single().Email.ShouldBe(mate.Email);
            _repository.DbSet.Single().FriendGroups.ShouldBe(mate.FriendGroups);
        }

        [Test]
        public void Insert_mate_then_it_should_be_retrieved()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build();

            _repository.Insert(mate);

            // Assert
            _repository.ContextCount().ShouldBe(1);
            _repository.Get(s => s.Id == mate.Id).FirstName.ShouldBe(mate.FirstName);
            _repository.Get(s => s.Id == mate.Id).LastName.ShouldBe(mate.LastName);
            _repository.Get(s => s.Id == mate.Id).Email.ShouldBe(mate.Email);
            _repository.Get(s => s.Id == mate.Id).FriendGroups.ShouldBe(mate.FriendGroups);
        }

        [Test]
        public void Insert_mate_then_it_should_be_retrieved_by_id()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build();

            _repository.Insert(mate);

            // Assert
            Mate returnedMate = _repository.GetById(mate.Id);
            returnedMate.FirstName.ShouldBe(mate.FirstName);
            returnedMate.LastName.ShouldBe(mate.LastName);
            returnedMate.Email.ShouldBe(mate.Email);
            returnedMate.FriendGroups.ShouldBe(mate.FriendGroups);
        }

        [Test]
        public void Insert_mate_then_it_should_be_retrieved_by_first()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build();

            _repository.Insert(mate);

            // Assert
            Mate returnedMate = _repository.GetFirst(s => s.Id == mate.Id);
            returnedMate.FirstName.ShouldBe(mate.FirstName);
            returnedMate.LastName.ShouldBe(mate.LastName);
            returnedMate.Email.ShouldBe(mate.Email);
            returnedMate.FriendGroups.ShouldBe(mate.FriendGroups);
        }

        [Test]
        public void Insert_mate_then_it_should_be_retrieved_by_single()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build();

            _repository.Insert(mate);

            // Assert
            Mate returnedMate = _repository.GetSingle(s => s.Id == mate.Id);
            returnedMate.FirstName.ShouldBe(mate.FirstName);
            returnedMate.LastName.ShouldBe(mate.LastName);
            returnedMate.Email.ShouldBe(mate.Email);
            returnedMate.FriendGroups.ShouldBe(mate.FriendGroups);
        }

        [Test]
        public void Insert_two_mate_then_retrieve_them_by_get_many()
        {
            // Arrange
            Mate m1 = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);
            Mate m2 = new ObjectMothers.MatesBuilder(_db)
                .WithEmail("Cormac.Long@readify.net")
                .WithFristName("Cormac")
                .WithLastName("Long")
                .Build(true);

            // Assert
            var returnedMates = _repository.GetMany(s => s.Email.Contains("readify"));
            returnedMates.Count().ShouldBe(2);
            returnedMates.Single(s => s.Email == m2.Email).FirstName.ShouldBe(m2.FirstName);
            returnedMates.Single(s => s.FirstName == m1.FirstName).Email.ShouldBe(m1.Email);
        }


        [Test]
        public void Insert_two_mate_then_retrieve_them()
        {
            // Arrange
            Mate m1 = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);
            Mate m2 = new ObjectMothers.MatesBuilder(_db)
                .WithEmail("Cormac.Long@readify.net")
                .WithFristName("Cormac")
                .WithLastName("Long")
                .Build(true);

            // Assert
            var returnedMates = _repository.Get();
            returnedMates.Count().ShouldBe(2);
            returnedMates.Single(s => s.Email == m2.Email).FirstName.ShouldBe(m2.FirstName);
            returnedMates.Single(s => s.FirstName == m1.FirstName).Email.ShouldBe(m1.Email);
        }

        [Test]
        public void Insert_two_mate_then_retrieve_them_by_get_many_queryable()
        {
            // Arrange
            Mate m1 = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);
            Mate m2 = new ObjectMothers.MatesBuilder(_db)
                .WithEmail("Cormac.Long@readify.net")
                .WithFristName("Cormac")
                .WithLastName("Long")
                .Build(true);

            // Assert
            var returnedMates = _repository.GetManyQueryable(s=>s.Email.Contains("readify"));
            returnedMates.Count().ShouldBe(2);
            returnedMates.Single(s => s.Email == m2.Email).FirstName.ShouldBe(m2.FirstName);
            returnedMates.Single(s => s.FirstName == m1.FirstName).Email.ShouldBe(m1.Email);
        }

        
        [Test]
        public void Delete_existed_mate_then_it_should_exist()
        {
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);
            
            //arrange
            _repository.Delete(mate);

            // Assert
            _repository.DbSet.Count().ShouldBe(0);
        }


        [Test]
        public void Update_existed_mate_then_changes_should_be_persisted()
        {
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);
            mate.LastName = "Davies";

            // Act
            _repository.Update(mate);

            // Assert
            _repository.DbSet.Single().LastName.ShouldBe("Davies");
        }

        [Test]
        public void Set_dbset_with_object_then_check_existence()
        {
            var mate = new ObjectMothers.MatesBuilder(_db).WithDefault().Build(true);

            // Assert
            _repository.Exists(mate.Id).ShouldBe(true);
        }
    }
}
