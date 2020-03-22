using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class MappingsConfig : Profile
    {
        public MappingsConfig()
        {

           
            CreateMap<CartEntity, Cart>()
              // .IncludeMembers(entity=>entity.CartsGames)
                .ForMember(model => model.Games, opt => opt.MapFrom(entity => entity.CartsGames.Select(y => y.GameEntity).ToList()));

            CreateMap<Cart, CartEntity>()
              // .IncludeMembers(model=>model.Games)
                .ForMember(model => model.CartsGames, opt => opt.MapFrom(entity => entity.Games))                
                ;

            CreateMap<GameEntity, IGame>().ReverseMap();
            CreateMap<DeveloperEntity, IDeveloper>().ReverseMap();

            CreateMap<GameGenreEntity, IGameGenre>().ReverseMap();


            CreateMap<CartsGamesEntity, IGame>().ReverseMap();


            CreateMap<CartsGamesEntity, Cart>()
                .ForMember(model => model.Games, opt => opt.MapFrom(entity => entity.GameEntity)).ReverseMap();





            //CreateMap<CartsGamesEntity, Game>()
            //    .ForMember(model => model, opt => opt.MapFrom(entity => entity.GameEntity));


            CreateMap<Game, CartsGamesEntity>()
                
                .ForMember(entity => entity.GameEntity, opt => opt.MapFrom(model => model));


            CreateMap<GameEntity, Game>()
                
                .ForMember(model => model.Genre, opt => opt.MapFrom(entity => entity.GameGenre.Select(y => y.GameGenreEntity).ToList()));

            CreateMap<Game, GameEntity>()
                
                .ForMember(entity => entity.GameGenre, opt => opt.MapFrom(model => model.Genre));

            CreateMap<GameGenreEntity, GameGenre>();

            CreateMap<GameGenre, GameGenreEntity>()
                .ForMember(entity => entity.GameGenre, opt => opt.MapFrom(model => model));



            CreateMap<IGameGenre, GameGenre>().ReverseMap();
            CreateMap<IGame, Game>().ReverseMap();
            CreateMap<ICart, Cart>().ReverseMap();

            CreateMap<DeveloperEntity, Developer>().ReverseMap();
            CreateMap<IDeveloper, Developer>().ReverseMap();

        }   
    }
}
