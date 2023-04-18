namespace W3C.XSD;

public partial class unique
{
    protected bool Equals(unique other) => Equals(Content, other.Content);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((unique) obj);
    }

    public override int GetHashCode() => (Content != null ? Content.GetHashCode() : 0);
}