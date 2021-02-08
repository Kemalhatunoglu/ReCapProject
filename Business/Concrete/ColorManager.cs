using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IRepositoryService<Color>, IColorService
    {
        IColorService _colorService;

        public ColorManager(IColorService colorService)
        {
            _colorService = colorService;
        }

        public void Add(Color entity)
        {
            _colorService.Add(entity);
        }

        public void Delete(Color entity)
        {
            _colorService.Delete(entity);
        }

        public Color Get(Expression<Func<Color, bool>> filter = null)
        {
            return _colorService.Get(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colorService.GetAll(filter);
        }

        public void Update(Color entity)
        {
            _colorService.Update(entity);
        }
    }
}
