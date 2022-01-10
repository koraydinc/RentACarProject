using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorsDal : IColorsDal
    {
        List<Colors> _colors;
        public InMemoryColorsDal()
        {
            _colors = new List<Colors>
            {
                new Colors{ ColorId =1, ColorName = "Beyaz"},
                new Colors{ ColorId =2, ColorName = "Siyah"},
                new Colors{ ColorId =3, ColorName = "Kırmızı"}
            };
        }
        public void Add(Colors colors)
        {
            _colors.Add(colors);
        }

        public void Delete(Colors colors)
        {
            Colors colorsToDelete = _colors.SingleOrDefault(c => c.ColorId == colors.ColorId);
            _colors.Remove(colorsToDelete);
        }

        public List<Colors> GetAll()
        {
            return _colors;
        }

        public List<Colors> GetById(int id)
        {
            return _colors.Where(c => c.ColorId == id).ToList();
        }

        public void Update(Colors colors)
        {
            Colors colorsToUpdate = _colors.SingleOrDefault(c => c.ColorId == colors.ColorId);
            colorsToUpdate.ColorName = colors.ColorName;
        }
    }
}
