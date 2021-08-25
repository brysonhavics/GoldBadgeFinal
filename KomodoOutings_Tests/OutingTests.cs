using KomodoOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoOutings_Tests
{
    [TestClass]
    public class OutingTests
    {
        [TestMethod]
        public void TestRepo()
        {
            OutingsRepository _outingRepository = new OutingsRepository();

            Outing outing1 = new Outing(OutingType.Golf, 100, new DateTime(01 / 01 / 2001), 1500.13);
            Outing outing2 = new Outing(OutingType.Bowling, 100, new DateTime(01 / 01 / 2002), 120.32);
            Outing outing3 = new Outing(OutingType.AmusementPark, 100, new DateTime(01 / 01 / 2003), 600.12);
            Outing outing4 = new Outing(OutingType.Concert, 100, new DateTime(01 / 01 / 2004), 400.53);

            _outingRepository.AddOuting(outing1);
            _outingRepository.AddOuting(outing2);
            _outingRepository.AddOuting(outing3);
            _outingRepository.AddOuting(outing4);

            _outingRepository.DisplayOutings();

            _outingRepository.ShowOutingsCosts();


        }
    }
}
