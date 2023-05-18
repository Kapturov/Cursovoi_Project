using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        System.AppContext ac = new AppContext();
        List<Client> list = new List<Client>();
        string result = "";

        [HttpGet]
        public string Get()
        {
            result = "";
            list = ac.Clients.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                result += $"Id: {list[i].IdClient}, FIO: {list[i].Fio}, Phone: {list[i].Phone}, Address: {list[i].Address} \n";
            }
            return result;
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            result = "";
            list = ac.Clients.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdClient == id) 
                {result += $"Id: {list[i].IdClient}, FIO: {list[i].Fio}, Phone: {list[i].Phone}, Address: {list[i].Address} \n";
            }
            }
                return result;
        }

        
        [HttpPost]
        public void Post(string fio, string phone, string address)
        {
            Client c = new Client { Fio = fio, Address=address, Phone=phone };
            ac.Clients.Add(c);
            ac.SaveChanges();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, string fio, string phone, string address)
        {

            list = ac.Clients.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdClient == id)
                {
                    list[i].Fio = fio;
                    list[i].Phone = phone;
                    list[i].Address = address;
                    ac.SaveChanges();
                }
            }
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ac.Clients.Where(u => u.IdClient == id).ExecuteDelete();
            ac.SaveChanges();
        }
    }
}
