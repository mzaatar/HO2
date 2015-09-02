using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HO2Server.Controllers;
using HO2Server.DAL.Common;
using HO2Server.Models.Business;
using NSubstitute;
using Xunit;

namespace HO2Server.Tests.DAL
{
    public class GenericRepositoryTest
    {
        [Fact]
        public void InsertMateAndCheckIfItIsRecieved()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder().withDefault().build();

            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            
            // Act
            repoStub.Insert(mate);
            
            
            // Assert
            repoStub.Received().Insert(mate);
        }

        [Fact]
        public void InsertMateAndRetrieveIt()
        {
            // Arrange
            var mate = new ObjectMothers.MatesBuilder().withDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();

            // Act
            repoStub.Insert(mate);

            // Assert
            repoStub.Get(s => s.MateId == mate.MateId).Returns(mate);
            repoStub.GetById(mate.MateId).Returns(mate);
            repoStub.GetFirst(s=>s.MateId == mate.MateId).Returns(mate);
            repoStub.GetSingle(s => s.MateId == mate.MateId).Returns(mate);
        }

        [Fact]
        public void InsertTwoMateAndCheckIfTheyAreRecieved()
        {
            // Arrange
            var allMates = new List<Mate>();
            allMates.Add(new ObjectMothers.MatesBuilder().withDefault().build());
            allMates.Add(new ObjectMothers.MatesBuilder()
                .withEmail("mzaatar@outlook.com")
                .withFristName("Mohamed")
                .withLastName("Gerg")
                .withId(2)
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

        [Fact]
        public void DeleteExistedMateReturnTrue()
        {
            var mate = new ObjectMothers.MatesBuilder().withDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();

            // Act
            repoStub.DbSet.Add(mate);

            // Assert
            repoStub.Delete(mate).Returns(true);
            repoStub.Delete(mate.MateId).Returns(true);
            repoStub.Delete(s=>s.MateId == 1).Returns(true);

        }


        [Fact]
        public void UpdateExistedMateAndCheckChanges()
        {
            var mate = new ObjectMothers.MatesBuilder().withDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            repoStub.DbSet.Add(mate);
            mate.LastName = "Davids";

            // Act
            repoStub.Update(mate);

            // Assert
            repoStub.Received().Update(mate);

        }

        [Fact]
        public void SetDbSetWithObjectAndCheckIfExits()
        {
            var mate = new ObjectMothers.MatesBuilder().withDefault().build();
            var repoStub = Substitute.For<IGenericRepository<Mate>>();
            repoStub.DbSet.Add(mate);

            // Act
            //repoStub.Exists(mate);

            // Assert
            repoStub.Exists(mate).Returns(true);

        }

        [Fact]
        public void GetGroupWithAdminAndCheckIfItIsRecieved()
        {
            //// Arrange
            //var mate = new ObjectMothers.MatesBuilder()
            //    .withDefault()
            //    .build();
            //var group = new ObjectMothers.GroupsBuilder()
            //    .withDefault()
            //    .withMateAdmin(mate)
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
