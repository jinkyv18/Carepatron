using api.Data;
using api.Helper.Events;
using api.Models.SqlModel;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _dataContext;

        public ClientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Get all client the data from the Clients table in database.
        /// </summary>
        /// <returns>All client data from Clients table.</returns>
        public Task<List<Client>> GetAll()
        {
            return _dataContext.Clients.ToListAsync();
        }

        /// <summary>
        /// Create a new item for client, saves in database. Creates a new Guid for the Id.
        /// </summary>
        /// <returns>Returns true there is an item saved.</returns>
        public async Task<bool> Create(Client client)
        {
            client.Id = Guid.NewGuid().ToString();
            await _dataContext.AddAsync(client);
            var result = (await _dataContext.SaveChangesAsync()) > 0;

            //Raise and Event
            var counter = new Counter();
            //var counter = new Counter(new Random().Next(10));
            counter.ThresholdReached += Counter_ThresholdReached;
            counter.Check(_dataContext.Clients.Count());

            return result;
        }

        /// <summary>
        /// Update client data from Clients table.
        /// </summary>
        /// <returns>Returns true if changes successfully updated and false if the client to update cannot be found in the database.</returns>
        public async Task<bool> Update(Client client)
        {
            var existingClient = await _dataContext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (existingClient == null)
                return false;

            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.Email = client.Email;
            existingClient.PhoneNumber = client.PhoneNumber;

            await _dataContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Search for clients that contains the searched key for first name and last name in Clients table.
        /// </summary>
        /// <param name="searchKey">String to be searched.</param>
        /// <returns>The list of all clients filtered by search key.</returns>
        public async Task<List<Client>> Search(string searchKey)
        {
            return await _dataContext.Clients
                            .Where(a =>
                                    a.FirstName.ToLower().Contains(searchKey.ToLower()) ||
                                    a.LastName.ToLower().Contains(searchKey.ToLower())
                                  ).ToListAsync();
        }


        /// <summary>
        /// Event after creating a client, IF the threshold is reached.
        /// </summary>
        private void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }
    }
}

