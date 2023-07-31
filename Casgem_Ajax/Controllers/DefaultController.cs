using Casgem_Ajax.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Casgem_Ajax.Controllers
{
    public class DefaultController : Controller
    {
        Context Context = new Context();
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult CustomerList()
        {

            var jsonCustomer = JsonConvert.SerializeObject(Context.Customers.ToList());
            return Json(jsonCustomer);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            Context.Customers.Add(customer);
            Context.SaveChanges();  
            var values = JsonConvert.SerializeObject(Context.Customers);
            return Json(values);


        }
		public IActionResult DeleteCustomer(int id)
		{
			var value = Context.Customers.Find(id);
			Context.Customers.Remove(value);
			Context.SaveChanges();
			return NoContent();
		}

		public IActionResult GetCustomer(int CustomerID)
		{
			var values = Context.Customers.Find(CustomerID);
			var jsonValues = JsonConvert.SerializeObject(values);
			return Json(jsonValues);
		}
	}
}
