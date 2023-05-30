using Sprache;

namespace HandlebarsParser
{
    public class HandlebarsOpenMustache : HandlebarsExpression, IPositionAware<HandlebarsOpenMustache>
    {
        public new HandlebarsOpenMustache SetPos(Position position, int length)
        {
            return base.SetPos(position, length) as HandlebarsOpenMustache;
        }
    }

    public static partial class HandlebarsGrammar
    {
        internal static Parser<HandlebarsOpenMustache> HandlebarsOpenMustache =>
            (from _ in Parse.String("{{").Token()
             select new HandlebarsOpenMustache()).Positioned();
    }
}
