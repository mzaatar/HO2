
using HO2Server.Controllers;
using HO2Server.DAL.Common;
using HO2Server.Models.Business;
using Xunit;

namespace HO2Server.Tests.Controllers
{
    public class MateControllerTest
    {
        [Fact]
        public void GetAllMatesReturnsEverythingInRepository()
        {
            //// Arrange
            //var allMates = new[] {
            //    new Mate  { MateId = 1,Email = "Moahemd.Zaatar@gmail.com" , FirstName = "Moahmed", LastName = "Zaatar"},
            //     new Mate  { MateId = 2,Email = "mzaatar@outlook.com" , FirstName = "Hesham", LastName = "Ahmed"}
            //};

            //var repoStub = NSubstitute.Substitute.For<IGenericRepository<Mate>>();
            //foreach (var mate in allMates)
            //{
            //    repoStub.Insert(mate);
            //}
            //var controller = new BaseApiController<Mate>(repoStub);
            
            //// Act
            //var result = controller.Get();

            //// Assert
            //Assert.Same(allMates, result);
        }

        [Fact]
        public void GetMateByIdReturnsItFormReposirtory()
        {
            //// Arrange
            //var mate = new ObjectMothers.MateBuilder()
            //    .withDefault().build();

            //var repoStub = NSubstitute.Substitute.For<IGenericRepository<Mate>>();
            //repoStub.Insert(mate);
            //var controller = new BaseApiController<Mate>(repoStub);
            
            //// Act
            //var result = controller.Get(1);

            //// Assert
            //Assert.Same(mate, result);
        }


        [Fact]
        public void PostMateAndCheckTheReposirtory()
        {
            //// Arrange
            //var mate = new ObjectMothers.MateBuilder()
            //    .withDefault().build();

            //var repoStub = NSubstitute.Substitute.For<IGenericRepository<Mate>>();
            //var controller = new BaseApiController<Mate>(repoStub);
            
            //// Act
            //controller.Post(mate);
            //var result = controller.Get(1);

            //// Assert
            //Assert.Same(mate, result);
        }
    }
}
