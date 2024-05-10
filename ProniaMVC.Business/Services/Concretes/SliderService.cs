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
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void CreateSlider(Slider slider)
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
            var existSlider = _sliderRepository.Get(x => x.Id == id);
            if (existSlider == null) throw new NullReferenceException("This slider does not exist!");
            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public Slider GetSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.Get(func);
        }

        public void UpdaterSlider(int id, Slider slider)
        {
            Slider oldSlider = _sliderRepository.Get(x => x.Id == id);
            if (oldSlider == null) throw new NullReferenceException("Bele bir Slider Yoxdur!");
            else
            {
                oldSlider.Title = slider.Title;
                oldSlider.SubTitle = slider.SubTitle;
                oldSlider.Description = slider.Description;
                oldSlider.ImageUrl = slider.ImageUrl;
                _sliderRepository.Commit();
            }
            
        }
    }
}
