﻿using AccountManagerment.Models;
using AccountManagerment.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Test.Moq
{
    public class MockAccountRepository : Mock<IAccountRepository>
    {
        public MockAccountRepository mockRegister(string email, string fullname)
        {
            if(email.Length == 0 || fullname.Length == 0)
            {
                Setup(x => x.Register(It.IsAny<string>(), It.IsAny<string>())).Returns(new Account
                {
                    Email = null,
                    FullName = null
                });
            }else
            {
                Setup(x => x.Register(It.IsAny<string>(), It.IsAny<string>())).Returns(new Account()
                {
                    Email = email,
                    FullName = fullname
                });
            }
            return this;
        }
        public MockAccountRepository mockGetAccounts(ResponseAccount response)
        {
            Setup(x => x.GetAccounts()).Returns(response);
            return this;
        }
    }
}
