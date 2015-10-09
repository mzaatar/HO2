using HO2.Domain.DAL.Common;
using HO2.Domain.Models;

namespace HO2.Server.Controllers
{
    public class MatesController : BaseApiController<Mate>
    {
        public MatesController() : base( new GenericRepository<Mate>())
        {

        }
    }
}