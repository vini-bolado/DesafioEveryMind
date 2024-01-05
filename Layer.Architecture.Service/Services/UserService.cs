using AutoMapper;
using FluentValidation;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layer.Architecture.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }


        public UserModel Add(CreateUserModel inputModel)
        {
            var entity = _mapper.Map<User>(inputModel);

            Validate(entity, Activator.CreateInstance<UserValidator>());
            _userRepository.Insert(entity);

            UserModel outputModel = _mapper.Map<UserModel>(entity);

            return outputModel;
        }

        public void Delete(int id) => _userRepository.Delete(id);

        public IEnumerable<UserModel> Get()
        {
            var entities = _userRepository.Select();

            var outputModels = entities.Select(s => _mapper.Map<UserModel>(s));

            return outputModels;
        }

        public UserModel GetById(int id)
        {
            var entity = _userRepository.Select(id);

            var outputModel = _mapper.Map<UserModel>(entity);

            return outputModel;
        }

        public UserModel Update(UpdateUserModel inputModel)
        {
            var entity = _mapper.Map<User>(inputModel);

            Validate(entity, Activator.CreateInstance<UserValidator>());
            _userRepository.Update(entity);

            var outputModel = _mapper.Map<UserModel>(entity);

            return outputModel;
        }
    }
}
