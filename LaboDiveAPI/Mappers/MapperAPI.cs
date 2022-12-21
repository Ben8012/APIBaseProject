using BLL.Models.DTO.User;
using BLL.Models.Forms;
using API.Models.DTO.UserAPI;
using API.Models.Forms;
using System.Security.Principal;
using System.Transactions;

namespace API.Mappers
{
    public static class MapperAPI
    {

        internal static User ToUser(this UserBll userBll)
        {
            return new User()
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


        internal static AddUserFormBll ToAddUserFromBll(this AddUserForm addUserFrom)
        {
            return new AddUserFormBll()
            {

                FirstName = addUserFrom.FirstName,
                LastName = addUserFrom.LastName,
                Birthdate = addUserFrom.Birthdate,
                Email = addUserFrom.Email,
                Password = addUserFrom.Password
            };
        }


        internal static UpdateUserFormBll ToUpdateUserFormBll(this UpdateUserForm updateUserForm)
        {
            return new UpdateUserFormBll()
            {
                Id = updateUserForm.Id,
                FirstName = updateUserForm.FirstName,
                LastName = updateUserForm.LastName,
                Birthdate = updateUserForm.Birthdate,
                Email = updateUserForm.Email,

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

    }
}
