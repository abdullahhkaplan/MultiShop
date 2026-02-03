namespace MultiShop.Catalog.DTOs.ProductDtos
{
    public class CreateProductDto
    {

        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
