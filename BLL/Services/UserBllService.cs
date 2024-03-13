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
using DAL.Models.DTO;

namespace BLL.Services
{
    public class UserBllService : IUserBll
    {
        private readonly ILogger _logger;
        private readonly IUserDal _userDal;
        private readonly IClubDal _clubDal;
        private readonly IDivelogDal _diveLogDal;
        private readonly IEventDal _eventDal;
        private readonly IOrganisationDal _organisationDal;
        private readonly IDiveplaceDal _diveplaceDal;

        public UserBllService(ILogger<UserBllService> logger, IUserDal userDal, IClubDal clubDal, IDivelogDal diveLogDal, IEventDal eventDal, IOrganisationDal organisationDal, IDiveplaceDal diveplaceDal)
        {
            _userDal = userDal;
            _logger = logger;
            _clubDal = clubDal;
            _diveLogDal = diveLogDal;
            _eventDal = eventDal;
            _organisationDal = organisationDal;
            _diveplaceDal = diveplaceDal;
        }

        public int? Delete(int id)
        {
            return _userDal.Delete(id);
        }

        public IEnumerable<UserBll> GetAll()
        {
            List<UserBll> users = _userDal.GetAll().Select(u => u.ToUserBll()).ToList();
            foreach (UserBll user in users)
            {
                user.Adress = GetAdressById(user.AdressId);
                user.Clubs = _clubDal.GetClubsByUserId(user.Id).Select(c => c.ToClubBll()).ToList();
                user.Divelogs = _diveLogDal.GetDivelogByUserId(user.Id).Select(d => d.ToDivelogBll()).ToList();
                user.Events = _eventDal.GetEventByUserId(user.Id).Select(e => e.ToEventBll()).ToList();
                user.Friends = _userDal.GetContactByUserId(user.Id).Select(u => u.ToUserBll()).ToList();
                user.Organisations = _organisationDal.GetOrganisationByUserId(user.Id).Select(o => o.ToOrganisationBll()).ToList();
                user.Diveplaces = _diveplaceDal.GetDiveplaceByUserId(user.Id).Select(d => d.ToDiveplaceBll()).ToList();
            }
            return users;
        }

        public UserBll? GetById(int id)
        {
            UserBll? user = _userDal.GetById(id)?.ToUserBll();
            user.Adress = GetAdressById(user.AdressId);
            user.Clubs = _clubDal.GetClubsByUserId(user.Id).Select(c => c.ToClubBll()).ToList();
            user.Divelogs = _diveLogDal.GetDivelogByUserId(user.Id).Select(d => d.ToDivelogBll()).ToList();
            foreach (var divelog in user.Divelogs)
            {
                //divelog.User = _userDal.GetById(divelog.UserId)?.ToUserBll();
                divelog.Event = divelog.EventId == 0 ? null : _eventDal.GetById(divelog.EventId)?.ToEventBll();
            }
            user.Events = _eventDal.GetEventByUserId(user.Id).Select(e => e.ToEventBll()).ToList();
            user.Friends = _userDal.GetContactByUserId(user.Id).Select(u => u.ToUserBll()).ToList();
            foreach (var friend in user.Friends)
            {
                friend.Adress = GetAdressById(friend.AdressId);
                friend.Clubs = _clubDal.GetClubsByUserId(user.Id).Select(c => c.ToClubBll()).ToList();
                foreach(var club in friend.Clubs)
                {
                    club.Adress = club.AdressId == 0 ? null : GetAdressById(user.AdressId);
                }
                friend.Divelogs = _diveLogDal.GetDivelogByUserId(user.Id).Select(d => d.ToDivelogBll()).ToList();
                friend.Events = _eventDal.GetEventByUserId(user.Id).Select(e => e.ToEventBll()).ToList();
              

                friend.Organisations = _organisationDal.GetOrganisationByUserId(user.Id).Select(o => o.ToOrganisationBll()).ToList();
               
                friend.Friends = null;
            }
            user.Organisations = _organisationDal.GetOrganisationByUserId(user.Id).Select(o => o.ToOrganisationBll()).ToList();
            foreach(var organisation in user.Organisations)
            {
                organisation.Adress = GetAdressById(organisation.AdressId);
            }
            //user.Diveplaces = _diveplaceDal.GetDiveplaceByUserId(user.Id).Select(d => d.ToDiveplaceBll()).ToList();
            //foreach (var diveplace in user.Diveplaces)
            //{
            //    diveplace.Adress = diveplace.AdressId == 0 ? null : _userDal.GetAdressById(diveplace.AdressId).ToAdressBll();
            //}
            return user;
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

        public int? Disable(int id)
        {
            return _userDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _userDal.Enable(id); 
        }

        public int? Like(int likerId, int likedId)
        {
            return _userDal.Like( likerId, likedId);
        }

        public int? UnLike(int likerId, int likedId)
        {
            return _userDal.UnLike( likerId, likedId);
        }

        public IEnumerable<UserBll> GetContactById(int id)
        {
            return _userDal.GetContactByUserId(id).Select(u => u.ToUserBll());
        }

        public AdressBll GetAdressById(int id)
        {
            return _userDal.GetAdressById(id).ToAdressBll();
        }
    }
}
