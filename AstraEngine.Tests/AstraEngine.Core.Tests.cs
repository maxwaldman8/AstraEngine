using Xunit;
using Shouldly;

using AstraEngine.Core;

namespace AstraEngine.Tests;

public class TickComponent : Component
{
    public int Ticked = 0;
    public override void Tick(double delta) => Ticked++;

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
        entity.AttachComponent(new TickComponent() { Active = false });
        entity.Tick(1);
        entity.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }

    [Fact]
    public void ChildShouldNotTickWhenNotActive()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.GetChild(0)!.AttachComponent(new TickComponent());
        entity.GetChild(0)!.Active = false;
        entity.Tick(1);
        entity.GetChild(0)!.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }

    [Fact]
    public void ChildShouldNotTickWhenParentIsNotActive()
    {
        Entity entity = new();
        entity.AddChild(new());
        entity.GetChild(0)!.AttachComponent(new TickComponent());
        entity.Active = false;
        entity.Tick(1);
        entity.GetChild(0)!.GetComponent<TickComponent>()!.Ticked.ShouldBe(0);
    }
}