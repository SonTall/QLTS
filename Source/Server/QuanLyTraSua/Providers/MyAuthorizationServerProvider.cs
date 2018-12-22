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
        private TaiKhoan taiKhoan = new TaiKhoan();
      //  private delegate TokenEndpointdelegate
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.AdditionalResponseParameters.Add("idtaikhoan", taiKhoan.MaTaiKhoan);
            context.AdditionalResponseParameters.Add("username", taiKhoan.TenTaiKhoan);
            context.AdditionalResponseParameters.Add("password", taiKhoan.MatKhau);
            context.AdditionalResponseParameters.Add("identity", context.Identity.Name);
            if(taiKhoan.MaNhanVien != null)
            {
                context.AdditionalResponseParameters.Add("id", taiKhoan.MaNhanVien);
            }
            else
            {
                context.AdditionalResponseParameters.Add("id", taiKhoan.MaKhachHang);
            }

            return base.TokenEndpointResponse(context);
        }

        //public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        //{
        //    context.AdditionalResponseParameters.Add("username", context.Identity.Name);
        //  //  context.AdditionalResponseParameters.Add("aa", context.);
        //    return base.TokenEndpoint(context);
        //}

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                taiKhoan = db.TaiKhoans.SingleOrDefault(v => v.TenTaiKhoan == context.UserName && v.MatKhau == context.Password);
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
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
            }
        }
    }
}