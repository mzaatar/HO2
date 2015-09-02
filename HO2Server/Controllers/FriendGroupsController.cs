using HO2Server.Models.Business;
using HO2Server.DAL.Common;

namespace HO2Server.Controllers
{
    public class FriendGroupsController : BaseApiController<FriendGroup>
    {

        public FriendGroupsController() : base( new GenericRepository<FriendGroup>())
        {
            
        }
    }
}