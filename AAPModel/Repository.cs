using AAPModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAPModel
{
    public class Repository
    {
        public long AddUser(AppUserModel appUser)
        {
            try
            {
                using (AAPMEntities entities = new AAPMEntities())
                {
                    var c = entities.AppUsers.Where(x => x.UserId == appUser.UserId).FirstOrDefault();

                    if (c == null)
                    {
                        c = new AppUser();
                        entities.AppUsers.Add(c);
                    }

                    c.FirstName = appUser.FirstName;
                    c.MiddleName = appUser.MiddleName;
                    c.LastName = appUser.LastName;
                    c.LoginId = appUser.LoginId;
                    c.IsActive = appUser.IsActive;
                    c.Email = appUser.Email;
                    c.AddressLine = appUser.AddressLine;
                    c.Phone = appUser.Phone;
                    c.RoleId = appUser.RoleId;

                    entities.SaveChanges();

                    return c.UserId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public List<AppUserModel> GetUsers(int roleId)
        {
            try
            {
                List<AppUserModel> lstUser = new List<AppUserModel>();
                using (AAPMEntities entities = new AAPMEntities())
                {

                    var Query = entities.AppUsers.AsQueryable();

                    if (roleId == 2)
                        Query = Query.Where(a => a.RoleId != 1).AsQueryable();
                    else if (roleId == 3)
                        Query = Query.Where(a => a.RoleId == 3).AsQueryable();

                    return lstUser = Query.Select(x => new AppUserModel
                    {
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        LastName = x.LastName,
                        RoleId = x.RoleId,
                        IsActive = x.IsActive,
                        AddressLine = x.AddressLine,
                        Email = x.Email,
                        UserId = x.UserId

                    }).ToList();

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string DeleteUser(int userId)
        {
            try
            {
                List<AppUserModel> lstUser = new List<AppUserModel>();
                using (AAPMEntities entities = new AAPMEntities())
                {
                    var entity = entities.AppUsers.Where(x => x.UserId == userId).FirstOrDefault();
                    if (entity != null)
                    {
                        entities.AppUsers.Remove(entity);
                        entities.SaveChanges();
                        return "Success";
                    }

                    return "Mot Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public AppUserModel GetUserDetail(int userId)
        {
            try
            {
                using (AAPMEntities entities = new AAPMEntities())
                {

                    var uder = entities.AppUsers.Select(x => new AppUserModel
                    {
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        LastName = x.LastName,
                        Phone=x.Phone,
                        LoginId=x.LoginId,
                        RoleId = x.RoleId,
                        IsActive = x.IsActive,
                        AddressLine = x.AddressLine,
                        Email = x.Email,
                        UserId = x.UserId

                    }).FirstOrDefault(x => x.UserId == userId);
                    return uder;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<RoleMaster> GetRole()
        {
            using (AAPMEntities entitie = new AAPMEntities())
            {
                var list = entitie.RoleMasters.ToList();
                return list;
            }
        }
    }
}
