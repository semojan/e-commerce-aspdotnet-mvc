using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(int ProductId, Guid BrowserId);
        ResultDto RemoveFromCart(int ProductId, Guid BrowserId);
        ResultDto<CartDto> GetMyCart(Guid BrowserId);

        ResultDto Add(int CartItemId);
        ResultDto LowOff(int CartItemId);
    }

    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDto()
            {
                Success = true,
            };
        }

        public ResultDto AddToCart(int ProductId, Guid BrowserId)
        {
            var cart = _context.Carts
                .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                .FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = BrowserId,
                };

                _context.Carts .Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            var product = _context.Products.Find(ProductId);

            var cartItem = _context.CartItems
                .Where(p => p.ProductId == ProductId && p.CartId == cart.Id)
                .FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
                _context.SaveChanges();
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,
                };
                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }

            return new ResultDto()
            {
                Success = true,
                Message = $"محصول {product.Name} با موفقیت به سبد خرید اضافه شد."
            };
        }

        public ResultDto<CartDto> GetMyCart(Guid BrowserId)
        {
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                .FirstOrDefault();

            return new ResultDto<CartDto>()
            {
                Data = new CartDto()
                {
                    ProductCount = cart.CartItems.Count(),
                    SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                    CartItems = cart.CartItems.Select(p => new CartItemDto
                    {
                        Count = p.Count,
                        Price = p.Price,
                        Product = p.Product.Name,
                        Id = p.Id,
                        Images = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? ""
                    }).ToList(),
                },
                Success = true,
                Message = ""
            };
        }

        public ResultDto LowOff(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);

            if(cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    Success = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDto()
            {
                Success = true,
            };
        }

        public ResultDto RemoveFromCart(int ProductId, Guid BrowserId)
        {
            var cartItem = _context.CartItems
                .Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefault();
            if(cartItem != null)
            {
                cartItem.IsDeleted = true;
                cartItem.DeleteTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto()
                {
                    Success = true,
                    Message = "محصول از سبد خرید حذف شد."
                };
            }

            return new ResultDto()
            {
                Success = false,
                Message = "محصول یافت نشد."
            };
        }
    }

    public class CartDto
    {
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }

    public class CartItemDto
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Images { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
