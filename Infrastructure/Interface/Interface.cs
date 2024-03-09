namespace Infrastructure.Interface;

    public interface Interface<T>
{
    public List<T> GetValues();
    public void AddValues(T value);
    public void UpdateValues(T value);
    public void DeleteValues(int id);
}

