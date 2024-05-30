using Shouldly;
using Xunit;

using AstraEngine.Core;
using AstraEngine.Serialization;
using AstraEngine.Canvas2D;

namespace AstraEngine.Tests;

public class CustomComponent : Component { }

public class SerializationTests
{
    [Fact]
    public void NotRealComponentShouldNotDeserialize()
    {
        bool pass = false;
        try
        {
            YAMLUtils.DeserializeEntity("!NotARealType {}");
        }
        catch (YamlDotNet.Core.YamlException)
        {
            pass = true;
        }
        Assert.True(pass);
    }

    [Fact]
    public void RealComponentShouldDeserialize()
    {
        YAMLUtils.DeserializeEntity("Name: Entity\nComponents:\n- !AstraEngine.Canvas2D.View {}");
        Assert.True(true);
    }

    [Fact]
    public void CustomComponentShouldDeserialize()
    {
        YAMLUtils.DeserializeEntity("Name: Entity\nComponents:\n- !AstraEngine.Tests.CustomComponent {}");
        Assert.True(true);
    }

    [Fact]
    public void ExampleHierarchyShouldDeserialize()
    {
        string exampleHierarchy = """
            Name: Root
            Components:
            - !AstraEngine.Canvas2D.View
              Canvas: !AstraEngine.Canvas2D.RaylibCanvas2D {}
            Children:
            - Name: Player
              Components:
              - !AstraEngine.Canvas2D.Rectangle2D
                Width: 50
                Height: 50
                Color: White
              - !AstraEngine.Canvas2D.Position2D
                X: 50
                Y: 50
        """;
        Entity root = YAMLUtils.DeserializeEntity(exampleHierarchy);
        root.Name.ShouldBe("Root");
        root.Components.ToArray()[0].GetType().ShouldBe(typeof(View));
        root.GetComponent<View>()!.Canvas!.ShouldNotBeNull();
        root.Children.ToArray()[0].Name.ShouldBe("Player");
        root.Children.ToArray()[0].GetComponent<Rectangle2D>()!.Width.ShouldBe(50);
        root.Children.ToArray()[0].GetComponent<Rectangle2D>()!.Height.ShouldBe(50);
        root.Children.ToArray()[0].GetComponent<Rectangle2D>()!.Color.ShouldBe(Color.White);
        root.Children.ToArray()[0].GetComponent<Position2D>()!.X.ShouldBe(50);
        root.Children.ToArray()[0].GetComponent<Position2D>()!.Y.ShouldBe(50);
    }
}