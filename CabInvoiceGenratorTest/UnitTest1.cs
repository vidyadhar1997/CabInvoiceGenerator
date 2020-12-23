using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGenratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator=null;
        RideRepository rideRepository;

        /// <summary>
        /// Test case for UC 1 Given the distance and time when invoice generator then should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenInvoiceGenerator_ThenShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare=invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test case for UC 2 Givens the multiple rides when invoice generator then should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenInvoiceGenerator_thenShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary=invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case for UC 3 Givens the multiple rides when invoice generator then should return following invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenInvoiceGenerator_thenShouldReturnFollowingInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateAvrageFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0 ,15);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case for UC 4 Givens the multiple rides when user identifier then should return following invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenUserId_thenShouldReturnFollowingInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            string userId = "Dhiraj";
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides("Suraj", new Ride[]{new Ride(3.0, 6), new Ride(4.0, 8)});
            rideRepository.AddRides("vidyadhar", new Ride[] { new Ride(3.0, 6), new Ride(4.0, 8) });
            Ride[] rideData = rideRepository.GetRides(userId);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateAvrageFare(rideData);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case for UC 5 Given the distance and time when invoice generator then should return total fare for premium ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenInvoiceGenerator_ThenShouldReturnTotalFareForPremiumRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
    }
}