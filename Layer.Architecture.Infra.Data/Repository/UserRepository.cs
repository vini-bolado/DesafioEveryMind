using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private readonly MyContext _myContext;

        public UserRepository(MyContext myContext) : base (myContext)
        {
            _myContext = myContext;
        }
    }
}
