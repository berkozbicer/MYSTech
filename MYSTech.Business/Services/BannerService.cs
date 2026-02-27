using MYSTech.DataAccess.UnitOfWork;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Services
{
    public class BannerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BannerService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Banner>> GetActiveBannersAsync()
        {
            var banners = await _unitOfWork.Banners.GetAllAsync();
            return banners.Where(b => b.IsActive).OrderBy(b => b.Order);
        }
    }
}
