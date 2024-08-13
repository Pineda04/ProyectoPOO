namespace ProyectoViajes.API.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}