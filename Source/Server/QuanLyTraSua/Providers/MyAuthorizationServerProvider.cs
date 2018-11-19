using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyTraSua.Providers
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var taiKhoan = db.TaiKhoans.SingleOrDefault(v => v.TenTaiKhoan == context.UserName && v.MatKhau == context.Password);
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                if (taiKhoan != null)
                {
                    var listMaQuyen = db.GetPhanQuyenByMaTaiKhoan((int)taiKhoan.MaTaiKhoan).ToList();
                    var quyenList = new List<string>();
                    listMaQuyen.ForEach(v =>
                    {
                        quyenList.Add(db.Quyens.SingleOrDefault(n => n.MaQuyen == v.MaQuyen).TenQuyen);
                    });
                    quyenList.ForEach(v =>
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, v.Trim().ToString()));
                    });

                    identity.AddClaim(new Claim("username", taiKhoan.TenTaiKhoan));
                    if(taiKhoan.MaNhanVien != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, db.NhanViens.SingleOrDefault(v => v.MaNhanVien == taiKhoan.MaNhanVien).TenNhanVien.ToString()));
                    }
                    else
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, db.KhachHangs.SingleOrDefault(v => v.MaKhachHang == taiKhoan.MaKhachHang).TenKhachHang.ToString()));

                    }
                    context.Validated(identity);
                }
                //else if (context.UserName == "user" && context.Password == "user")
                //{
                //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                //    identity.AddClaim(new Claim("username", "user"));
                //    identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
                //    context.Validated(identity);
                //}
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
            }
        }
    }
}