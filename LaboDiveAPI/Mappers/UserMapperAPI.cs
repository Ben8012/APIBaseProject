using BLL.Models.Forms;
using API.Models.DTO.UserAPI;
using System.Security.Principal;
using System.Transactions;
using DAL.Models;
using BLL.Interfaces;
using API.Models.Forms.UserAPI;
using BLL.Models.DTO;
using DAL.Models.DTO;
using System.Data.Common;
using API.Models.DTO;

namespace API.Mappers
{
    public static class UserMapperAPI
    {

        internal static User ToUser(this UserBll userBll)
        {
            return new User()
            {
                Id = userBll.Id,
                Firstname = userBll.FirstName,
                Lastname = userBll.LastName,
                Email = userBll.Email,
                Phone = userBll.Phone,
                Role = userBll.Role,
                Birthdate = userBll.Birthdate,
                CreatedAt = userBll.CreatedAt,
                UpdatedAt = userBll.UpdatedAt,
                IsActive = userBll.IsActive,
                InsuranceId = userBll.InsuranceId,
                AdressId = userBll.AdressId

            };
        }


        internal static AddUserFormBll ToAddUserFromBll(this AddUserForm addUserFrom)
        {
            return new AddUserFormBll()
            {
                FirstName = addUserFrom.FirstName,
                LastName = addUserFrom.LastName,
                Email = addUserFrom.Email,
                Phone = addUserFrom.Phone,
                Birthdate = addUserFrom.Birthdate,
                InsuranceId = addUserFrom.InsuranceId,
                InsuranceNumber= addUserFrom.InsuranceNumber,
                AdressId = addUserFrom.AdressId,
                Password= addUserFrom.Password,
            };
        }


        internal static UpdateUserFormBll ToUpdateUserFormBll(this UpdateUserForm updateUserForm)
        {
            return new UpdateUserFormBll()
            {
                Id = updateUserForm.Id,
                FirstName = updateUserForm.FirstName,
                LastName = updateUserForm.LastName,
                Email = updateUserForm.Email,
                Phone = updateUserForm.Phone,
                Birthdate = updateUserForm.Birthdate,
                InsuranceId = updateUserForm.InsuranceId,
                InsuranceNumber = updateUserForm.InsuranceNumber,
                AdressId = updateUserForm.AdressId,

            };
        }

        internal static LoginFormBll ToLoginFormBll(this LoginForm loginForm)
        {
            return new LoginFormBll()
            {
                Email = loginForm.Email,
                Password = loginForm.Password
            };
        }

        internal static OrganisationByUser ToOrganisation(this DbDataReader reader)
        {
            return new OrganisationByUser()
            {
                UserId = (int)reader["user_id"],
                Name = (string)reader["name"],
                Level = (string)reader["level"],
                RefNunber = (string)reader["refNumber"],
                CreatedAt = (DateTime)reader["createdAt"],
                Picture = (string)reader["picture"]
            };

        }

    }
}
