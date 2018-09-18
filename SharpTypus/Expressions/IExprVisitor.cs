// Class generated by GenerateExpressions.py script

namespace SharpTypus.Expressions {
interface IExprVisitor<T> {
T Visit(Binary expr);
T Visit(Unary expr);
T Visit(Literal expr);
T Visit(Grouping expr);
T Visit(Variable expr);
}
}