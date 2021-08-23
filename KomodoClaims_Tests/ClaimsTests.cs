using KomodoClaims_Classes;
using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddClaimTest()
        {
            ClaimRepo _claims = new ClaimRepo();

            Claims claim = new Claims(1, ClaimType.Car, "Test test test", 450.23, new DateTime(2012, 5, 17), new DateTime(2012, 5, 10));
            Claims claim2 = new Claims(2, ClaimType.Home, "Test2 Test2 Test2", 486.23, new DateTime(2012, 5, 17), new DateTime(2016, 5, 10));

            _claims.AddClaimToRepo(claim);
            _claims.AddClaimToRepo(claim2);

            _claims.GetNextClaim();

            _claims.ShowClaims();

        }
    }
}
