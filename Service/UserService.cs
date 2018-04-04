using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        private List<string> _errors;

        public UserService(IUserRepository userRepository): base(userRepository)
        {
            _userRepository = userRepository;
        }

        public List<string> Delete(User user)
        {
            _errors = new List<string>();
            if (!VerifyUserCanBeChanged(user))
            {
                _errors.Add("Não é possível alterar este usuário");
                return _errors;
            }
            user.Active = ((int)GenericStatusEnum.Inactive).ToString();
            _userRepository.Update(user);
            return _errors;
        }

        public bool VerifyUserExists(User user)
        {
            _errors = new List<string>();

            if (VerifyUserExistsByCpf(user))
            {
                _errors.Add("CPF já cadastrado para a empresa selecionada.");
            }

            if (VerifyUserExistsByEmail(user))
            {
                _errors.Add("E-mail já cadastrado.");
            }
            
            return _errors.Count() != 0;
        }

        private bool VerifyUserCanBeChanged(User user)
        {
            Expression<Func<User, bool>> filter = (User p) => p.Active.Equals("1") && p.Id == user.Id;
            var result = this.Get(filter, null, "");
            return (result?.Count() > 0);
        }

        private bool VerifyUserExistsByEmail(User user)
        {
            Expression<Func<User, bool>> filter = (User p) => p.Email.ToLower().Equals(user.Email.ToLower()) && p.Id != user.Id;
            var result = this.Get(filter, null, "");
            return (result?.Count() > 0);
        }

        private bool VerifyUserExistsByCpf(User user)
        {
            Expression<Func<User, bool>> filter = (User p) => p.Cpf.ToLower().Equals(user.Cpf.ToLower()) && p.Id != user.Id ;
            var result = this.Get(filter, null, "");
            return (result?.Count() > 0);
        }

        public List<string> UpdateProfile(User user)
        {
            _errors = new List<string>();
            if (!VerifyUserCanBeChanged(user))
            {
                _errors.Add("Não é possível alterar este usuário");
                return _errors;
            }
            if (!VerifyUserExists(user))
            {
                var userChanged = _userRepository.GetById(user.Id);
                userChanged.IdProfile = user.IdProfile;
                userChanged.Email = user.Email;
                userChanged.Cpf = user.Cpf;
                userChanged.Name = user.Name;
                userChanged.Username = user.Email;
                _userRepository.Update(userChanged);
            }
            return _errors;
        }
    }
}
