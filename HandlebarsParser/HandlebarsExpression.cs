using Sprache;

namespace HandlebarsParser
{
    public abstract class HandlebarsExpression : IPositionAware<HandlebarsExpression>
    {
        public Position Position { get; protected set; }
        public int Length { get; protected set; }

        public HandlebarsExpression SetPos(Position position, int length)
        {
            Position = position;
            Length = length;
            return this;
        }

        public static HandlebarsExpression Parse(string expression) =>
               HandlebarsGrammar.HandlebarsVariable
                   .Or<HandlebarsExpression>(HandlebarsGrammar.HandlebarsIdentifier)
                   .Parse(expression);
    }
}
