using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HO2Server.Models.Business;

namespace HO2Server.Tests.ObjectMothers
{
    public class GroupsBuilder
    {
        FriendGroup _group = new FriendGroup();

        public GroupsBuilder withDefault()
        {
            return this
                .withId(1)
                .withName("Default Group")
                .withDetails("Default Details");
        }

        public GroupsBuilder withId(int id)
        {
            _group.FriendGroupId = id;
            return this;
        }

        public GroupsBuilder withName(string name)
        {
            _group.FriendGroupName = name;
            return this;
        }

        public GroupsBuilder withDetails(string details)
        {
            _group.FriendGroupDetails = details;
            return this;
        }

        public GroupsBuilder withMateAdmin(Mate mate)
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
