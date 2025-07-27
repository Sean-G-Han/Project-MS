using System.Threading.Tasks;

public interface EntityAccessor
{
    int GetSpeed();
    Entity GetEntity();
    void SetEntity(Entity entity);

}
public interface EntityAccessor<T> : EntityAccessor
{
    Task Attack(T target);
    Task Support(T target);
}