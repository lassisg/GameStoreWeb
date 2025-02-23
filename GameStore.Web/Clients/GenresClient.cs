﻿using GameStore.Web.Models;

namespace GameStore.Web.Clients;

public class GenresClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync() 
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
}