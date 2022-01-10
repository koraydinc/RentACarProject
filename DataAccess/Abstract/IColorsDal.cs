using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IColorsDal
    {
        List<Colors> GetAll();
        List<Colors> GetById(int id);
        void Add(Colors colors);
        void Update(Colors colors);
        void Delete(Colors colors);

    }
}
