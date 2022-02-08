using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("carimage.add,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var addResult = _fileHelper.Upload(file);
            if (!addResult.Success)
            {
                return new ErrorResult(addResult.Message);
            }
            carImage.ImagePath = addResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddedMessage);
        }

        [SecuredOperation("carimage.delete,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImage(carImage.Id));
            if (result != null)
            {
                return result;
            }

            _fileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.RemovedMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarIdImages(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        [SecuredOperation("carimage.update,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImage(carImage.Id));
            if (result != null)
            {
                return result;
            }

            var updateResult = _fileHelper.Update(file, carImage.ImagePath);
            if (!updateResult.Success)
            {
                return new ErrorResult(updateResult.Message);
            }

            carImage.ImagePath = updateResult.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdatedMessage);
        }

        //Business Codes

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult("Car image limit exceeded!");
            }

            return new SuccessResult();
        }
        private IResult CheckImage(int carImageId)
        {
            var image = _carImageDal.Get(i => i.Id == carImageId);
            if (image == null)
            {
                return new ErrorResult("Image not found!");
            }
            return new SuccessResult();
        }
    }
}
