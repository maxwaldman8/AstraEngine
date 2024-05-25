using System.Diagnostics.CodeAnalysis;

namespace AstraEngine.Core;

/// <summary>
/// An <see cref="Entity"/> is an container that represents an object within the game world. Entities serve as
/// containers for <see cref="Component"/>s, which define their behavior, properties, and interactions.  
/// </summary>
public class Entity
{
    /// <summary>Name for this <see cref="Entity"/></summary>
    public string Name { get; set; } = String.Empty;
    /// <summary>Whether or not this <see cref="Entity"/> is active</summary>
    public bool IsActive { get; set; } = true;
    private readonly HashSet<Component> _uninitializedComponents = [];
    private readonly HashSet<Component> _components = [];
    /// <summary>An enumerable containing all of the <see cref="Component"/>s attached to this <see cref="Entity"/></summary>
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
    /// <summary>An enumerable containing all of the children of this <see cref="Entity"/></summary>
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
    /// <param name="component">The <see cref="Component"/> that was found</param>
    /// <returns>true if a <see cref="Component"/> of the specified type was found and false otherwise</returns>
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
    /// <returns>T if a <see cref="Component"/> of the specified type was found and null otherwise</returns>
    public T? GetComponent<T>() where T : Component
    {
        foreach (var c in _components)
        {
            if (c is T found) { return found; }
        }
        return null;
    }

    /// <summary>
    /// Retrieves all <see cref="Component"/>s of the specified type that are attached to this <see cref="Entity"/>.
    /// </summary>
    /// 
    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return _components.Where(c => c is T).Cast<T>();
    }

    /// <summary>
    /// Returns an enumerable of all <see cref="Component"/>s of the specified type attached to this <see cref="Entity"/> and all of its children
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
    /// Attach the specified <see cref="Component"/> to this <see cref="Entity"/>.
    /// </summary>
    /// <param name="component">The <see cref="Component"/> to attach</param>
    /// <returns>true if the <see cref="Component"/> was added and false if the <see cref="Component"/> was already present</returns>
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
    /// Detach the specified <see cref="Component"/> from this <see cref="Entity"/> if it is present.
    /// </summary>
    /// <param name="component">The <see cref="Component"/> to detach</param>
    /// <returns>true if the <see cref="Component"/> was found and removed and false otherwise.</returns>
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
    /// Executed when the game first starts
    /// </summary>
    public void Start()
    {
        if (!IsActive) { return; }

        // Start each component
        foreach (var component in _components) if (component.IsActive) { component.Start(); }

        // Start each child
        foreach (var child in _children) { child.Start(); }
    }

    /// <summary>
    /// Apply's time based changes to this <see cref="Entity"/> by first performing a tick
    /// on each of its <see cref="Component"/>s then calling tick on each child.
    /// </summary>
    /// <param name="deltaTime">The amount of time in seconds that has passed</param>
    public void Tick(double deltaTime)
    {
        if (!IsActive) { return; }

        // All uninitialized components are initialized
        InitializeComponents();

        // Tick each component
        foreach (var component in _components) if (component.IsActive) { component.Tick(deltaTime); }

        // Tick each child
        foreach (var child in _children) { child.Tick(deltaTime); }
    }

    /// <summary>
    /// Executed when this <see cref="Entity"/> exits the game
    /// </summary>
    public void Exit()
    {
        // Exit each component
        foreach (var component in _components) { component.Exit(); }

        // Exit each child
        foreach (var child in _children) { child.Exit(); }
    }

    /// <summary>
    /// Executed when the game ends
    /// </summary>
    public void End()
    {
        if (!IsActive) { return; }

        // Start each component
        foreach (var component in _components) if (component.IsActive) { component.End(); }

        // Start each child
        foreach (var child in _children) { child.End(); }
    }

    private void InitializeComponents()
    {
        IEnumerable<Component> components = [.. _uninitializedComponents];
        _uninitializedComponents.Clear();
        foreach (var component in components) { component.Initialize(); }
        foreach (var child in _children) { child.InitializeComponents(); }
    }

    /// <summary>
    /// Retrieves a child with the specified name.
    /// </summary>
    /// <param name="name">The name to search for</param>
    /// <param name="child">The child that was found</param>
    /// <returns>true if a <see cref="Component"/> of the specified type was found and false otherwise</returns>
    public bool TryGetChild(string name, [NotNullWhen(true)] out Entity? child)
    {
        foreach (var c in _children)
        {
            if (c.Name == name)
            {
                child = c;
                return true;
            }
        }
        child = null;
        return false;
    }

    /// <summary>
    /// Retrieves a child with the specified name.
    /// </summary>
    /// <param name="name">The name to search for</param>
    /// <returns><see cref="Entity"/> if a child with the specified name was found and null otherwise</returns>
    public Entity? GetChild(string name)
    {
        foreach (var c in _children)
        {
            if (c.Name == name) { return c; }
        }
        return null;
    }

    /// <summary>
    /// Retrieves one of this <see cref="Entity"/>'s children
    /// </summary>
    /// <param name="index">Index of child to retrieve</param>
    /// <returns><see cref="Entity"/> if this <see cref="Entity"/>'s child at index exists else null</returns>
    public Entity? GetChild(int index)
    {
        return Children.ToArray()[index];
    }

    /// <summary>
    /// Returns an enumerable of all children with the specified name
    /// </summary>
    /// <param name="name">Name to filter by</param>
    /// <returns>IEnumerable‹<see cref="Entity"/>›</returns>
    public IEnumerable<Entity> GetChildren(string name)
    {
        return _children.Where(c => c.Name == name);
    }

    /// <summary>
    /// Adds the specified Entity as a child of this component
    /// </summary>
    /// <param name="player"><see cref="Entity"/> to add as a child</param>
    /// <returns>true if the child was added and false if the child was already present</returns>
    public bool AddChild(Entity player)
    {
        if (_children.Add(player))
        {
            player.Parent = this;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Removes the specified Entity as a child of this component
    /// </summary>
    /// <param name="player">Child to remove</param>
    /// <returns>true if the child was found and removed and false otherwise.</returns>
    public bool RemoveChild(Entity player)
    {
        if (_children.Remove(player))
        {
            player.Exit();
            player.Parent = null;
            return true;
        }
        return false;
    }
}