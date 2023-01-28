using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CopyableBenchmark;

internal static class SourceGenExtensions
{
    internal static bool IsDecoratedWithAttribute(
        this TypeDeclarationSyntax syntax, string attributeName) =>
        syntax.AttributeLists
            .SelectMany(x => x.Attributes)
            .Any(x => x.Name.ToString().ToLower() == attributeName);

    internal static string BuildDtoProperty(
        this PropertyDeclarationSyntax pds, Compilation compilation)
    {
        // get the symbol for this property from the semantic model
        var symbol = compilation
            .GetSemanticModel(pds.SyntaxTree)
            .GetDeclaredSymbol(pds);

        var property = (symbol as IPropertySymbol);
        // use the same type and name for the DTO properties as on the entity
        return $"public {property.Type.Name()} {property.Name} {{get; set;}}";
    }
    // instead of returning "System.Collections.Generic.IList<>", just condense it to "IList<>"
    // the namespace is already added in the usings block
    internal static string Name(this ITypeSymbol typeSymbol) =>
        typeSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
}