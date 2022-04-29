using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VolvoRefactor.Application.DataProviders;
using VolvoRefactor.IntegrationTests.MockedProviders;
using VolvoRefactor.WebApi.DTOs;
using Xunit;

namespace VolvoRefactor.IntegrationTests.Controllers
{
    public class TaxControllerTests
    {
        private WebApplicationFactory<WebApi.Startup> _factory;
        private HttpClient _client;

        public TaxControllerTests()
        {
            _factory = new WebApplicationFactory<WebApi.Startup>();
            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ITaxConfigurationProvider, TestTaxConfigurationProvider>();
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetTax_NotTollFreeVehicle_ReturnsExpectedValue()
        {
            //Arrange            
            var dto = new CongestionTaxDTO
            {
                VehicleType = "Car",
                City = "Custom",
                Dates = new DateTime[]
                {
                    new DateTime(2013,09,05,12,20,00),
                    new DateTime(2013,09,05,14,50,00),
                    new DateTime(2013,09,05,15,20,00),
                    new DateTime(2013,09,05,16,10,00)
                }
            };

            //Act
            var response = await _client.GetAsync($"https://localhost:44323/tax/congestion{CastToQuery(dto)}");
            var responseString = await response.Content.ReadAsStringAsync();
            var resultData = JsonSerializer.Deserialize<int>(responseString);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(39, resultData);

        }

        [Fact]
        public async Task GetTax_TollFreeVehicle_ReturnsZero()
        {
            //Arrange            
            var dto = new CongestionTaxDTO
            {
                VehicleType = "Motorbike",
                City = "Custom",
                Dates = new DateTime[]
                {
                    new DateTime(2013,09,05,12,20,00),
                    new DateTime(2013,09,05,14,50,00),
                    new DateTime(2013,09,05,15,20,00),
                    new DateTime(2013,09,05,16,10,00)
                }
            };

            //Act
            var response = await _client.GetAsync($"https://localhost:44323/tax/congestion{CastToQuery(dto)}");
            var responseString = await response.Content.ReadAsStringAsync();
            var resultData = JsonSerializer.Deserialize<int>(responseString);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(0, resultData);

        }

        [Fact]
        public async Task GetTax_HolidayMonth_ReturnsZero()
        {
            //Arrange            
            var dto = new CongestionTaxDTO
            {
                VehicleType = "Car",
                City = "Custom",
                Dates = new DateTime[]
                {
                    new DateTime(2013,07,05,12,20,00),
                    new DateTime(2013,07,05,14,50,00),
                    new DateTime(2013,07,05,15,20,00),
                    new DateTime(2013,07,05,16,10,00)
                }
            };

            //Act
            var response = await _client.GetAsync($"https://localhost:44323/tax/congestion{CastToQuery(dto)}");
            var responseString = await response.Content.ReadAsStringAsync();
            var resultData = JsonSerializer.Deserialize<int>(responseString);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(0, resultData);

        }

        private string CastToQuery(CongestionTaxDTO dto)
        {
            string query = $"?VehicleType={dto.VehicleType}&City={dto.City}";
            query += string.Join("", dto.Dates.Select(d => "&Dates=" + d.ToString("yyyy-MM-dd HH:mm:ss")));
            return query;
        }
    }
}
