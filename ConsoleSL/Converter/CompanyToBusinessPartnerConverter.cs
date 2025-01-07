using ConsoleSL.Models.FakerAPI.Companie;
using ConsoleSL.Models.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Converter
{
    public class CompanyToBusinessPartnerConverter
    {
        public static List<BusinessPartner> Convert(List<Company> companies)
        {
            return companies.Select(company => new BusinessPartner
            {
                CardCode = "D-"+ company.Id.ToString(),  // Mapeando ID como CardCode
                CardName = company.Name,  // Nome da empresa como CardName
                AliasName = company.Name,  // Alias como o nome da empresa
                CardType = "C",  // Tipo de parceiro (Cliente, por exemplo)
                GroupCode = 107,  // Código do grupo, valor fixo ou configurável
                Currency = "R$",  // Exemplo de valor fixo para a moeda
                MainUsage = "10",  // Valor fixo para uso principal
                Phone1 = company.Phone,  // Telefone principal da empresa
                EmailAddress = company.Email,  // Email principal da empresa
                BPAddresses = company.Addresses.Select(addr => new BPAddress
                {
                    AddressName = $"{company.Name} Address",
                    BPCode = company.Id.ToString(),
                    Street = addr.Street,
                    StreetNo = addr.BuildingNumber,
                    City = addr.City,
                    ZipCode = addr.Zipcode,
                    Country = "BR",
                    County = addr.StreetName,  // Nome da rua mapeado como County
                    State = addr.CountyCode,
                    AddressType = "S",  // Tipo de endereço (por exemplo, "S" para envio)
                }).ToList(),
                ContactEmployees = new List<ContactEmployee>
            {
                new ContactEmployee
                {
                    CardCode = company.Id.ToString(),
                    Name = $"{company.Contact.Firstname} {company.Contact.Lastname}",
                    FirstName = company.Contact.Firstname,
                    LastName = company.Contact.Lastname,
                    Phone1 = company.Contact.Phone,
                    //Email = company.Contact.Email,
                    Active = "tYES"
                }
            },
                BPFiscalTaxIDCollection = new List<BPFiscalTaxID>
            {
                new BPFiscalTaxID
                {
                    TaxId0 = company.Vat // Mapeando o VAT da empresa como um campo fiscal
                }
            }
            }).ToList();
        }
    }
}
