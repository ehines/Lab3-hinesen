using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//DONE Task 7 items go here

        private readonly DateTime DateThatFlightLeaves = new DateTime(2012, 05, 1);
        private readonly DateTime DateThatFlghtReturns = new DateTime(2012, 05, 3);
	    private readonly int Miles = 900;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(DateThatFlightLeaves, DateThatFlghtReturns, Miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnIncorrectDates()
        {
            new Flight(DateThatFlghtReturns, DateThatFlightLeaves, Miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(DateThatFlightLeaves, DateThatFlghtReturns, -5);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDaySpread()
        {
            var target = new Flight(DateThatFlightLeaves, new DateTime(2012, 05, 2), Miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDaySpread()
        {
            var target = new Flight(DateThatFlightLeaves, DateThatFlghtReturns, Miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDaySpread()
        {
            var target = new Flight(DateThatFlightLeaves, new DateTime(2012, 05, 11), Miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
	}
}
