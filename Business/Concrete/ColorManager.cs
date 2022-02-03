using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorsDal)
        {
            _colorDal = colorsDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.RemovedMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == id), Messages.ListedMessage);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
