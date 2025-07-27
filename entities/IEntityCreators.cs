public interface IEntityCreators
{
    public static int Id { get; protected set; }
    public abstract static EntityNode Create();
}