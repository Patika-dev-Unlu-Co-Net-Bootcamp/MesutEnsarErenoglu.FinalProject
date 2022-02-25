

using FinalProject.Domain.Interfaces;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IBidRepository BidRepository { get;  }
        public IBrandRepository BrandRepository { get;  }
        public ICategoryRepository CategoryRepository { get;  }
        public IColorRepository ColorRepository { get;  }
        public IProductRepository ProductRepository { get;  }
        public ISubCategoryRepository SubCategoryRepository { get;  }
        Task<int> SaveChangesAsync();
    }
}
