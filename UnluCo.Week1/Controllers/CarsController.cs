using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Week1.Models;

namespace UnluCo.Week1.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //Veriler statik olarak kullanılmıştır. Aşağıdaki veriler fake olarak eklenmiş rastgele araç verileridir.
        private static List<Cars> CarsList = new List<Cars>()
        {
            new Cars
            {
                Id = 1,
                Brand = "Ford",
                Model = "Focus",
                Km = 45000,
                Year = 2018,
                Price = 300000
            },
            new Cars
            {
                Id = 2,
                Brand = "Toyota",
                Model = "Corolla",
                Km = 120000,
                Year = 2015,
                Price = 220000
            },
            new Cars
            {
                Id = 3,
                Brand = "Volvo",
                Model = "V40",
                Km = 80000,
                Year = 2018,
                Price = 450000
            },
            new Cars
            {
                Id = 4,
                Brand = "Volkswagen",
                Model = "Passat",
                Km = 123000,
                Year = 2020,
                Price = 750000
            },
            new Cars
            {
                Id = 5,
                Brand = "Volkswagen",
                Model = "GolfR",
                Km = 83000,
                Year = 2019,
                Price = 900000
            }
        };
        //Tüm araçların sıralandığı GET metodu.
        [HttpGet] 
        public List<Cars> GetCars()
        {
            var carList = CarsList.OrderBy(x => x.Id).ToList<Cars>();
            return carList;
        }
        //Yalnızca istenilen ID numaralı araç bilgilerini getiren GET metodu.
        [HttpGet("{id}")] 
        public Cars GetById(int id)
        {
            var cars = CarsList.Where(car => car.Id == id).SingleOrDefault();
            return cars;
        }
        //Yeni bir araç bilgisi eklemek için POST metodu.
        [HttpPost]
        public IActionResult AddCar([FromQuery] Cars newCar)
        {
            var car = CarsList.SingleOrDefault(x => x.Id == newCar.Id);
            if (car != null)
            {
                return BadRequest();
            }
            CarsList.Add(newCar);
            return Ok();
        }
        //Belirli bir ID numaralı araç bilgilerini değiştirmek için kullanılan Put metodu.
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Cars updatedCar)
        {
            var car = CarsList.SingleOrDefault(x => x.Id == id);
            if (car is null)
            {
                return BadRequest();
            }
            car.Brand = updatedCar.Brand != default ? updatedCar.Brand : car.Brand;
            car.Model = updatedCar.Model != default ? updatedCar.Model : car.Model;
            car.Year = updatedCar.Year != default ? updatedCar.Year : car.Year;
            car.Km = updatedCar.Km != default ? updatedCar.Km : car.Km;
            car.Price = updatedCar.Price != default ? updatedCar.Price : car.Price;
            return Ok();
        }
        //Yalnızca aracın satış fiyatını değiştirmek için kullanılan Patch metodu.
        [HttpPatch("{id}")]
        public IActionResult PatchCar(int id, [FromBody] Cars patchCars)
        {
            var carEdit = CarsList.SingleOrDefault(x => x.Id == id);
            if (carEdit is null)
            {
                return BadRequest();
            }
            carEdit.Price = patchCars.Price;
            return Ok();
        }
        //Belirli bir ID numaralı aracı silmek için kullanılan DELETE metodu.
        [HttpDelete]
        public IActionResult DeleteCar([FromQuery] int id)
        {
            var car = CarsList.SingleOrDefault(x => x.Id == id);
            if (car is null)
            {
                return BadRequest();
            }
            CarsList.Remove(car);
            return Ok();
        }
        //Aracın model ismini girerek aynı isimli tüm araçları listeleyen GET metodu.
        [HttpGet("listCarModel")]
        public ActionResult<List<Cars>> GetByFilter([FromQuery] string filter)
        {
            var searchCar = CarsList.SingleOrDefault(x => x.Model.Contains(filter));
            if (searchCar is null)
            {
                return NotFound();
            }
            return Ok(searchCar);
        }
        //Tüm araçları üretim yıllarına göre eskiden yeniye doğru sıralayan GET metodu. 
        [HttpGet("orderByYear")]
        public IActionResult OrderByYear()
        {
            var orderByYear = CarsList.OrderBy(x => x.Year);
            return Ok(orderByYear);
        }
    }
}
