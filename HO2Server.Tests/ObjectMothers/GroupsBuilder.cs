using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HO2Server.DAL;
using HO2Server.Models.Business;

namespace HO2Server.Tests.ObjectMothers
{
    public class GroupsBuilder
    {
        private FriendGroup _group = new FriendGroup();
        private IHO2Context db;


        public GroupsBuilder WithDefault()
        {
            return this
                .WithId(1)
                .WithName("Default Group")
                .WithDetails("Default Details");
        }

        public GroupsBuilder WithId(int id)
        {
            _group.FriendGroupId = id;
            return this;
        }

        public GroupsBuilder WithName(string name)
        {
            _group.FriendGroupName = name;
            return this;
        }

        public GroupsBuilder WithDetails(string details)
        {
            _group.FriendGroupDetails = details;
            return this;
        }

        public GroupsBuilder WithMateAdmin(Mate mate)
        {
            _group.FriendGroupAdminUser = mate;
            return this;
        }

        public FriendGroup build()
        {
            return _group;
        }
    }
}
