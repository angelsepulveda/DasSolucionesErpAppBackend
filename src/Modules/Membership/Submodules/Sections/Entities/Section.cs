namespace Membership.Submodules.Sections;

public class Section : Entity<Guid>
{
    public string Name { get; private set; }
    public bool Status { get; private set; }
    public string Key { get; private set; }
    public string? Description { get; private set; }

    private Section(Guid id, string name, string key, string? description, bool status)
    {
        Id = id;
        Name = name;
        Description = description;
        Key = key;
        Status = status;
    }

    public static Section Create(string name, string key, string? description)
    {
        Guid id = Guid.NewGuid();
        const bool status = true;

        return new Section(id, name, key, description, status);
    }

    public void Update(string name, string key, string? description)
    {
        Name = name;
        Key = key;
        Description = description;
    }

    public void Delete()
    {
        if (Status == true)
            Status = false;
    }
}
