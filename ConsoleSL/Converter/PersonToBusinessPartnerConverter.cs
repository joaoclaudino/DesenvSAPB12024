using ConsoleSL.Models.FakerAPI.Person;
using ConsoleSL.Models.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Converter
{
    public class PersonToBusinessPartnerConverter
    {
        public static List<BusinessPartner> Convert(List<Person> persons)
        {
            return persons.Select(person => new BusinessPartner
            {
                CardCode = person.Id.ToString(),  // Mapeando ID como CardCode
                CardName = $"{person.Firstname} {person.Lastname}",  // Nome completo
                AliasName = person.Firstname,  // Alias
                CardType = person.Gender == "Male" ? "S" : "C",  // Exemplo de mapeamento baseado no gênero
                GroupCode = 108,  // Código do grupo, valor fixo ou configurável
                Currency = "R$",  // Exemplo de valor fixo
                MainUsage = "10",  // Valor fixo
                Phone1 = person.Phone,  // Telefone principal
                EmailAddress = person.Email,  // Email
                BPAddresses = new List<BPAddress>
            {
                new BPAddress
                {
                    AddressName = $"{person.Firstname} {person.Lastname}'s Address",
                    BPCode = person.Id.ToString(),
                    Street = person.Address.Street,
                    StreetNo = person.Address.BuildingNumber,
                    City = person.Address.City,
                    ZipCode = person.Address.Zipcode,
                    Country = "BR",
                    County = person.Address.StreetName,  // Mapeando o nome da rua como County
                    State = person.Address.CountyCode,
                    AddressType = "S",  // Tipo de endereço, por exemplo "S" para endereço de entrega
                }
            },
                ContactEmployees = new List<ContactEmployee>
            {
                new ContactEmployee
                {
                    CardCode = person.Id.ToString(),
                    Name = $"{person.Firstname} {person.Lastname}",
                    FirstName = person.Firstname,
                    LastName = person.Lastname,
                    Phone1 = person.Phone,
                    Active = "tYES"
                }
            }
            }).ToList();
        }
    }
}
