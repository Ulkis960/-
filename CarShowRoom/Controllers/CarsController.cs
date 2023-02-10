using CarShowRoom.Data;
using CarShowRoom.Domain;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext context;
        public CarsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CarCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Car CarShowRoomDb = new Car
                {
                    Id = bindingModel.Id,
                    RegNumber = bindingModel.RegNumber,
                    Manufacture = bindingModel.Manufacture,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManufacture = bindingModel.YearOfManufacture,
                    Price = bindingModel.Price,
                };

                context.Cars.Add(CarShowRoomDb);
                

                return this.RedirectToAction("Success");
            }

            return this.View();


        }
        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult All(string searchStringModel, string searchStringPrice)
        {
            List<CarAllViewModel> cars = context.Cars
                .Select(CarShowRoomDb => new CarAllViewModel
                {
                    Id = CarShowRoomDb.Id,
                    Manufacture = CarShowRoomDb.Manufacture,
                    Model = CarShowRoomDb.Model,
                    Picture = CarShowRoomDb.Picture,
                    YearOfManufacture = CarShowRoomDb.YearOfManufacture,
                    Price = CarShowRoomDb.Price
                }
                ).ToList();


            


            return View(cars);

        }


        public IActionResult Sort()
        {
            List<CarAllViewModel> cars = context.Cars
                .Select(CarShowRoomDb => new CarAllViewModel
                {
                    Id = CarShowRoomDb.Id,
                    Manufacture = CarShowRoomDb.Manufacture,
                    Model = CarShowRoomDb.Model,
                    Picture = CarShowRoomDb.Picture,
                    YearOfManufacture = CarShowRoomDb.YearOfManufacture,
                    Price = CarShowRoomDb.Price
                }
                ).OrderBy(x => x.Price).ToList();

            return View(cars);

        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CarCreateViewModel Car = new CarCreateViewModel()
            {
                Id = item.Id,
                Manufacture = item.Manufacture,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price

            };
            return View(Car);
        }
        [HttpPost]

        public IActionResult Edit(CarCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    Id = bindingModel.Id,
                    RegNumber = bindingModel.RegNumber,
                    Manufacture = bindingModel.Manufacture,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManufacture = bindingModel.YearOfManufacture,
                    Price = bindingModel.Price,
                };
                context.Cars.Update(car);
                context.SaveChanges();
                return this.RedirectToAction("All");

            }
            return View(bindingModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CarCreateViewModel car = new CarCreateViewModel()
            {
                Id = item.Id,
                Manufacture = item.Manufacture,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price

            };
            return View(car);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Car item = context.Cars.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            context.Cars.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Cars");

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CarDetailsViewModel Car = new CarDetailsViewModel()
            {
                Id = item.Id,
                Manufacture = item.Manufacture,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price

            };
            return View(Car);
        }

    }
}
