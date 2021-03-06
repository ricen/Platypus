// Class generated by GenerateExpressions.py script

using SharpTypus.Parsing;
namespace SharpTypus.Expressions {
class Unary : Expr {
public Expr Expr { get; }
public Token Operator_ { get; }

public Unary(Expr expr, Token operator_) {
Expr = expr;
Operator_ = operator_;
}

public override T Accept<T>(IExprVisitor<T> visitor) => visitor.Visit(this);
public override bool Equals(object obj) {
if(!(obj is Unary)) return false;
return ((Unary)obj).Expr == this.Expr && ((Unary)obj).Operator_ == this.Operator_;
}
public override int GetHashCode() => (Expr, Operator_).GetHashCode();
}
}
