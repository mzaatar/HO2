using HO2Server.DAL.Common;
using HO2Server.Models.Business;

namespace HO2Server.Controllers
{
    public class MatesController : BaseApiController<Mate>
    {
        public MatesController() : base( new GenericRepository<Mate>())
        {

        }
    }
}