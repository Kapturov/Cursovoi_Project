using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        System.AppContext ac = new AppContext();
        List<Order> list = new List<Order>();
        string result = "";

        [HttpGet]
        public string Get()
        {
            result = "";
            list = ac.Orders.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                result += $"Id: {list[i].IdOrder}, IdCar: {list[i].IdCar}, IdClient: {list[i].IdClient}, Hours: {list[i].Hours}, Summa: {list[i].Summa}\n";
            }
            return result;
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            result = "";
            list = ac.Orders.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].IdOrder == id)
                result += $"Id: {list[i].IdOrder}, IdCar: {list[i].IdCar}, IdClient: {list[i].IdClient}, Hours: {list[i].Hours}, Summa: {list[i].Summa}\n";
            }
            return result;
        }

        
        [HttpPost]
        public void Post(int IdCar, int IdClient, int hours, double summa)
        {
            Order o = new Order { IdClient = IdClient, IdCar=IdCar, Hours=hours, Summa=summa };
            ac.Orders.Add(o);
            ac.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, int IdCar, int IdClient, int hours, double summa)
        {
            list = ac.Orders.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdOrder == id)
                {
                    list[i].IdCar = IdCar;
                    list[i].Hours = hours;
                    list[i].Summa = summa;
                    list[i].IdClient=IdClient;
                    ac.SaveChanges();
                }
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ac.Orders.Where(u => u.IdOrder == id).ExecuteDelete();
            ac.SaveChanges();
        }
    }
}
