﻿using HO2.Domain.DAL.Common;
using HO2.Domain.Models;

namespace HO2Server.Controllers
{
    public class VotesController : BaseApiController<Vote>
    {
        public VotesController() : base( new GenericRepository<Vote>())
        {

        }
    }
}