// Class generated by GenerateExpressions.py script

namespace MoonSharp.Parsing.Expressions {
interface IExprVisitor {
void Visit(Binary expr);
void Visit(Unary expr);
void Visit(Literal expr);
void Visit(Grouping expr);
}
}