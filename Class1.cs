using Newtonsoft.Json;
using ProjetoEmpreiteira.Model;
using System;
using System.Net.Http;
using System.Text;

public class ClienteServices
{
	public void SalvarClienteServices(Cliente cliente)
	{
		HttpClient httpclient = new HttpClient();
		HttpResponseMessage response;

		var json = JsonConvert.SerializeObject(cliente);

		try
        {

			response = httpclient.PostAsync("https://localhost:44373/pessoas/save", new StringContent(json, Encoding.UTF8, "application/json")).Result;
			response.EnsureSuccessStatusCode();

			var resultado = response.Content.ReadAsStringAsync().Result;

		}
		catch (HttpRequestException ex)
        {

			Console.WriteLine(ex.Message);
        }

	}

	public void RemoverClienteServices(int id)
    {

		HttpClient httpclient = new HttpClient();
		HttpResponseMessage response;

        try
        {

			response = httpclient.DeleteAsync($"https://localhost:44373/pessoas/remover?nome={id}").Result;

			var resultado = response.Content.ReadAsStringAsync().Result;

			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				Console.WriteLine(resultado);
			}



		}
		catch(HttpRequestException ex)
        {

			Console.WriteLine(ex.Message);
        }
	
    }

	public void AtualizarClienteServices(int id)
    {

		HttpClient httpclient = new HttpClient();
		HttpResponseMessage response;


		try
        {
			var json = JsonConvert.SerializeObject(id);

			response = httpclient.PutAsync($"https://localhost:44373/pessoas/remover?nome={id}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

			var resultado = response.Content.ReadAsStringAsync().Result;


        }



    }
}
