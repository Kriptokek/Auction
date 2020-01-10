using BLL;
using BLL.Interfaces;
using Ninject.Modules;

namespace WebApplication2
{
    public class AuctionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IProductService>().To<ProductService>();
            Bind<IAuctionLotService>().To<AuctionLotService>();
        }
    }
}