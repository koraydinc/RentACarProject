using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorsDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorsDal()
        {
            _colors = new List<Color>
            {
                new Color{ ColorId =1, ColorName = "Beyaz"},
                new Color{ ColorId =2, ColorName = "Siyah"},
                new Color{ ColorId =3, ColorName = "Kırmızı"}
            };
        }
        public void Add(Color colors)
        {
            _colors.Add(colors);
        }

        public void Delete(Color colors)
        {
            Color colorsToDelete = _colors.SingleOrDefault(c => c.ColorId == colors.ColorId);
            _colors.Remove(colorsToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetById(int id)
        {
            return _colors.Where(c => c.ColorId == id).ToList();
        }

        public void Update(Color colors)
        {
            Color colorsToUpdate = _colors.SingleOrDefault(c => c.ColorId == colors.ColorId);
            colorsToUpdate.ColorName = colors.ColorName;
        }
    }
}
