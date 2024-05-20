using BlazorConsumesApi.Client.Models;
using BlazorTest.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorConsumesApi.Client.Shared.Components.Products
{
    public partial class CreateProducts
    {
        [Parameter]
        public int? Id { get; set; }


        public List<CategoriesJson> lista { get; set; }

        CategoriesJson jason = new CategoriesJson();

        PostProductJson p = new PostProductJson();



        public async Task<List<CategoriesJson>> Get()
        {
            try
            {

                lista = await http.GetFromJsonAsync<List<CategoriesJson>>("api/Category/GetCategory");

                return lista;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }

        public async Task Create()
        {
            try
            {
                var jsoncontent = JsonSerializer.Serialize(p);
                var content = new StringContent(jsoncontent);

                await http.PostAsync("api/Product/PostProducts", content);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public async Task Edit(int id)
        {

        }



    }
}
