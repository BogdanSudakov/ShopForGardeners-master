using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Repository
{
    public class AccountRepository : IAccount
    {
        private readonly AppDBContent appDBContent;
        public AccountRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }



        public IEnumerable<User> AllAccounts => this.appDBContent.User;

        public async Task createUser(RegisterViewModel user)
        {
            this.appDBContent.User.Add(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Login = user.Login,
            });

            await appDBContent.SaveChangesAsync();
        }
    }
}
