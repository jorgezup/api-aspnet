using System;

namespace UserApi.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}