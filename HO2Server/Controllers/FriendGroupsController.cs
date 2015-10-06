using HO2.Domain.DAL.Common;
using HO2.Domain.Models.Business;

namespace HO2Server.Controllers
{
    public class FriendGroupsController : BaseApiController<FriendGroup>
    {

        public FriendGroupsController() : base( new GenericRepository<FriendGroup>())
        {
            
        }
    }
}