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
using static System.Reflection.Metadata.BlobBuilder;

namespace BLL.Services
{
    public class UserBllService : IUserBll
    {
        private readonly ILogger _logger;
        private readonly IUserDal _userDal;
        private readonly IClubDal _clubDal;
        private readonly IDivelogDal _diveLogDal;
        private readonly IEventDal _eventDal;
        private readonly IDiveplaceDal _diveplaceDal;
        private readonly IAdressBll _adressBll;
        private readonly ITrainingDal _trainingDal;
        private readonly IOrganisationDal _organisationDal;
        private readonly IMessageDal _messageDal;

        public UserBllService(ILogger<UserBllService> logger,IMessageDal messageDal, IOrganisationDal organisationDal, ITrainingDal trainingDal, IUserDal userDal, IClubDal clubDal, IDivelogDal diveLogDal, IEventDal eventDal, IDiveplaceDal diveplaceDal, IAdressBll adressBll)
        {
            _userDal = userDal;
            _logger = logger;
            _clubDal = clubDal;
            _diveLogDal = diveLogDal;
            _eventDal = eventDal;
            _diveplaceDal = diveplaceDal;
            _adressBll = adressBll;
            _trainingDal = trainingDal;
            _organisationDal= organisationDal;
            _messageDal = messageDal;
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
                user.Email = "";
                user.Adress = user.AdressId == 0 ? null : _adressBll.GetById(user.AdressId);
                user.Clubs = _clubDal.GetClubsByUserId(user.Id).Select(c => c.ToClubBll()).ToList();
                foreach (var club in user.Clubs)
                {
                    club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
                }
                //user.Divelogs = _diveLogDal.GetDivelogByUserId(user.Id).Select(d => d.ToDivelogBll()).ToList();
                //user.Events = _eventDal.GetEventByUserId(user.Id).Select(e => e.ToEventBll()).ToList();
                user.Friends = GetFriendsUserId(user.Id).ToList();
                user.Likers = GetLikersByUserId(user.Id).ToList();
                user.Likeds = GetLikedsByUserId(user.Id).ToList();

              
                foreach (var liker in user.Likers)
                {
                    liker.Email = "";
                }
                foreach (var liked in user.Likeds)
                {
                    liked.Email = "";
                }

                user.Trainings = _trainingDal.GetTrainingsByUserId(user.Id).Select(t => t.ToTrainingBll()).ToList();
                foreach (var training in user.Trainings)
                {
                    training.Organisation = _organisationDal.GetById(training.OrganisationId).ToOrganisationBll();
                }
                //user.Diveplaces = _diveplaceDal.GetDiveplaceByUserId(user.Id).Select(d => d.ToDiveplaceBll()).ToList();
            }
            return users;
        }

