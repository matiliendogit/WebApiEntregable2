using WebApiEntregable2.Data;
using WebApiEntregable2.Data.Entities;
using WebApiEntregable2.Interfaces;

namespace WebApiEntregable2.Repositories
{
    public class TaskRepository(TaskManagerDbContext context) : ITaskRepository
    {
        private readonly TaskManagerDbContext _context = context;


        public IReadOnlyList<ETask> GetAll()
        {
            return _context.ETasks.ToList();
        }

        public ETask? GetById(int id)
        {
            return _context.ETasks.FirstOrDefault(t => t.Id == id);
        }

        public ETask Create(ETask newTask)
        {
            newTask.Id = _context.ETasks.Count() == 0 ? 0 : _context.ETasks.Max(t => t.Id) + 1;
            _context.ETasks.Add(newTask);
            _context.SaveChanges();
            return newTask;
        }

        public bool Update(ETask task)
        {


            _context.ETasks.Update(task);
            
            return _context.SaveChanges() > 0;
        }

        public bool Delete(ETask task)
        {
            _context.ETasks.Remove(task);
            return _context.SaveChanges() > 0;
        }
    }
}

     