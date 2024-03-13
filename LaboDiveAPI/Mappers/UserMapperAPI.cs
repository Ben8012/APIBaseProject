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

        internal static Adress ToAdress(this AdressBll adressBll)
        {
            return new Adress()
            {
                Id = adressBll.Id,
                Number = adressBll.Number,
                Street = adressBll.Street,
                PostCode = adressBll.PostCode,
                City = adressBll.City,
                Country = adressBll.Country
            };

        }

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
                    Insurance = userBll.Insurance is null ? null : userBll.Insurance.ToInsurance(),
                    Adress = userBll.Adress is null ? null : userBll.Adress.ToAdress(),
                    Organisations = userBll.Organisations is null ? null : userBll.Organisations.Select(o => o.ToOrganisation()).ToList(),
                    Divelogs = userBll.Divelogs is null ? null : userBll.Divelogs.Select(d => d.ToDivelog()).ToList(),
                    Diveplaces = userBll.Diveplaces is null ? null : userBll.Diveplaces.Select(p => p.ToDiveplace()).ToList(),
                    Friends = userBll.Friends is null ? null :  userBll.Friends .Select(f => f.ToUser()).ToList(),
                    Clubs = userBll.Clubs is null ? null : userBll.Clubs.Select(c => c.ToClub()).ToList(),
                    Events = userBll.Events is null ? null : userBll.Events.Select(e => e.ToEvent()).ToList()

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
                //Phone = updateUserForm.Phone,
                Birthdate = updateUserForm.Birthdate,
                Photo = updateUserForm.Photo,
                //InsuranceId = updateUserForm.InsuranceId,
                //InsuranceNumber = updateUserForm.InsuranceNumber,
               // AdressId = updateUserForm.AdressId,

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
