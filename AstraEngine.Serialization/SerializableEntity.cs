using AstraEngine.Core;

namespace AstraEngine.Serialization;

internal class SerializableEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public List<Component> Components { get; set; } = [];
    public List<SerializableEntity> Children { get; set; } = [];
    public SerializableEntity? Parent { get; set; }

    internal Entity ToEntity()
    {
        Entity entity = new()
        {
            Name = Name,
            IsActive = IsActive
        };
        foreach (Component component in Components)
        {
            entity.AttachComponent(component);
        }
        foreach (SerializableEntity child in Children)
        {
            entity.AddChild(child.ToEntity());
        }
        return entity;
    }
}