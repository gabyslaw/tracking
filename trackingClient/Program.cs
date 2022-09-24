// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using trackingClient;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7065");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/issue");
response.EnsureSuccessStatusCode();

if(response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
	foreach (var issue in issues)
	{
		Console.WriteLine(issue.Title);
	}
	

}
else
{
    Console.WriteLine("No results");
}
Console.ReadLine();
