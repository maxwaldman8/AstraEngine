using System.Reflection;

using AstraEngine.Core;
using AstraEngine.Canvas2D;

using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Core;

namespace AstraEngine.Serialization;

/// <summary>
/// Utility class for YAML parsing
/// </summary>
public static class YAMLUtils
{
    /// <summary>
    /// Gets type from string and searches all assemblies
    /// </summary>
    /// <param name="type">Name of the type to search for</param>
    /// <returns>Type if type was found else null</returns>
    internal static Type? GetType(string type)
    {
        if (Type.GetType(type) != null) { return Type.GetType(type); }
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly assembly in assemblies)
        {
            if (Type.GetType($"{type}, {assembly}") != null) { return Type.GetType($"{type}, {assembly}"); }
        }
        return null;
    }

    /// <summary>
    /// Deserializes entity from YAML string
    /// </summary>
    /// <param name="input">YAML input</param>
    /// <returns>Entity</returns>
    public static Entity DeserializeEntity(string input) => new DeserializerBuilder().WithNodeTypeResolver(new StringToType()).WithTypeConverter(new ColorConverter()).Build().Deserialize<SerializableEntity>(input).ToEntity();

    /// <summary>
    /// Deserializes entity from YAML file
    /// </summary>
    /// <param name="path">Path to input file</param>
    /// <returns>Entity</returns>
    public static Entity DeserializeEntityFromFile(string path) => new DeserializerBuilder().WithNodeTypeResolver(new StringToType()).WithTypeConverter(new ColorConverter()).Build().Deserialize<SerializableEntity>(File.ReadAllText(path)).ToEntity();
}

internal class StringToType : INodeTypeResolver
{
    public bool Resolve(NodeEvent? nodeEvent, ref Type currentType)
    {
        if (nodeEvent!.Tag.ToString()[0] == '!')
        {
            Type? type = YAMLUtils.GetType(nodeEvent!.Tag.ToString()[1..]);
            if (type != null) { currentType = type; }
            else { return false; }
        }
        return true;
    }
}

internal class ColorConverter : IYamlTypeConverter
{
    public static readonly IYamlTypeConverter Instance = new ColorConverter();

    public bool Accepts(Type type)
    {
        return type == typeof(Color);
    }

    public object? ReadYaml(IParser parser, Type type)
    {
        if (parser.Current!.GetType() == typeof(MappingStart))
        {
            parser.Consume<MappingStart>();

            parser.Consume<Scalar>();
            byte r = byte.Parse(parser.Consume<Scalar>().Value);

            parser.Consume<Scalar>();
            byte g = byte.Parse(parser.Consume<Scalar>().Value);

            parser.Consume<Scalar>();
            byte b = byte.Parse(parser.Consume<Scalar>().Value);

            parser.Consume<MappingEnd>();
            return new Color(r, g, b, 1);
        }
        else
        {
            return Color.FromString(parser.Consume<Scalar>().Value);
        }
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type) { }
}