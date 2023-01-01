using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace blogMediator;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Article, ArticleDto>().ReverseMap();
        CreateMap<ArticleForUpdateDto, Article> ().ReverseMap();
    }
}
