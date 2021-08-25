using KomodoInsurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsurance_Tests
{
    [TestClass]
    public class InsuranceTest
    {
        [TestMethod]
        public void RepoTests()
        {

            BadgeRepository badgeRepository = new BadgeRepository();

            Badge badge1 = new Badge(1, 1);
            Badge badge2 = new Badge(2, 3);
            Badge badge3 = new Badge(3, 5);

            badgeRepository.AddBadge(badge1);
            badgeRepository.AddBadge(badge2);
            badgeRepository.AddBadge(badge3);

            badgeRepository.DisplayBadges();
            badgeRepository.DisplayBadgeDoors(1);


        }
    }
}
