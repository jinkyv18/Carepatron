using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class ClientDTO : ClientBase
    {
        [Required]
        public string Id { get; set; }
    }

    public class ClientBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }

    public class ClientCreateRequest : ClientBase
    {
    }
}

