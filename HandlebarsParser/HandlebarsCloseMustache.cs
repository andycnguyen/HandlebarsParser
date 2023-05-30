using Sprache;

namespace HandlebarsParser
{
    public class HandlebarsCloseMustache : HandlebarsExpression, IPositionAware<HandlebarsCloseMustache>
    {
        public new HandlebarsCloseMustache SetPos(Position position, int length)
        {
            return base.SetPos(position, length) as HandlebarsCloseMustache;
        }
    }

    public static partial class HandlebarsGrammar
    {
        public static Parser<HandlebarsCloseMustache> HandlebarsCloseMustache =>
            (from _ in Parse.String("}}").Token()
             select new HandlebarsCloseMustache()).Positioned();
    }
}
