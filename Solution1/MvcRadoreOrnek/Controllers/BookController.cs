using Microsoft.AspNetCore.Mvc;
using MvcRadoreOrnek.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MvcRadoreOrnek.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Book> bookList = new List<Book>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5030/api/Book"))
                {
                    string getString = await response.Content.ReadAsStringAsync();
                    bookList = JsonConvert.DeserializeObject<List<Book>>(getString);
                }
            }

            return View(bookList);
        }

        public async Task<Book> BookDetails(int id)
        {
            Book getBookDetail = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5030/api/Book/" + id))
                {
                    string getBookDetailString = await response.Content.ReadAsStringAsync();
                    getBookDetail = JsonConvert.DeserializeObject<Book>(getBookDetailString);
                }
            }
            return getBookDetail;
        }

        public async Task<IActionResult> Details(int id)
        {
            var getBookDetail = await BookDetails(id);

            return View(getBookDetail);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent serializedBook = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5030/api/Book", serializedBook))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            //işlem başarılı
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var getBook = await BookDetails(id);
            return View(getBook);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent serializedBook = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("http://localhost:5030/api/Book", serializedBook))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            //işlem başarılı
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            TempData["message"] = $"{book.BookName} güncellendi.";
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var getBook = await BookDetails(id);

            return View(getBook);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5030/api/Book/" + id))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //işlem başarılı
                    }
                }
            }
            TempData["message"] = $"ID: {id} Silindi";
            return RedirectToAction("Index");
        }
    }
}