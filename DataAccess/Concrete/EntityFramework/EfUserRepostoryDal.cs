using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserRepostoryDal : EfEntityRepositoryDal<User>
    {
        private readonly CoinContext _context;
        public EfUserRepostoryDal(CoinContext context) : base(context)
        {
            _context = context;
        }

        public bool LoginControl(string userName, string password)
        {
            var userList = _context.Users.ToList();

            foreach (var item in userList)
            {
                if (item.UserName == userName && item.Password == password)
                    return true;
                                
            }
            return false;
        }

    }
}
