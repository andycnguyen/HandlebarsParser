using Sprache;

namespace HandlebarsParser
{
    public class HandlebarsIdentifier : HandlebarsExpression, IPositionAware<HandlebarsIdentifier>
    {
        public HandlebarsIdentifier(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public new HandlebarsIdentifier SetPos(Position position, int length)
        {
            return base.SetPos(position, length) as HandlebarsIdentifier;
        }
    }

    public static partial class HandlebarsGrammar
    {
        private static readonly char[] IllegalCharacters = new[]
        {
            '!', '"', '#', '%', '&',
            '\'', '(', ')', '*', '+',
            ',', '.', '/', ';', '<',
            '=', '>', '@', '[', '\\',
            ']', '^', '`', '}', '|',
            '}', '~'
        };

        internal static Parser<HandlebarsIdentifier> HandlebarsIdentifier =>
            (from name in Parse.CharExcept(IllegalCharacters).AtLeastOnce().Text()
             select new HandlebarsIdentifier(name)).Token().Positioned();
    }
}
