namespace EmployerPortal.Domain.Entities;

public class User
{
    public User(string username, string name)
    {
        Id = Guid.NewGuid();
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    protected User() { }

    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
}