using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFATest
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
        IEnumerable<GeneralCookie> GetCookies();
        void ClearAllCookies();
    }

    public class GeneralCookie
    {
        //
        // Summary:
        //     Returns the Secure attribute.
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the Secure attribute.
        //     Set method documentation [Android Documentation] Sets the Secure attribute of
        //     this cookie.
        public bool Secure { get; set; }
        //
        // Summary:
        //     Returns the Port attribute, usually containing comma-separated port numbers.
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the Port attribute,
        //     usually containing comma-separated port numbers. A null port indicates that the
        //     cookie may be sent to any port. The empty string indicates that the cookie should
        //     only be sent to the port of the originating request.
        //     Set method documentation [Android Documentation] Set the Port attribute of this
        //     cookie.
        public string Portlist { get; set; }
        //
        // Summary:
        //     Returns the Path attribute.
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the Path attribute.
        //     This cookie is visible to all subpaths.
        //     Set method documentation [Android Documentation] Set the Path attribute of this
        //     cookie. HTTP clients send cookies to this path and its subpaths.
        public string Path { get; set; }
        //
        // Summary:
        //     Returns the name of this cookie.
        //
        // Remarks:
        //     Returns the name of this cookie.
        //     [Android Documentation]
        public string Name { get; }
        //
        // Summary:
        //     Returns the Max-Age attribute, in delta-seconds.
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the Max-Age attribute,
        //     in delta-seconds.
        //     Set method documentation [Android Documentation] Sets the Max-Age attribute of
        //     this cookie.
        public long MaxAge { get; set; }

        //
        // Summary:
        //     Returns true if this cookie's Max-Age is 0.
        //
        // Remarks:
        //     Returns true if this cookie's Max-Age is 0.
        //     [Android Documentation]
        public bool HasExpired { get; set; }
  
        //
        // Summary:
        //     Returns the value of this cookie.
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the value of this cookie.
        //     Set method documentation [Android Documentation] Sets the opaque value of this
        //     cookie.
        public string Value { get; set; }
        //
        // Summary:
        //     Returns the version of this cookie.
        //
        // Exceptions:
        //   T:Java.Lang.IllegalArgumentException:
        //     if v is neither 0 nor 1
        //
        // Remarks:
        //     Get method documentation [Android Documentation] Returns the version of this
        //     cookie.
        //     Set method documentation [Android Documentation] Sets the Version attribute of
        //     the cookie.
        public int Version { get; set; }
    }
}
