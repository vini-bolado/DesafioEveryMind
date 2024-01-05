using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Layer.Architeture.Configuracao
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateUserModel, User>().ReverseMap();
            CreateMap<UpdateUserModel, User>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap(); 
        }
    }
}
