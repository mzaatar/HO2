using HO2.Domain.DAL.Common;
using HO2.Domain.Models.Business;

namespace HO2Server.Controllers
{
    public class MatesController : BaseApiController<Mate>
    {
        public MatesController() : base( new GenericRepository<Mate>())
        {

        }
    }
}