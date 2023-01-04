using DAL.Models.DTO;
using DAL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        IEnumerable<UserDal> GetAll();

        UserDal? GetById(int id);

        UserDal? Insert(AddUserFormDal form);

        UserDal? Update(UpdateUserFormDal form);

        int? Delete(int id);

        UserDal Login(LoginFormDal form);


    }
}
