using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

public class CustomerController : Controller
{


    private readonly HttpClient httpClient;

    public CustomerController()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
    }
    public IActionResult Index()
    {
        string apiUrl = "https://getinvoices.azurewebsites.net/api/Customers";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(apiUrl).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
            string apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
            return View(customers);
        }
        else
        {
            return View(new List<Customer>());
        }
    }

    public IActionResult Create()
    {
        return View(new Customer());
    }


    [HttpPost]
    public async Task<IActionResult> CreateCustomer(Customer customers)
    {
        string apiUrl = "https://getinvoices.azurewebsites.net/api/CreateCustomerList";

        using (HttpClient client = new HttpClient())
        {
            string json = JsonConvert.SerializeObject(customers);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new Customer());
            }
        }
    }


    public async Task<IActionResult> Delete(string id)
    {
        var response = await httpClient.DeleteAsync($"Customer/{id}");
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }



    public async Task<IActionResult> Edit(string id)
    {
        var response = await httpClient.GetAsync($"Customer/{id}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var customer = JsonConvert.DeserializeObject<Customer>(json);

        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, Customer customer)
    {
        if (ModelState.IsValid)
        {
            return View(customer);
        }

        var json = JsonConvert.SerializeObject(customer);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync($"Customer/{id}", content);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> Save(Customer customer)
    {
        
        string apiUrl = "https://getinvoices.azurewebsites.net/api/CreateCustomerList";

        using (HttpClient client = new HttpClient())
        {
            string json = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new Customer());
            }
        }
    }


}
