using ShopForGardeners.Data.Models;
using ShopForGardeners.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForGardeners.Data.Interfaces
{
    public interface IAccount
    {
        IEnumerable<User> AllAccounts { get; }

        Task createUser(RegisterViewModel user);

    }
}
