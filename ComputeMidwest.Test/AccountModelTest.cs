using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeMidwest.Entity;
using ComputeMidwest.Model;
using NUnit.Framework;

namespace ComputeMidwest.Test
{
    [TestFixture]
    public class AccountModelTest
    {
        private AccountModel _model;
        [SetUp]
        public void Init()
        {
            _model = new AccountModel(new EntityModelContainer(@"metadata=res://*/EntityModel.csdl|res://*/EntityModel.ssdl|res://*/EntityModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=""Data Source=|DataDirectory|\ComputeMidwest.sdf"""));
        }

        [Test]
        public void TestCreateAccount()
        {
            var account = _model.CreateAccount("bleh", "Tom", "Twitter", "http://goatse.cx");
        }
    }
}
