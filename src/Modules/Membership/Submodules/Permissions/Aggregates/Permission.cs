namespace Membership.Submodules.Permissions;

public class Permission : Aggregate<Guid>
{
    public string Name { get; private set; }
    public Guid ModuleId { get; private set; }
    public bool Status { get; private set; }
    public string Key { get; private set; }
    public string? Description { get; private set; }

    private readonly List<PermissionAction> _actions = new();
    public IReadOnlyList<PermissionAction> Actions => _actions.AsReadOnly();

    private Permission(
        Guid id,
        string name,
        Guid moduleId,
        string key,
        string? description,
        bool status
    )
    {
        Id = id;
        Name = name;
        ModuleId = moduleId;
        Description = description;
        Key = key;
        Status = status;
    }

    public static Permission Create(string name, Guid moduleId, string key, string? description)
    {
        Guid id = Guid.NewGuid();
        const bool status = true;

        return new Permission(id, name, moduleId, key, description, status);
    }

    public void AddActions(Guid actionId)
    {
        PermissionAction permissionAction = PermissionAction.Create(Id, actionId);
        _actions.Add(permissionAction);
    }

    public void RemoveActions(Guid actionId)
    {
        PermissionAction? permissionAction = _actions.FirstOrDefault(x => x.ActionId == actionId);

        if (permissionAction != null)
            _actions.Remove(permissionAction);
    }

    public void Activate()
    {
        if (Status == false)
            Status = true;
    }

    public void Update(string name, Guid moduleId, string key, string? description)
    {
        Name = name;
        ModuleId = moduleId;
        Key = key;
        Description = description;
    }

    public void Delete()
    {
        if (Status == true)
            Status = false;
    }
}
