namespace _04_06_01_ecommerce.Application.Services.Common.Queeries.GetMenuItem
{
    public class MenuItemDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Children { get; set; }
    }
}

