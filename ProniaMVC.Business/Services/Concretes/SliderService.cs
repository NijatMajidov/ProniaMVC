using ProniaMVC.Business.Exceptions;
using ProniaMVC.Business.Services.Abstracts;
using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepositoryAbstracts;
using ProniaMVC.Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Services.Concretes
{
    internal class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void AddSlider(Slider slider)
        {
            if (slider == null) throw new NullReferenceException("Slider cannot be null!!!!");
            if (!_sliderRepository.GetAll().Any(x => x.ImageUrl == slider.ImageUrl))
            {
                _sliderRepository.Add(slider);
                _sliderRepository.Commit();
            }
            else throw new DublicateCategoryException("Name","This slider is now available!!!");
        }

        public void DeleteSlider(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public Slider GetSlider(Func<Slider, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void UpdaterSlider(int id, Slider slider)
        {
            throw new NotImplementedException();
        }
    }
}
