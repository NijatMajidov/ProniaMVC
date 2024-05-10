using Microsoft.AspNetCore.Mvc;
using ProniaMVC.Business.Exceptions;
using ProniaMVC.Business.Services.Abstracts;
using ProniaMVC.Business.Services.Concretes;
using ProniaMVC.Core.Models;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        IWebHostEnvironment _webHostEnvironment;
        public SliderController(ISliderService sliderService, IWebHostEnvironment webHostEnvironment)
        {
            _sliderService = sliderService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _sliderService.GetAllSliders();
            
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!slider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("PhotoFile", "File Formati Duzgun Deyil!!!");
                return View();
            }

            string path = @"C:\Users\user\Desktop\MVC_Project\ProniaMVC\ProniaMVC\wwwroot\Upload\Sliders\";
            string fileName = slider.ImageFile.FileName;
            using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
            {
                slider.ImageFile.CopyTo(stream);
            }
            slider.ImageUrl = fileName;
            if (!ModelState.IsValid)
            {
                return View();
            }
            _sliderService.CreateSlider(slider);
            return RedirectToAction("Index");
        }
            public IActionResult Delete(int id)
            {
                Slider slider = _sliderService.GetSlider(x => x.Id == id);

                string path = _webHostEnvironment.WebRootPath + @"\Upload\Slider\" + slider.ImageUrl;
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                _sliderService.DeleteSlider(id);
                return RedirectToAction("Index");
            }


            public IActionResult Update(int id)
            {
                Slider slider = _sliderService.GetSlider(x => x.Id == id);

                return View(slider);
            }
            [HttpPost]
            public IActionResult Update(Slider slider)
            {

                Slider oldSlider = _sliderService.GetSlider(x => x.Id == slider.Id);
                if (slider.ImageFile == null)
                {
                    slider.ImageUrl = oldSlider.ImageUrl;
                }
                else if (!slider.ImageFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("PhotoFile", "File Formati Duzgun Deyil!!!");
                    return View();
                }
                else
                {
                    string path = @"C:\Users\user\Desktop\MVC_Project\ProniaMVC\ProniaMVC\wwwroot\Upload\Sliders\";
                    string fileName = slider.ImageFile.FileName;
                    using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
                    {
                        slider.ImageFile.CopyTo(stream);
                    }
                    slider.ImageUrl = fileName;
                }

                _sliderService.UpdaterSlider(slider.Id, slider);
                return RedirectToAction("Index");
            }
        }
    }