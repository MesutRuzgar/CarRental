using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            Console.WriteLine("------RENK EKLENDI----");
            _colorDal.Add(color);            
        }

        public void Delete(Color color)
        {
            Console.WriteLine("------RENK SILINDI----");
            _colorDal.Delete(color);            
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }
        public void Update(Color color)
        {
            Console.WriteLine("------RENK GUNCELLENDI----");
            _colorDal.Update(color);
        }
    }
}
