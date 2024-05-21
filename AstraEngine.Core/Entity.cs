using System.Diagnostics.CodeAnalysis;

namespace AstraEngine.Core;

/// <summary>
/// An <see cref="Entity"/> is an container that represents an object  within the game world. Entities serve as
/// containers for components, which define their behavior, properties, and interactions.  
/// </summary>
public class Entity
{
    private readonly HashSet<Component> _uninitializedComponents = [];
    private readonly HashSet<Component> _components = [];
    /// <summary>An enumerable containing all of the components attached to this <see cref="Entity"/>.</summary>
    public IEnumerable<Component> Components
    {
        get => _components;
        init
        {
            foreach (var component in value)
            {
                AttachComponent(component);
            }
        }
    }
    private HashSet<Entity> _children = [];
    /// <summary>An enumerable containing all of the children of this <see cref="Entity"/> </summary>
    public IEnumerable<Entity> Children
    {
        get => _children;
        init => _children = [.. value];
    }

    private Entity? _parent;
    /// <summary>This <see cref="Entity"/>'s parent</summary>
    public Entity? Parent
    {
        get => _parent;
        set
        {
            if (_parent == value) { return; }
            if (value is Entity parent)
            {
                _parent?._children.Remove(this);
                parent._children.Add(this);
            }
            _parent = value;
        }
    }

    /// <summary>
    /// Retrieves a <see cref="Component"/> of the specified type that is attached to this <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Component"/> to retrieve.</typeparam>
    /// <param name="component">The component that was found</param>
    /// <returns>true if a component of the specified type was found and false otherwise</returns>
    public bool TryGetComponent<T>([NotNullWhen(true)] out T? component) where T : Component
    {
        foreach (var c in _components)
        {
            if (c is T found)
            {
                component = found;
                return true;
            }
        }
        component = null;
        return false;
    }

    /// <summary>
    /// Retrieves a <see cref="Component"/> of the specified type that is attached to this <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Component"/> to retrieve.</typeparam>
    /// <returns>T if a component of the specified type was found and null otherwise</returns>
    public T? GetComponent<T>() where T : Component
    {
        foreach (var c in _components)
        {
            if (c is T found) { return found; }
        }
        return null;
    }

    /// <summary>
    /// Returns an enumerable of all components of the specified type
    /// </summary>
    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return _components.Where(c => c is T).Cast<T>();
    }

    /// <summary>
    /// Returns an enumerable of all components of the specified type in this component and all children
    /// </summary>
    public IEnumerable<T> GetComponentsInChildren<T>() where T : Component
    {
        IEnumerable<T> components = GetComponents<T>();
        foreach (var c in _children)
        {
            components = components.Concat(c.GetComponentsInChildren<T>());
        }
        return components;
    }

    /// <summary>
    /// Attach the specified component to this <see cref="Entity"/>.
    /// </summary>
    /// <param name="component">The component to attach</param>
    /// <returns>true if the component was added and false if the component was already present</returns>
    public bool AttachComponent(Component component)
    {
        if (_components.Add(component))
        {
            component.Entity = this;
            _ = _uninitializedComponents.Add(component);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Detach the specified component from this <see cref="Entity"/> if it is present.
    /// </summary>
    /// <param name="component">The component to detach</param>
    /// <returns>true if the component was found and removed and false otherwise.</returns>
    public bool DetachComponent(Component component)
    {
        if (_components.Remove(component))
        {
            _ = _uninitializedComponents.Remove(component);
            component.Entity = null;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Apply's time based changes to this <see cref="Entity"/> by first performing a tick
    /// on each of its <see cref="Component"/>s then calling tick on each child.
    /// </summary>
    /// <param name="deltaTime">The amount of time in seconds that has passed</param>
    public void Tick(double deltaTime)
    {
        // All uninitialized components are initialized
        IEnumerable<Component> components = [.. _uninitializedComponents];
        _uninitializedComponents.Clear();
        foreach (var component in components) { component.Initialize(); }

        // Tick each component
        foreach (var component in _components) { component.Tick(deltaTime); }

        // Tick each child
        foreach (var child in _children) { child.Tick(deltaTime); }
    }

    /// <summary>
    /// Adds the specified Entity as a child of this component
    /// </summary>
    /// <param name="player"></param>
    public void AddChild(Entity player)
    {
        player.Parent = this;
    }
}