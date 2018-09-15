// Class generated by GenerateExpressions.py script

namespace SharpTypus.Parsing.Expressions {
class Binary : Expr {
public Expr LeftExpr { get; }
public Expr RightExpr { get; }
public Token Operator_ { get; }

public Binary(Expr leftExpr, Expr rightExpr, Token operator_) {
LeftExpr = leftExpr;
RightExpr = rightExpr;
Operator_ = operator_;
}

public override T Accept<T>(IExprVisitor<T> visitor) => visitor.Visit(this);
public static bool operator ==(Binary left, Binary right) =>
left.LeftExpr == right.LeftExpr && left.RightExpr == right.RightExpr && left.Operator_ == right.Operator_;
public static bool operator !=(Binary left, Binary right) =>
!(left == right);
public override bool Equals(object obj) => obj is Binary ? (Binary)obj == this : false;
public override int GetHashCode() => (LeftExpr, RightExpr, Operator_).GetHashCode();
}
}
