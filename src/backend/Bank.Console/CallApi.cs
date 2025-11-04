using Bank.Infra.repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Bank.Infra.repository.interfaces;
using System.IO;
using Bank.Domain;


class Program
{
    public static async Task Main(string[] args)
    {
         var client = new HttpClient();
        client.Timeout = TimeSpan.FromMinutes(10);   
        try
        {
            //pega setings json string connection
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory()) // define o caminho base
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();    

            ///injete a dependencia
            var services = new ServiceCollection();
            services.AddInfra(configuration);

            // Construir o provedor
            var provider = services.BuildServiceProvider();

            // Resolver e executar o serviço
            var servico = provider.GetRequiredService<IItenRepository>();
            var save = provider.GetRequiredService<IUnitOfWork>();


            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://api.andbank.com.br/candidate/positions"
            );
            request.Headers.Add("x-Test-Key", "9MsyhgyioqtMLUiUFRNm");

            using var response = await client.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead
            );
            response.EnsureSuccessStatusCode();

    
            await using var stream = await response.Content.ReadAsStreamAsync();

            Console.WriteLine("Buscando dados da API.... isso pode levar lguns minutos");
            await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<Item>(stream))
            {
                if (item?.value == null || item.positionId==null || item.date==null)
                    continue;
                item.date = DateTime.SpecifyKind(item.date, DateTimeKind.Utc);
                 await servico.AddItem(item);
            }
            Console.WriteLine("Salvando os dados isso pode levar lguns minutos");
            //await save.Commit();
            Console.WriteLine("Processo concluido");



        }
        catch (HttpRequestException ex)
        {
            Console.Error.WriteLine($"Erro HTTP: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.Error.WriteLine($"Erro de parsing JSON: {ex.Message}");
        }
        catch (OperationCanceledException)
        {
            Console.Error.WriteLine("Operação cancelada (timeout/cancelamento externo).");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro inesperado: {ex}");
        }
    }
}
