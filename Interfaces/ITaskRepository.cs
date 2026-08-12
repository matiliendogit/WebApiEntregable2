using WebApiEntregable2.Data.Entities;

namespace WebApiEntregable2.Interfaces
{
    public interface ITaskRepository
    {
        IReadOnlyList<ETask> GetAll();

        ETask? GetById(int id);

        ETask Create(ETask task);

        bool Update(ETask task);
        
        bool Delete(ETask task);

    }
}
