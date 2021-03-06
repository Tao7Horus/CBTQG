using System;
using System.Web.Security;
using Business.Entities.Domain;
namespace Module.Framework.Common

{
    public class CustomMembershipProvider : MembershipProvider
    {
        
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            var user = GetUser(username, true);

            if (user == null)
            {
                //var userObj = new User { NameUser = username, UserEmailAddress = email };
                //var membershipObj = new webpages_Membershipss { Password = GetMd5Hash(password), PasswordSalt = "", PasswordFailuresSinceLastSuccess = 0, IsConfirmed = true, CreateDate = DateTime.Now, PasswordChangedDate = DateTime.Now };
                //var userQuery = new UserQuery();
                //userQuery.AddUser(userObj, membershipObj);

                status = MembershipCreateStatus.Success;

                return GetUser(username, true);
            }
            status = MembershipCreateStatus.DuplicateUserName;

            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
            //var usersContext = new UsersContext();
            //var user = usersContext.GetUser(username);
            //if (user != null)
            //{
            //    var memUser = new MembershipUser("CustomMembershipProvider", username, user.UserId, user.UserEmailAddress,
            //                                                string.Empty, string.Empty,
            //                                                true, false, DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.Now, DateTime.Now);
            //    return memUser;
            //}
            //return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            UsersServiceClient _UsersSrv = new UsersServiceClient();
            LoginParam model = new LoginParam();
            model.UserName = username;
            model.Password = password;
            var temp = _UsersSrv.ValidateUser(model);
            if (temp != null && temp.Data!=null&& temp.Data.resultObject==1)
            {
                return true;
            }
            return false;

        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new System.Security.Cryptography.
                RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        //public static string GetMd5Hash(string value)
        //{
        //    var md5Hasher = MD5.Create();
        //    var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        //    var sBuilder = new StringBuilder();
        //    for (var i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();
        //}
        //public static string EncodePassword(string pass, string salt)
        //{
        //    var bytes = Encoding.Unicode.GetBytes(pass);
        //    var src = Convert.FromBase64String(salt);
        //    var md5Hasher = MD5.Create();
        //    var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pass + salt));
        //    return Convert.ToBase64String(data);
        //}
    }
}