﻿using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBll
    {
         IEnumerable<UserBll> GetAll();

        IEnumerable<UserBll> GetLikersByUserId(int id);
        IEnumerable<UserBll> GetFriendsUserId(int id);
        IEnumerable<UserBll> GetLikedsByUserId(int id);

         UserBll? GetById(int id);

         UserBll? Insert(AddUserFormBll form);

         UserBll? Update(UpdateUserFormBll form);

         int? Delete(int id);

        UserBll Login(LoginFormBll form);
        int? Enable(int id);

        int? Disable(int id);

        int? Like(int likerId, int likedId);
        int? UnLike(int likerId, int likedId);
        int? DeleteLike(int likerId, int likedId);
        UserBll Admin(int id);
        UserBll UnAdmin(int id);

        int? UpdateInsuranceDate(int id, string date);
        int? UpdateCertificatDate(int id, string date);


    }
}
