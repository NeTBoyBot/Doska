using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Doska.DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Doska.AppServices.MapProfile;
using Doska.AppServices.IRepository;
using Doska.AppServices.Services.Ad;
using Doska.DataAccess.Repositories;
using Doska.Infrastructure.BaseRepository;
using Doska.AppServices.Services.Categories;
using Doska.AppServices.Services.User;
using Doska.AppServices.Services.SubCategories;
using Doska.AppServices.Services.FavoriteAd;

namespace Doska.Registrar
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbContextOptionsConfigurator<DoskaContext>, DoskaContextConfiguration>();

            services.AddDbContext<DoskaContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<DoskaContext>>()
                .Configure((DbContextOptionsBuilder<DoskaContext>)dbOptions)));

            services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<DoskaContext>()));

            services.AddAutoMapper(typeof(UserMapProfile), typeof(AdMapProfile),
                typeof(CategoryMapProfile), typeof(SubCategoryMapProfile));

            // Регистрация объявления
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IFavoriteRepository, AdRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ISubCategoryService, SubCategoryService>();
            services.AddTransient<ISubCategoryRepository, SubcategoryRepository>();

            services.AddTransient<IFavoriteAdService, FavoriteAdService>();
            services.AddTransient<IFavoriteAdRepository, FavoriteAdRepository>();

            return services;
        }
    }
}
