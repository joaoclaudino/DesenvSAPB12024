using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Models.FakerAPI.Product
{
    public class ProductResponse
    {
        public required string Status { get; set; }
        public required int Code { get; set; }
        public required int Total { get; set; }
        public required List<Product> Data { get; set; }
    }

    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Ean { get; set; }
        public required string Upc { get; set; }
        public required string Image { get; set; }
        public required List<ImageDetail> Images { get; set; }
        public required double NetPrice { get; set; }
        public required int Taxes { get; set; }
        public required string Price { get; set; }
        public required List<int> Categories { get; set; }
        public required List<string> Tags { get; set; }
    }

    public class ImageDetail
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Url { get; set; }
    }
}
