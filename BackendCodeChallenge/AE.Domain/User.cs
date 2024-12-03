using AE.Domain.Common;

namespace AE.Domain;

public class User : BaseEntity
{
    public User()
    {
        Ships = new();
    }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public List<Ship> Ships { get; set; }
}
