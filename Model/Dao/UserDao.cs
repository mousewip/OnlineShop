using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                // 0 = tk khong ton tai
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    // -1 = tk bi khoa
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                        // 1 = password dung
                        return 1;
                    else
                        // 2 = password sai
                        return 2;
                }
                
            }
        }
    }
}
