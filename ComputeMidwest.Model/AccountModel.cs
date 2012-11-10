using System;
using System.Linq;
using ComputeMidwest.Entity;

namespace ComputeMidwest.Model
{
    internal class AccountModel
    {
        private readonly EntityModelContainer _container;

        public AccountModel(EntityModelContainer container)
        {
            _container = container;
        }

        public Account GetAccountById(Guid userid, string authtoken)
        {
            // todo: validate user
            return (from account in _container.Accounts where account.Id == userid select account).FirstOrDefault();
        }

        public Account GetAccountByName(string username, string authType)
        {
            return
                (from account in _container.Accounts
                 where account.Name == username && account.AuthType == authType
                 select account).FirstOrDefault();
        }

        public Account CreateAccount(string username, string authType)
        {
            var account = new Account
                {
                    Name = username,
                    AuthType = authType
                };

            _container.Accounts.AddObject(account);
            _container.SaveChanges();
            return account;
        }
    }
}