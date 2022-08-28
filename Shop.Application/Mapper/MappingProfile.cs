using AutoMapper;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using Shop.Application.Functions.Categories.Queries.GetCategoryDetail;
using Shop.Application.Functions.Comments.Command.CreateComment;
using Shop.Application.Functions.Comments.Queries.GetInList;
using Shop.Application.Functions.Orders.Command.CreateOrder;
using Shop.Application.Functions.Products.Commands.CreateProduct;
using Shop.Application.Functions.Products.Commands.UpdateProduct;
using Shop.Application.Functions.Products.Queries.GetProductDetail;
using Shop.Application.Functions.Products.Queries.GetProductsList;
using Shop.Application.Functions.Users.Queries.GetUserDetail;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductInListViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryInListViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<CommentsView, Comment>().ReverseMap()
                .ForMember(c => c.UserName, x => x.MapFrom(x => x.User.NickName));
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<OrderToSend, CreateOrderCommand>().ReverseMap();

        }
    }
}
