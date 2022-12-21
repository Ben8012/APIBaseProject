
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using DAL.Models;
using DAL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    internal static class MapperBll
    {

        // vers la BLL
        internal static UserBll ToUserBll(this UserDal userBll)
        {
            return new UserBll()
            {
                Id = userBll.Id,
                FirstName = userBll.FirstName,
                LastName = userBll.LastName,
                Birthdate = userBll.Birthdate,
                Email = userBll.Email,
                CreatedAt = userBll.CreatedAt,
                UpdatedAt = userBll.UpdatedAt,
            };
        }

    
        // vers la DAL

        internal static AddUserFormDal ToAddUserFromDal(this AddUserFormBll addUserFromBll)
        {
            return new AddUserFormDal()
            {
               
                FirstName = addUserFromBll.FirstName,
                LastName = addUserFromBll.LastName,
                Birthdate = addUserFromBll.Birthdate,
                Email = addUserFromBll.Email,
                Password = addUserFromBll.Password
            };
        }


        internal static UpdateUserFormDal ToUpdateUserFormDal(this UpdateUserFormBll addUserFromBll)
        {
            return new UpdateUserFormDal()
            {
                Id = addUserFromBll.Id,
                FirstName = addUserFromBll.FirstName,
                LastName = addUserFromBll.LastName,
                Birthdate = addUserFromBll.Birthdate,
                Email = addUserFromBll.Email
            };
        }


        internal static LoginFormDal ToLoginFormDal(this LoginFormBll loginFormBll)
        {
            return new LoginFormDal()
            {
                Email = loginFormBll.Email, 
                Password = loginFormBll.Password
            };
        }

    }
}


