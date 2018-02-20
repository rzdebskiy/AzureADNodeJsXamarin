using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using MFATest;
using System.Threading.Tasks;
//using Android.Webkit;
using Java.Net;

[assembly: Dependency(typeof(MFATestPCL.Droid.Helper.Authenticator))]
namespace MFATestPCL.Droid.Helper
{
    public class Authenticator : IAuthenticator
    {
        CookieManager cookieManager;

        async Task<AuthenticationResult> IAuthenticator.Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            if (cookieManager == null)
            {
                cookieManager = new CookieManager();
                cookieManager.SetCookiePolicy(CookiePolicy.AcceptAll);
                CookieHandler.Default = cookieManager;
            };

            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            var uri = new Uri(returnUri);
            var platformParams = new PlatformParameters((Activity)Forms.Context);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
            return authResult;
        }

        void IAuthenticator.ClearAllCookies()
        {
            Android.Webkit.CookieManager cookieManager = Android.Webkit.CookieManager.Instance;
            cookieManager.RemoveAllCookie();
            cookieManager.Flush();
        }

        IEnumerable<GeneralCookie> IAuthenticator.GetCookies()
        {

            ICookieStore cookieStore = cookieManager.CookieStore;
            if (cookieStore.Cookies.Count > 0)
                foreach (var cookie in cookieStore.Cookies)
                {
                    yield return new GeneralCookie { Value = cookie.Value, HasExpired = cookie.HasExpired, MaxAge = cookie.MaxAge, Path = cookie.Path, Portlist = cookie.Portlist, Secure = cookie.Secure, Version = cookie.Version };
                }
        }
    }

}