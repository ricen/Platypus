// Class generated by GenerateExpressions.py script

namespace SharpTypus.Parsing.Expressions {
class Grouping : Expr {
public Expr Expr { get; }

public Grouping(Expr expr) {
Expr = expr;
}

public override T Accept<T>(IExprVisitor<T> visitor) => visitor.Visit(this);
public static bool operator ==(Grouping left, Grouping right) =>
left.Expr == right.Expr;
public static bool operator !=(Grouping left, Grouping right) =>
!(left == right);
public override bool Equals(object obj) => obj is Grouping ? (Grouping)obj == this : false;
public override int GetHashCode() => (Expr).GetHashCode();
}
}
