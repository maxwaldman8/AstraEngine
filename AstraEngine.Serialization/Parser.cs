using System.Reflection;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace AstraEngine.Serialization;

public class Parser {
    public static T Deserialize<T>(string input) => new DeserializerBuilder().WithNodeTypeResolver(new StringToType()).Build().Deserialize<T>(input);
}

internal class StringToType : INodeTypeResolver {
    public bool Resolve(NodeEvent? nodeEvent, ref Type currentType) {
        try {
            if (nodeEvent!.Tag.ToString()[0] == '!') {
                currentType = Type.GetType(
                    Type.GetType(nodeEvent!.Tag.ToString()[1..]) == null
                    ? $"{nodeEvent!.Tag.ToString()[1..]}, {Assembly.GetEntryAssembly()}"
                    : nodeEvent!.Tag.ToString()[1..]
                )!;
            }
        } catch {
            Console.WriteLine("Invalid Type!");
            return false;
        }
        return true;
    }
}