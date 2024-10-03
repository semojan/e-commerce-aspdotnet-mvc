namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }
}
