
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Models.DTO;
using DAL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class UserMapperBll
    {

        // vers la BLL
        internal static UserBll ToUserBll(this UserDal userDal)
        {
            return new UserBll()
            {
                Id = userDal.Id,
                FirstName = userDal.FirstName,
                LastName = userDal.LastName,
                Email = userDal.Email,
                Phone = userDal.Phone,
                Role = userDal.Role,
                Birthdate = userDal.Birthdate,
                CreatedAt = userDal.CreatedAt,
                UpdatedAt = userDal.UpdatedAt,
                IsActive = userDal.IsActive,
                InsuranceId = userDal.InsuranceId,
                AdressId = userDal.AdressId
                
            };
        }

        // vers la DAL

        internal static AddUserFormDal ToAddUserFromDal(this AddUserFormBll addUserFromBll)
        {
            return new AddUserFormDal()
            {

                FirstName = addUserFromBll.FirstName,
                LastName = addUserFromBll.LastName,
                Email = addUserFromBll.Email,
                Birthdate = addUserFromBll.Birthdate,
                Password = addUserFromBll.Password,
            };
        }


        internal static UpdateUserFormDal ToUpdateUserFormDal(this UpdateUserFormBll updateUserFromBll)
        {
            return new UpdateUserFormDal()
            {
                Id = updateUserFromBll.Id,
                FirstName = updateUserFromBll.FirstName,
                LastName = updateUserFromBll.LastName,
                Email = updateUserFromBll.Email,
                //Phone = updateUserFromBll.Phone,
                Birthdate = updateUserFromBll.Birthdate,
                //InsuranceId = updateUserFromBll.InsuranceId,
                //InsuranceNumber = updateUserFromBll.InsuranceNumber,
                //AdressId = updateUserFromBll.AdressId,
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


