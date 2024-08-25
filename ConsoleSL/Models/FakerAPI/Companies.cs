using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Models.FakerAPI.Companie
{
    public class CompanieResponse
    {
        public required string Status { get; set; }
        public required int Code { get; set; }
        public required int Total { get; set; }
        public required List<Company> Data { get; set; }
    }

    public class Company
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Vat { get; set; }
        public required string Phone { get; set; }
        public required string Country { get; set; }
        public required List<Address> Addresses { get; set; }
        public required string Website { get; set; }
        public required string Image { get; set; }
        public required Contact Contact { get; set; }
    }

    public class Address
    {
        public required int Id { get; set; }
        public required string Street { get; set; }
        public required string StreetName { get; set; }
        public required string BuildingNumber { get; set; }
        public required string City { get; set; }
        public required string Zipcode { get; set; }
        public required string Country { get; set; }
        public required string CountyCode { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
    }

    public class Contact
    {
        public required int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required DateTime Birthday { get; set; }
        public required string Gender { get; set; }
        public required Address Address { get; set; }
        public required string Website { get; set; }
        public required string Image { get; set; }
    }
}
