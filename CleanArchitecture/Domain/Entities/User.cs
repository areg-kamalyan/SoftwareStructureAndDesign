namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Private constructor for EF Core/serialization
        private User() { }

        public User(string email, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            Id = Guid.NewGuid();
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }

        // Domain behavior/method
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
