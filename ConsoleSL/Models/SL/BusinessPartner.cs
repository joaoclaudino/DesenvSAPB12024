using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Models.SL
{
    public class BPAddress
    {
        public string AddressName { get; set; }
        public string BPCode { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string BuildingFloorRoom { get; set; }
        public string AddressType { get; set; }
        public string TypeOfAddress { get; set; }
    }

    public class ContactEmployee
    {
        public string CardCode { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Active { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class BPFiscalTaxID
    {
        public string TaxId0 { get; set; }
        public string TaxId1 { get; set; }
        public string TaxId4 { get; set; }
        public string TaxId5 { get; set; }
        public string TaxId9 { get; set; }
    }

    public class BusinessPartner
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string AliasName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public string Currency { get; set; }
        public string MainUsage { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Cellular { get; set; }
        public string EmailAddress { get; set; }
        public List<BPFiscalTaxID> BPFiscalTaxIDCollection { get; set; }
        public List<BPAddress> BPAddresses { get; set; }
        public List<ContactEmployee> ContactEmployees { get; set; }
    }

}
