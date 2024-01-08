using Dapper;
using Domain.DTO.Requests;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TestIntegrations.Fixtures;
public class AbstractIntegrationTest : IClassFixture<APIWebApplicationFactory>
{
        protected readonly HttpClient _client;
        public AbstractIntegrationTest(APIWebApplicationFactory fixture)
        {
          
            _client = fixture.CreateClient();

            //Ouvrir connexion à la base de donnée
            //Drop la base de données
            //Fixer la base de données
        }


    public void Login()
    {

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
    }

   public void Logout()
    {
           _client.DefaultRequestHeaders.Authorization = null;
    }
}
