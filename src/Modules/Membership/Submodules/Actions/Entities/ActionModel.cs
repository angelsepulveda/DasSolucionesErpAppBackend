namespace Membership.Submodules.Actions;

public class ActionModel : Entity<Guid>
{
    public string Name { get; private set; }
    public bool Status { get; private set; }

    private ActionModel(Guid id, string name, bool status)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public static ActionModel Create(string name)
    {
        Guid id = Guid.NewGuid();
        const bool status = true;

        return new ActionModel(id, name, status);
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
