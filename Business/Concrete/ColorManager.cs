using Business.Abstract;
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
        IColorsDal _colorDal;
        public ColorManager(IColorsDal colorsDal)
        {
            _colorDal = colorsDal;
        }
        public List<Colors> GetAll()
        {
            return _colorDal.GetAll();
        }
    }
}
