public class SnakeCaseParameterTransformer : IOutboundParameterTransformer {
  public string? TransformOutbound(object? value) {
    if (value == null) return null;

    var str = value.ToString()!;
    return System.Text.RegularExpressions.Regex
        .Replace(str, "([a-z])([A-Z])", "$1_$2")
        .ToLower();
  }
}