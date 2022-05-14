namespace Day39CaseStudy.Services.DbService.Interfaces;

public interface ICrudService<T>
{
    void Add(T entity);
    IEnumerable<T> GetAll();
    void Update(T entity);
    T GetByName(string entityName);
    void Delete(int entityId);
}
