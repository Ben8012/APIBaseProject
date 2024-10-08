﻿using DAL.Models.DTO;
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

        IEnumerable<UserDal> GetLikersByUserId(int id);
        IEnumerable<UserDal> GetFriendsUserId(int id);
        IEnumerable<UserDal> GetLikedsByUserId(int id);

        UserDal? GetById(int id);

        UserDal? Insert(AddUserFormDal form);

        UserDal? Update(UpdateUserFormDal form);

        int? Delete(int id);

        UserDal Login(LoginFormDal form);
        int? Enable(int id);
        int? Disable(int id);

        int? Like(int likerId, int likedId);
        int? UnLike(int likerId, int likedId);

        int? DeleteLike(int likerId, int likedId);

        int? Admin(int id);
        int? UnAdmin(int id);

        int? UpdateInsuranceDate(int id, string date);
        int? UpdateCertificatDate(int id, string date);

    }
}
