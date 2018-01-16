using System;
using System.Transactions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class IsolatedAttribute : Attribute, ITestAction
    {
        private TransactionScope _transactionScope;

        public void BeforeTest(ITest test)
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        public void AfterTest(ITest test)
        {
            if(_transactionScope!=null)
                _transactionScope.Dispose();

            _transactionScope = null;
        }

        public ActionTargets Targets => ActionTargets.Test;
    }
}