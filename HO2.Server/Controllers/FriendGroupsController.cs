using HO2.Domain.DAL.Common;
using HO2.Domain.Models;

namespace HO2.Server.Controllers
{
    public class FriendGroupsController : BaseApiController<FriendGroup>
    {

        public FriendGroupsController() : base( new GenericRepository<FriendGroup>())
        {
            base.DataStore = new GenericRepository<FriendGroup>();
        }
    }
}