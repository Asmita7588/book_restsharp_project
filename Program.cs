using System.Net;
using BookRestSharp;
using Newtonsoft.Json;
using RestSharp;

internal class Program
{
    private static RestClient client;
    private static void Main(string[] args)
    {
        var client = new RestClient("http://localhost:3000");
        // Get data from json file 
        var request = new RestRequest("Books", Method.Get);
        var response =   client.Execute(request);

        if(response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Data retrived successfully");
            List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(response.Content);

            if (bookList != null) {
                foreach (var book in bookList) { 
                    Console.WriteLine($"Id = {book.id}, title = {book.title}, author = {book.author}, avilable = {book.available}");
                }
            }
            else
            {
                Console.WriteLine($"Book not found status : {response.StatusCode}");
            }

        }
    }
}