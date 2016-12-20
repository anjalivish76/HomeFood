using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFood.Authentication
{
    public class FormsAuthenticationProvider
    {
        #region Public methods

        /// <summary>
        /// sign in current user based on provided credentials
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <param name="token">token if any</param>
        /// <param name="branchName">branch id</param>
        /// <param name="userId">user id to be stored in session for DigiPass redirect</param>
        /// <param name="createPersistentCookie">true if necessary</param>
        /// <returns>authentication status</returns>
        //public AuthenticationStatus SignIn(string userName, string password,bool createPersistentCookie = false)
        //{
        //    userId = null;
        //    //var provider = new ServiceProvider();
        //    var status = AuthenticationStatus.Failed;
        //    //AuthenticationResultBo result = null;

        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionUtils.HandleServiceException(ex, ComponentName, Constants.ErrorCodes.SecurityServiceError, @"SignIn");
        //    }

        //    if (result != null)
        //    {
        //        status = result.Status;

        //        if (result.Status == AuthenticationStatus.Ok
        //             || result.Status == AuthenticationStatus.MustChangePassword)
        //        {
        //            //Check whether DigiPass is required or not and take action accordingly
        //            //var is2FaEnabled = result.UserInfo.User2FAEnabled && result.UserInfo.ExtendedInfo.Branch2FAEnabled;
        //            var is2FaEnabled = false;
        //            if (result.UserInfo.ExtendedInfo.Branch2FAEnabled && !result.UserInfo.ExtendedInfo.HoldInvoiceOnline)
        //            {
        //                is2FaEnabled = true;
        //            }
        //            else if (result.UserInfo.ExtendedInfo.Branch2FAEnabled && result.UserInfo.ExtendedInfo.HoldInvoiceOnline && result.UserInfo.Rights[47])
        //            {
        //                is2FaEnabled = true;
        //            }
        //            if (!is2FaEnabled)
        //            {
        //                BaseCacheManager.CleanupUserData(result.UserInfo.Id);
        //                FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        //                BaseCacheManager.SetLastSessionId(result.UserInfo.Id, HttpContext.Current.Session.SessionID);

        //                var userShortcutList = new List<UserShortcutBo>();
        //                var userShortcutFilteredList = new List<UserShortcutBo>();

        //                try
        //                {
        //                    // load shortcuts list
        //                    //userShortcutList = provider.CustomerCareClient.GetUserShortcuts(result.UserInfo.Id);

        //                    // load shortcuts filtered list 
        //                    //userShortcutFilteredList =
        //                    //    provider.CustomerCareClient.GetUserShortcutsFiltered(result.UserInfo.Id);
        //                }
        //                catch (Exception ex)
        //                {
        //                    ExceptionUtils.HandleServiceException(ex, ComponentName,
        //                        Constants.ErrorCodes.SecurityServiceError, "SignIn.GetUserShortcuts");
        //                }

        //                var transfastIdentity = new WebAppIdentity(result.UserInfo, userShortcutList,
        //                    userShortcutFilteredList);
        //                WebAppUtils.SessionManager[SessionKey.CurrentUser] = transfastIdentity;

        //                try
        //                {
        //                    //load company shortcuts filtered
        //                    //transfastIdentity.CompanyShortcutSettingsFiltered = provider.CustomerCareClient
        //                    //    .GetCompanyShortcuts(transfastIdentity.ExtendedInfo.CompanyId.Value);
        //                }
        //                catch (Exception ex)
        //                {
        //                    ExceptionUtils.HandleServiceException(ex, ComponentName,
        //                        Constants.ErrorCodes.SecurityServiceError,
        //                        "SignIn.GetCompanyShortcuts");
        //                }

        //                if (transfastIdentity.UserData != null
        //                    && !String.IsNullOrEmpty(transfastIdentity.UserData.DefaultLang))
        //                {
        //                    WebAppUtils.SessionManager[SessionKey.SelectedLanguage] =
        //                        transfastIdentity.UserData.DefaultLang;
        //                }
        //            }
        //            else
        //            {
        //                //DigiPass situation (2FA enabled)
        //                //status = AuthenticationStatus.RequiresDigiPass;
        //                status = AuthenticationStatus.RequiresDuoSecurity;
        //                userId = result.UserInfo.Id;
        //            }
        //        }
        //    }
        //    return status;
        //}

        #endregion
    }
}