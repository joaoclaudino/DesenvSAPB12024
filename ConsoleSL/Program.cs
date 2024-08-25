// See https://aka.ms/new-console-template for more information
using ConsoleSL.Controllers;
using ConsoleSL.Models.FakerAPI.Companie;
using ConsoleSL.Models.FakerAPI.Person;
using ConsoleSL.Models.FakerAPI.Product;

Console.WriteLine("Hello, World!");

FakerAPIController objFakerAPIController = new FakerAPIController();

ProductResponse? objProductResponse=await objFakerAPIController.ConsultaProduct();
PersonResponse? objPersonResponse = await objFakerAPIController.ConsultaPersons();
CompanieResponse? objCompanieResponse = await objFakerAPIController.ConsultaCompanies();

if (objProductResponse!=null)
{
    Console.WriteLine(string.Format("Produtos: {0}", objProductResponse.Data.Count()));
}
if (objPersonResponse != null)
{
    Console.WriteLine(string.Format("Persons: {0}", objPersonResponse.Data.Count()));
}
if (objCompanieResponse != null)
{
    Console.WriteLine(string.Format("Companies: {0}", objCompanieResponse.Data.Count()));
}



Console.ReadLine();