        public UserBll? GetById(int id)
        {
            UserBll? user = _userDal.GetById(id)?.ToUserBll();
            user.Adress = user.AdressId == 0 ? null : _adressBll.GetById(user.AdressId);
            user.Clubs = _clubDal.GetClubsByUserId(user.Id).Select(c => c.ToClubBll()).ToList();
            foreach (var club in user.Clubs)
            {
                club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
            }
            //user.Divelogs = _diveLogDal.GetDivelogByUserId(user.Id).Select(d => d.ToDivelogBll()).ToList();
            //foreach (var divelog in user.Divelogs)
            //{
            //    divelog.User = _userDal.GetById(divelog.UserId)?.ToUserBll();
            //    divelog.Event = divelog.EventId == 0 ? null : _eventDal.GetById(divelog.EventId)?.ToEventBll();
            //}
            //user.Events = _eventDal.GetEventByUserId(user.Id).Select(e => e.ToEventBll()).ToList();
            user.Friends = GetFriendsUserId(user.Id).ToList();
            user.Likers = GetLikersByUserId(user.Id).ToList();
            user.Likeds = GetLikedsByUserId(user.Id).ToList();
            foreach (var friend in user.Friends)
            {
                friend.Email = "";
                friend.Messages = _messageDal.GetMessagesBetween(user.Id, friend.Id).Select(m => m.ToMessageBll()).ToList();
                foreach (var message in friend.Messages)
                {
                    message.Sender = _userDal.GetById(message.SenderId).ToUserBll();
                    message.Sender.Email = "";
                    message.Reciever = _userDal.GetById(message.RecieverId).ToUserBll();
                    message.Reciever.Email = "";
                }
                friend.Adress = friend.AdressId == 0 ? null : _adressBll.GetById(friend.AdressId);
                friend.Clubs = _clubDal.GetClubsByUserId(friend.Id).Select(c => c.ToClubBll()).ToList();
                foreach(var club in friend.Clubs)
                {
                    club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
                }
                friend.Divelogs = _diveLogDal.GetDivelogByUserId(friend.Id).Select(d => d.ToDivelogBll()).ToList();
                friend.Events = _eventDal.GetEventByUserId(friend.Id).Select(e => e.ToEventBll()).ToList();
                friend.Trainings = _trainingDal.GetTrainingsByUserId(friend.Id).Select(t => t.ToTrainingBll()).ToList();
                foreach (var training in friend.Trainings)
                {
                    training.Organisation = _organisationDal.GetById(training.OrganisationId).ToOrganisationBll();
                }
            }
            foreach (var liker in user.Likers)
            {
                liker.Email = "";
                liker.Trainings = _trainingDal.GetTrainingsByUserId(liker.Id).Select(t => t.ToTrainingBll()).ToList();
                foreach (var training in liker.Trainings)
                {
                    training.Organisation = _organisationDal.GetById(training.OrganisationId).ToOrganisationBll();
                }
            }
            foreach (var liked in user.Likeds)
            {
                liked.Email = "";
                liked.Trainings = _trainingDal.GetTrainingsByUserId(liked.Id).Select(t => t.ToTrainingBll()).ToList();
                foreach (var training in liked.Trainings)
                {
                    training.Organisation = _organisationDal.GetById(training.OrganisationId).ToOrganisationBll();
                }
            }

            user.Trainings = _trainingDal.GetTrainingsByUserId(user.Id).Select(t => t.ToTrainingBll()).ToList();
            foreach (var training in user.Trainings)
            {
                training.Organisation = _organisationDal.GetById(training.OrganisationId).ToOrganisationBll();
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
            UserBll? user = _userDal.Insert(form.ToAddUserFromDal())?.ToUserBll();
            user = GetById(user.Id);
            return user;
        }

        public UserBll? Update(UpdateUserFormBll form)
        {
            return _userDal.Update(form.ToUpdateUserFormDal())?.ToUserBll();   
        }

        public UserBll Login(LoginFormBll form)
        {
            UserBll? user = _userDal.Login(form.ToLoginFormDal()).ToUserBll();
            user = GetById(user.Id);
            return user;
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

        public IEnumerable<UserBll> GetFriendsUserId(int id)
        {
            return _userDal.GetFriendsUserId(id).Select(u => u.ToUserBll());
        }

        public IEnumerable<UserBll> GetLikersByUserId(int id)
        {
            return _userDal.GetLikersByUserId(id).Select(u => u.ToUserBll());
        }

        public IEnumerable<UserBll> GetLikedsByUserId(int id)
        {
            return _userDal.GetLikedsByUserId(id).Select(u => u.ToUserBll());
        }

        public int? DeleteLike(int likerId, int likedId)
        {
            return _userDal.DeleteLike(likerId, likedId);
        }

        public int? Admin(int id)
        {
            return _userDal.Admin(id);
        }

        public int? UnAdmin(int id)
        {
            return _userDal.UnAdmin(id);
        }

        public int? UpdateInsuranceDate(int id, string date)
        {
            return _userDal.UpdateInsuranceDate(id, date);
        }

        public int? UpdateCertificatDate(int id, string date)
        {
            return _userDal.UpdateCertificatDate(id, date);
        }
    }
}
