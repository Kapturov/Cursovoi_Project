using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalApp;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        AppContext ac = new AppContext();
        List <Car> list = new List<Car>();
        string result="";


        [HttpGet]
        public string GetCars()
        {
            result = "";
            list = ac.Cars.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                result += $"Id: {list[i].IdCar}, Model: {list[i].Model}, RegNum: {list[i].RegNum}, Price: {list[i].Price}, Year: {list[i].Year} \n";
            }
            return result;
        }

        [HttpGet("{id}")]
        public string GetCar(int id)
        {
            result = "";
            list = ac.Cars.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdCar== id)
             { result += $"Id: {list[i].IdCar}, Model: {list[i].Model}, RegNum: {list[i].RegNum}, Price: {list[i].Price}, Year: {list[i].Year} \n"; }
                
            }
            return result;
        }

        [HttpPut("{id}")]
        public void PutCar(int id, string model, string regnum, double price, int year)
        {
            list = ac.Cars.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdCar == id)
                {
                    list[i].Model = model;
                    list[i].RegNum = regnum;
                    list[i].Price = price;
                    list[i].Year = year;    
                    ac.SaveChanges();
                }
            }

        }

        [HttpPost]
        public void PostCar(string model, string regnum,double price, int year )
        {
            Car c = new Car { Model= model, RegNum=regnum, Price=price, Year=year };
            ac.Cars.Add(c);
            ac.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteCar(int id)
        {
            ac.Cars.Where(u => u.IdCar == id).ExecuteDelete();
            ac.SaveChanges();
        }
    }
}
