﻿using GameStore.Web.Models;

namespace GameStore.Web.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync() 
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ??
           throw new Exception("Game is not found");
    
    public async Task UpdateGameAsync(GameDetails updatedGame)
        => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");
   
}