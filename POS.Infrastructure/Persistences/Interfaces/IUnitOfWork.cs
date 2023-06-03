namespace POS.Infrastructure.Persistences.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Declaración o matricula de nuestras Interfaces a nivel de repository
    ICategoryRepository Category { get; }

    void SaveChanges();
    Task SaveChangesAsync();

}
