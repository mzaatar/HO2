
using NUnit.Framework;

namespace HO2Server.Tests.Controllers
{
    [TestFixture]
    public class MateControllerTest
    {
        [Test]
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

        [Test]
        public void GetMateByIdReturnsItFormReposirtory()
        {
            //// Arrange
            //var mate = new ObjectMothers.MateBuilder()
            //    .WithDefault().build();

            //var repoStub = NSubstitute.Substitute.For<IGenericRepository<Mate>>();
            //repoStub.Insert(mate);
            //var controller = new BaseApiController<Mate>(repoStub);
            
            //// Act
            //var result = controller.Get(1);

            //// Assert
            //Assert.Same(mate, result);
        }


        [Test]
        public void PostMateAndCheckTheRepository()
        {
            //// Arrange
            //var mate = new ObjectMothers.MateBuilder()
            //    .WithDefault().build();

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
