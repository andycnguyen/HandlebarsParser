using Sprache;

namespace HandlebarsParser
{
    public class HandlebarsVariable : HandlebarsExpression, IPositionAware<HandlebarsVariable>
    {
        public HandlebarsVariable(string name, HandlebarsVariable child = null)
        {
            Name = name;
            Child = child;
        }

        public string Name { get; private set; }
        public HandlebarsVariable Child { get; private set; }

        public new HandlebarsVariable SetPos(Position position, int length)
        {
            return base.SetPos(position, length) as HandlebarsVariable;
        }
    }

    public static partial class HandlebarsGrammar
    {
        internal static Parser<HandlebarsVariable> HandlebarsVariable =>
            (from identifier in HandlebarsIdentifier.Token()
             from child in Parse.Char('.').Then(_ => HandlebarsVariable).Optional()
             select new HandlebarsVariable(identifier.Name, child.GetOrDefault())).Positioned();
    }
}
