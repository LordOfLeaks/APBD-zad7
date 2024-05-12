using Microsoft.EntityFrameworkCore;

namespace Zadanie7.Models;

public class ClientTripRepository
{

    private readonly DbContext _dbContext;

    public ClientTripRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ClientTrip> AddClientTrip(ClientTrip newTrip)
    {
        _dbContext.Add(newTrip);
        await _dbContext.SaveChangesAsync();
        return newTrip;
    }
}