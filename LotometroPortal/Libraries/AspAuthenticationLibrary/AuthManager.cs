using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace LotometroPortal.Libraries.AspAuthenticationLibrary
{
    public static class AuthManager
    {
        //private static ClaimsIdentity Identity;// { get; private set; }

        //private static ClaimsPrincipal Principal;// { get; private set; }

        //private static AuthenticationProperties Properties; //{ get; private set; }

        public static ClaimsPrincipal GetPrincipalWithCookieName(int id, string name, string role, string email, string cookieName)
        {
            ClaimsIdentity Identity = new ClaimsIdentity(cookieName);
            Identity.AddClaim(new Claim(ClaimTypes.Sid, id.ToString()));
            Identity.AddClaim(new Claim(ClaimTypes.Name, name));
            Identity.AddClaim(new Claim(ClaimTypes.Role, role));
            Identity.AddClaim(new Claim(ClaimTypes.Email, email));

            return new ClaimsPrincipal(new[] { Identity });
        }

        public static ClaimsPrincipal GetPrincipalWithDefaultScheme(int id, string name, string role, string email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, id.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, email)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public static ClaimsPrincipal GetPrincipalWithDefaultScheme(string id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, id.ToString())
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public static ClaimsPrincipal GetPrincipalWithDefaultScheme(string id, string name, string role, string email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, id),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, email)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public static AuthenticationProperties GetProperties(int minutesTimeout)
        {
            AuthenticationProperties properties = new AuthenticationProperties
            {
                AllowRefresh = true, 
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(minutesTimeout),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                IssuedUtc = DateTimeOffset.UtcNow
                // The time at which the authentication ticket was issued.

                //RedirectUri = returnUrl
                // The full path or absolute URI to be used as an http redirect response value. 

            };

            return properties;
        }

        public static string GetClaimValue(IIdentity id, string type)
        {
            try
            {
                if (id == null)
                    return null;
                else
                {
                    ClaimsIdentity myIdentity = (ClaimsIdentity)id;
                    if (myIdentity != null)
                    {
                        Claim claimID = myIdentity.Claims.FirstOrDefault(x => x.Type == type);
                        return claimID?.Value.ToString();
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve algum erro para obter o ClaimValue. Exceção: {ex.Message}");
            }
        }

        //public static int GetUserSid()
        //{
        //    try
        //    {
        //        string value = GetClaimValue(Identity, ClaimTypes.Sid);

        //        if (string.IsNullOrEmpty(value))
        //            return 0;
        //        else
        //            return int.Parse(value);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Houve algum erro para obter o valor do Sid. Exceção: {ExceptionManager.ExceptionMessage(ex)}");
        //    }
        //}

        public static int GetUserSid(IIdentity id)
        {
            try
            {
                ClaimsIdentity myIdentity = (ClaimsIdentity)id;

                string value = GetClaimValue(myIdentity, ClaimTypes.Sid);                

                if (string.IsNullOrEmpty(value))
                    return 0;
                else
                    return int.Parse(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve algum erro para obter o valor do Sid. Exceção: {ex.Message}");
            }
        }

        //public static string GetUserName()
        //{
        //    try
        //    {
        //        return GetClaimValue(Identity, ClaimTypes.Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Houve algum erro para obter o valor do Role. Exceção: {ExceptionManager.ExceptionMessage(ex)}");
        //    }
        //}

        public static string GetUserName(IIdentity id)
        {
            try
            {
                ClaimsIdentity myIdentity = (ClaimsIdentity)id;

                return GetClaimValue(myIdentity, ClaimTypes.Name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve algum erro para obter o valor do Role. Exceção: {ex.Message}");
            }
        }

        //public static string GetUserRole()
        //{
        //    try
        //    {
        //        return GetClaimValue(Identity, ClaimTypes.Role);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Houve algum erro para obter o valor do Role. Exceção: {ExceptionManager.ExceptionMessage(ex)}");
        //    }
        //}

        public static string GetUserRole(IIdentity id)
        {
            try
            {
                ClaimsIdentity myIdentity = (ClaimsIdentity)id;

                return GetClaimValue(myIdentity, ClaimTypes.Role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve algum erro para obter o valor do Role. Exceção: {ex.Message}");
            }
        }

        //public static string GetUserEmail()
        //{
        //    try
        //    {
        //        return GetClaimValue(Identity, ClaimTypes.Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Houve algum erro para obter o valor do Email. Exceção: {ExceptionManager.ExceptionMessage(ex)}");
        //    }
        //}

        public static string GetUserEmail(IIdentity id)
        {
            try
            {
                ClaimsIdentity myIdentity = (ClaimsIdentity)id;

                return GetClaimValue(myIdentity, ClaimTypes.Email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve algum erro para obter o valor do Email. Exceção: {ex.Message}");
            }
        }
    }
}
