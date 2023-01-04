using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using BLL.Interfaces;
using DAL.Interfaces;
using BLL.Models.Forms;
using BLL.Mappers;
using BLL.Models.DTO;

namespace BLL.Services
{
    public class UserBllService : IUserBll
    {
        private readonly ILogger _logger;
        private readonly IUserDal _userDal;

        public UserBllService(ILogger<UserBllService> logger, IUserDal userDal)
        {
            _userDal = userDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _userDal.Delete(id);
        }

        public IEnumerable<UserBll> GetAll()
        {
            return _userDal.GetAll().Select(u => u.ToUserBll());
        }

        public UserBll? GetById(int id)
        {
            return _userDal.GetById(id)?.ToUserBll();
        }

        public UserBll? Insert(AddUserFormBll form)
        {
            return _userDal.Insert(form.ToAddUserFromDal())?.ToUserBll();
        }

        public UserBll? Update(UpdateUserFormBll form)
        {
            return _userDal.Update(form.ToUpdateUserFormDal())?.ToUserBll();   
        }

        public UserBll Login(LoginFormBll form)
        {
            return _userDal.Login(form.ToLoginFormDal()).ToUserBll();
        }
    }
}
