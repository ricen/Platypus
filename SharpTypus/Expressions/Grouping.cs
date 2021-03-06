// Class generated by GenerateExpressions.py script

using SharpTypus.Parsing;
namespace SharpTypus.Expressions {
class Grouping : Expr {
public Expr Expr { get; }

public Grouping(Expr expr) {
Expr = expr;
}

public override T Accept<T>(IExprVisitor<T> visitor) => visitor.Visit(this);
public override bool Equals(object obj) {
if(!(obj is Grouping)) return false;
return ((Grouping)obj).Expr == this.Expr;
}
public override int GetHashCode() => (Expr).GetHashCode();
}
}
