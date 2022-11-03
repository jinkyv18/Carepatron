using api.Models.SqlModel;

namespace api.Data
{
    public class DataSeeder
    {
        private readonly DataContext dataContext;

        public DataSeeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Create initial value for the datacontext in memory.
        /// </summary>
        public void Seed()
        {
            var clients = new List<Client>();

            clients.Add(new Client(Guid.NewGuid().ToString(), "John", "Smith", "john@gmail.com", "+18202820232"));
            clients.Add(new Client(Guid.NewGuid().ToString(), "John Stevens", "Hulk", "johnstevens@gmail.com", "+1820283296"));
            clients.Add(new Client(Guid.NewGuid().ToString(), "Steve", "Nash", "nash@gmail.com", "+18298231232"));
            clients.Add(new Client(Guid.NewGuid().ToString(), "Stephen", "King", "king@gmail.com", "+18202814672"));

            dataContext.AddRange(clients);
            dataContext.SaveChanges();
        }
    }
}

