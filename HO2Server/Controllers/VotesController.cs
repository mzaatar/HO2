using HO2Server.DAL.Common;
using HO2Server.Models.Business;

namespace HO2Server.Controllers
{
    public class VotesController : BaseApiController<Vote>
    {
        public VotesController() : base( new GenericRepository<Vote>())
        {

        }
    }
}