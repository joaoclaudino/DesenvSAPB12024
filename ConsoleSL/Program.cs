// See https://aka.ms/new-console-template for more information
using ConsoleSL.Controllers;
using ConsoleSL.Converter;
using ConsoleSL.Models.FakerAPI.Companie;
using ConsoleSL.Models.FakerAPI.Person;
using ConsoleSL.Models.FakerAPI.Product;
using ConsoleSL.Models.SL;


SLAPIController objSLAPIController = new SLAPIController();
await objSLAPIController.LoginAsync();
Console.WriteLine("Login Service Layer OK!");

FakerAPIController objFakerAPIController = new FakerAPIController();

ProductResponse? objProductResponse=await objFakerAPIController.ConsultaProduct();
PersonResponse? objPersonResponse = await objFakerAPIController.ConsultaPersons();
CompanieResponse? objCompanieResponse = await objFakerAPIController.ConsultaCompanies();

if (objProductResponse!=null)
{
    Console.WriteLine(string.Format("Produtos: {0}", objProductResponse.Data.Count()));
}
if (objCompanieResponse != null)
{
    Console.WriteLine(string.Format("Companies: {0}", objCompanieResponse.Data.Count()));
    List<BusinessPartner> businessPartners = CompanyToBusinessPartnerConverter.Convert(objCompanieResponse.Data);
    foreach (var partner in businessPartners)
    {
        await objSLAPIController.PostBusinessPartner(partner);
    }
}
//if (objPersonResponse != null)
//{
//    Console.WriteLine(string.Format("Persons: {0}", objPersonResponse.Data.Count()));
//    List<BusinessPartner> businessPartners = PersonToBusinessPartnerConverter.Convert(objPersonResponse.Data);
//    foreach (var partner in businessPartners)
//    {
//        await objSLAPIController.PostBusinessPartner(partner);
//    }
//}




Console.ReadLine();