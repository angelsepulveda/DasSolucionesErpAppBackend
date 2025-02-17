namespace Membership.Submodules.Modules.Models;

public class ModuleModel : Entity<Guid>
{
    public string Name { get; private set; }
    public bool Status { get; private set; }

    private ModuleModel(Guid id, string name, bool status)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public static ModuleModel Create(string name)
    {
        Guid id = Guid.NewGuid();
        const bool status = true;

        return new ModuleModel(id, name, status);
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void Delete()
    {
        if (Status == true)
            Status = false;
    }
}
