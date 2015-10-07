
using System.Data.Entity;
using HO2.Domain.DAL;
using HO2.Domain.Models;


namespace HO2Server.Tests.ObjectMothers
{
    public class GroupsBuilder
    {
        private FriendGroup _group = new FriendGroup();
        private IHO2Context _db;

        public GroupsBuilder(IHO2Context db)
        {
            _db = db;
        }

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

        public FriendGroup Build()
        {
            //_db.Set<FriendGroup>().Add(_group);
            //_db.Save();
            return _group;
        }
    }
}
