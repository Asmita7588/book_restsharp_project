using System.Net;
using BookRestSharp;
using Newtonsoft.Json;
using RestSharp;

internal class Program
{
    private static RestClient client;
    private static async Task Main(string[] args)
    {
        //var client = new RestClient("http://localhost:3000");
        //// Get data from json file 
        //var request = new RestRequest("Books", Method.Get);
        //var response =   client.Execute(request);

        //if(response.StatusCode == HttpStatusCode.OK)
        //{
        //    Console.WriteLine("Data retrived successfully");
        //    List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(response.Content);

        //    if (bookList != null) {
        //        foreach (var book in bookList) { 
        //            Console.WriteLine($"Id = {book.id}, title = {book.title}, author = {book.author}, avilable = {book.available}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Book not found status : {response.StatusCode}");
        //    }

        //}
        client = new RestClient("http://localhost:3000");
        Console.WriteLine("Adding new book :");
        await AddNewBook("Letting go", "dravid", "false");
    }
    private static async Task AddNewBook(string title, string author,string available)
    {
        var request = new RestRequest("Books", Method.Post);

        var jsonObj = new { 

            title = title,
            author = author,
            available = available
        };

        request.AddJsonBody(jsonObj);

        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == HttpStatusCode.Created)
        {
            var bookData = JsonConvert.DeserializeObject<Book>(response.Content);
            if (bookData != null)
            {
                Console.WriteLine($"Id = {bookData.Id}, author = {bookData.Author}, title = {bookData.Title}, available = {bookData.Available}");
            }
        }
        else
        {
            Console.WriteLine($"Error : {response.StatusCode} , Message : {response.Content}");
        }
    }
}