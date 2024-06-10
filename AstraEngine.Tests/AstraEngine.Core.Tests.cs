using AstraEngine.Core;

using Shouldly;

using Xunit;

namespace AstraEngine.Tests;

internal class TickComponent : Component
{
    public int Ticked = 0;
    public override void Tick(double delta) => Ticked++;
}

internal class RemoveComponent : Component
{
    public override void Tick(double delta) => Entity.Parent!.RemoveChild(Entity);
}

internal class AddComponent : Component
{
    public override void Tick(double delta) => Entity.Parent!.AddChild(new Entity());
}

internal class AddTickComponent : Component
{
    public override void Tick(double delta) => Entity.AttachComponent(new TickComponent());
}

internal class RemoveSelfComponent : Component
{
    public override void Tick(double delta) => Entity.DetachComponent(this);
}

public class AstraEngineCoreTest
{
    [Fact]
    public void ComponentShouldTickWhenActive()
    {
        Entity entity = new();
        entity.AttachComponent(new TickComponent());
        entity.Tick(1);
        entity.GetComponent<TickComponent>()!.Ticked.ShouldBe(1);
    }

    [Fact]
    public void ComponentShouldNotTickWhenNotActive()
    {
        Entity entity = new();
        entity.AttachComponent(new TickComponent() { IsActive = false });
        entity.Tick(1);
        entity.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }

    [Fact]
    public void ChildShouldNotTickWhenNotActive()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.GetFirstChild()!.AttachComponent(new TickComponent());
        entity.GetFirstChild()!.IsActive = false;
        entity.Tick(1);
        entity.GetFirstChild()!.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }

    [Fact]
    public void ChildShouldNotTickWhenParentIsNotActive()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.GetFirstChild()!.AttachComponent(new TickComponent());
        entity.IsActive = false;
        entity.Tick(1);
        entity.GetFirstChild()!.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }

    [Fact]
    public void TickShouldNotThrowErrorWhenParentRemoved()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.AddChild(new());
        entity.GetFirstChild()!.AttachComponent(new RemoveComponent());
        entity.GetFirstChild()!.AttachComponent(new TickComponent());
        entity.Tick(1);
    }

    [Fact]
    public void TickShouldNotThrowErrorWhenSiblingAdded()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.AddChild(new());
        entity.GetFirstChild()!.AttachComponent(new AddComponent());
        entity.GetFirstChild()!.AttachComponent(new TickComponent());
        entity.Tick(1);
    }

    [Fact]
    public void ComponentShouldNotThrowErrorWhenRemoved()
    {
        Entity entity = new();
        entity.AttachComponent(new RemoveSelfComponent());
        entity.Tick(1);
        entity.Components.Count().ShouldBe(0);
    }

    [Fact]
    public void ComponentShouldNotTickWhenAdded()
    {
        Entity entity = new();
        entity.AttachComponent(new AddTickComponent());
        entity.Tick(1);
        entity.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
        entity.Tick(1);
        entity.GetComponent<TickComponent>()!.Ticked.ShouldBe(1);
    }
}