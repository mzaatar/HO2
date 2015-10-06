using System.Collections.Generic;
using System.Linq;
using HO2Server.DAL.Common;
using HO2Server.Models.Business;
using NUnit.Framework;
using HO2Server.DAL;
using NSubstitute;
using Shouldly;

namespace HO2Server.Tests.DAL
{
    [TestFixture]
    public class GenericRepositoryTest
    {
        private HO2Context db;
        [SetUp]
        public void Init()
        {
            db = new HO2Context("HO2Context.Test");
        }

        [Test]
        public void Insert_mate_then_it_should_received()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(db).WithDefault().build();

            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            
            // Act
            repoStub.Insert(mate);
            
            // Assert
            repoStub.Received().Insert(mate);
            repoStub.ContextCount().ShouldBe(1);
        }

        [Test]
        public void InsertMateAndRetrieveIt()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder(db).WithDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();

            // Act
            repoStub.Insert(mate);

            // Assert
            repoStub.Get(s => s.MateId == mate.MateId).Returns(mate);
            repoStub.GetById(mate.MateId).Returns(mate);
            repoStub.GetFirst(s=>s.MateId == mate.MateId).Returns(mate);
            repoStub.GetSingle(s => s.MateId == mate.MateId).Returns(mate);
        }

        [Test]
        public void InsertTwoMateAndCheckIfTheyAreRecieved()
        {
            // Arrange
            var allMates = new List<Mate>();
            allMates.Add(new ObjectMothers.MatesBuilder(db).WithDefault().build());
            allMates.Add(new ObjectMothers.MatesBuilder(db)
                .WithEmail("mzaatar@outlook.com")
                .WithFristName("Mohamed")
                .WithLastName("Gerg")
                .WithId(2)
                .build());
            var repoStub = Substitute.For<IGenericRepository<Mate>>();

            // Act
            repoStub.InsertMany(allMates);
            
            // Assert
            repoStub.Received().InsertMany(allMates);
            repoStub.GetMany(s => s.FirstName == allMates[0].FirstName).Returns(allMates);
            repoStub.GetManyQueryable(s => s.FirstName == allMates[0].FirstName).Returns(allMates.AsQueryable());
            repoStub.Get().Returns(allMates);
            repoStub.ContextCount().Returns(2);
        }

        [Test]
        public void DeleteExistedMateReturnTrue()
        {
            var mate = new ObjectMothers.MatesBuilder(db).WithDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();

            // Act
            repoStub.DbSet.Add(mate);

            // Assert
            repoStub.Delete(mate).Returns(true);
            repoStub.Delete(mate.MateId).Returns(true);
            repoStub.Delete(s=>s.MateId == 1).Returns(true);

        }


        [Test]
        public void UpdateExistedMateAndCheckChanges()
        {
            var mate = new ObjectMothers.MatesBuilder(db).WithDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            repoStub.DbSet.Add(mate);
            mate.LastName = "Davids";

            // Act
            repoStub.Update(mate);

            // Assert
            repoStub.Received().Update(mate);

        }

        [Test]
        public void SetDbSetWithObjectAndCheckIfExits()
        {
            var mate = new ObjectMothers.MatesBuilder(db).WithDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            repoStub.DbSet.Add(mate);

            // Act
            //repoStub.Exists(mate);

            // Assert
            repoStub.Exists(mate).Returns(true);

        }

        [Test]
        public void GetGroupWithAdminAndCheckIfItIsReceived()
        {
            //// Arrange
            //var mate = new ObjectMothers.MatesBuilder()
            //    .WithDefault()
            //    .build();
            //var group = new ObjectMothers.GroupsBuilder()
            //    .WithDefault()
            //    .WithMateAdmin(mate)
            //    .build();

            //var repoStub = Substitute.For<IGenericRepository<FriendGroup>>();
            //repoStub.DbSet.Add(group);

            //// Act
            //var result = repoStub.GetWithInclude(s => s.FriendGroupId == group.FriendGroupId, "Mate");


            //// Assert
            //result.Received().FirstOrDefault().Mates;
        }
    }
}
