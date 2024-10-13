using System.Text;

HttpClient client = new();

HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://learn.javascript.ru/");
Console.WriteLine($"Request Method: {requestMessage.Method}");
Console.WriteLine($"Request Version: {requestMessage.Version}");
Console.WriteLine("Request Headers:");
foreach (var header in requestMessage.Headers)
    Console.WriteLine($"\t{header.Key}: {header.Value}");
Console.WriteLine($"Request Content: {requestMessage.Content}");
Console.WriteLine($"\n{new String('*', 50)}\n");

//HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

//HttpResponseMessage responseMessage = await client.GetAsync("https://learn.javascript.ru/");
//Console.WriteLine($"Status: {responseMessage.StatusCode}");
//Console.WriteLine("Response Headers:");
//foreach (var header in responseMessage.Headers)
//{
//    Console.WriteLine($"\t{header.Key}:");
//    foreach (var value in header.Value)
//        Console.WriteLine($"\t\t{value}");
//}
//Console.WriteLine($"Request Content: {await responseMessage.Content.ReadAsStringAsync()}");

//string responseString = await client.GetStringAsync("https://learn.javascript.ru/");
//Console.WriteLine(responseString);

//byte[] responseBytes = await client.GetByteArrayAsync("https://learn.javascript.ru/");
//Console.WriteLine(Encoding.UTF8.GetString(responseBytes));

using (Stream stream = await client.GetStreamAsync("https://learn.javascript.ru/"))
{
    StreamReader reader = new StreamReader(stream);
    //Console.WriteLine(await reader.ReadToEndAsync());
    using (StreamWriter file = new("file_html.txt", false))
    {
        await file.WriteAsync(await reader.ReadToEndAsync());

    }
}


