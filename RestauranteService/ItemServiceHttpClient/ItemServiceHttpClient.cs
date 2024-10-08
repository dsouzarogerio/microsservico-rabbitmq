﻿using RestauranteService.Dtos;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient;

public class ItemServiceHttpClient : IItemServiceHttpClient
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public async void EnviaRestauranteParaItemService(ReadRestauranteDto readRestauranteDto)
    {
        var conteudoHttp = new StringContent
            (
                JsonSerializer.Serialize(readRestauranteDto), 
                    Encoding.UTF8, 
                    "application/json"
            );
        await _client.PostAsync(_configuration["ItemService"], conteudoHttp);
    }
}
