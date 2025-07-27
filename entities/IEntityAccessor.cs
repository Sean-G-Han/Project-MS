public interface EntityAccessor
{
    int GetSpeed();
    Entity GetEntity();
    void SetEntity(Entity entity);

}
public interface EntityAccessor<T> : EntityAccessor
{
    void Attack(T target);
    void Support(T target);
}