namespace _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct
{
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}
