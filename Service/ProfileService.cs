using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System;
using Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using System.Linq;
using Domain.Enum;

namespace Service
{
    public class ProfileService : GenericService<Profile>, IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private List<string> _errors;


        public ProfileService(IProfileRepository profileRepository) : base(profileRepository)
        {
            _profileRepository = profileRepository;
        }



        private bool VerifyProfileExistsByName(Profile profile)
        {
            Expression<Func<Profile, bool>> filter = (Profile p) => p.Name.ToUpper() == profile.Name.ToUpper() && p.Id != profile.Id;
            var result = this.Get(filter, null, "");
            return (result?.Count() > 0) ? true : false;
        }

        private bool VerifyProfileCanBeChanged(Profile profile)
        {
            return (profile.Active.Equals(((int)GenericStatusEnum.Active).ToString())) ? true : false;
        }

        public bool VerifyProfileExists(Profile profile)
        {
            _errors = new List<string>();

            if (VerifyProfileExistsByName(profile))
                _errors.Add("O nome do perfil não deve ser duplicado.");
            return _errors.Count() != 0;
        }

        public List<Permission> GetPermissions(int idProfile)
        {
            return _profileRepository.GetPermissions(idProfile);
        }

        public new List<string> Insert(Profile profile)
        {
            if (!this.VerifyProfileExists(profile))
                this._profileRepository.Insert(profile);
            return this._errors;
        }

        public new List<string> Update(Profile profile)
        {

            if (!this.VerifyProfileExists(profile))
            {
                this._profileRepository.Update(profile);
            }

            return this._errors;
        }
    }
}
