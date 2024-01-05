using FluentValidation;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Service.Interface
{
    public interface IUserService : IBaseService<User>
    {
        UserModel Add(CreateUserModel inputModel);
        void Delete(int id);
        IEnumerable<UserModel> Get();
        UserModel GetById(int id);
        UserModel Update(UpdateUserModel inputModel);
    }
}
