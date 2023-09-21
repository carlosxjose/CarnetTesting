using System;
using ECRti.Framework.Interfaces;

namespace CarnetTesting
{
    public class CardNetServices : ICore
    {
        private readonly ICore _CardNetCore;

        public CardNetServices() 
        {
            _CardNetCore = new ECRti.Framework.Core();
        }

        public string Initialice()
        {
            return _CardNetCore.Initialice();
        }

        public string ProcessAnnulment(int host, int referenceNumber)
        {
            return _CardNetCore.ProcessAnnulment(host, referenceNumber);
        }

        public string ProcessCheckInAnnulment(int folio, int referenceNumber)
        {
            return _CardNetCore.ProcessCheckInAnnulment(folio, referenceNumber);
        }

        public string ProcessCheckInHotelRentCar(int folio, DateTime entryDate, DateTime departureDate, int amount, int tax, int otherTaxes, int invoiceId)
        {
            return _CardNetCore.ProcessCheckInHotelRentCar(folio,entryDate, departureDate, amount, tax, otherTaxes, invoiceId);
        }

        public string ProcessCheckOutAMEXHotelRentCar(string authorizationAmex, int amount)
        {
            return _CardNetCore.ProcessCheckOutAMEXHotelRentCar(authorizationAmex, amount);
        }

        public string ProcessCheckOutHotelRentCar(int folio, int amount)
        {
            return _CardNetCore.ProcessCheckOutHotelRentCar(folio, amount);
        }

        public string ProcessClose()
        {
            return _CardNetCore.ProcessClose();
        }

        public string ProcessDeferredSale(int amount, int tax, int otherTaxes, int invoiceId, int quantyOfPayments)
        {
            return _CardNetCore.ProcessDeferredSale(amount,tax, otherTaxes, invoiceId, quantyOfPayments);
        }

        public string ProcessLoyaltySale(int amount, int tax, int otherTaxes, int invoiceId)
        {
            return _CardNetCore.ProcessLoyaltySale(amount,tax, otherTaxes, invoiceId);
        }

        public string ProcessNormalSale(int amount, int tax, int otherTaxes, int invoiceId)
        {
            return _CardNetCore.ProcessNormalSale(amount,tax,otherTaxes, invoiceId);
        }

        public string ProcessReCheckInHotelRentCar(int folio, int amount, int tax, int otherTaxes)
        {
            return _CardNetCore.ProcessReCheckInHotelRentCar(folio, amount, tax, otherTaxes);
        }

        public string ProcessReturn(int amount, int tax, int otherTaxes, int invoiceId)
        {
            return ProcessReturn(amount,tax,otherTaxes, invoiceId);
        }

        public string SetLocalEndPoint(string ipAddress, int portNumber)
        {
            return _CardNetCore.SetLocalEndPoint(ipAddress,portNumber);
        }

        public string SetRemoteEndPoint(string ipAddress, int portNumber)
        {
            return _CardNetCore.SetRemoteEndPoint(ipAddress,portNumber);
        }

        public string SetTimeout(int milliseconds)
        {
            return _CardNetCore.SetTimeout(milliseconds);
        }
    }
}
