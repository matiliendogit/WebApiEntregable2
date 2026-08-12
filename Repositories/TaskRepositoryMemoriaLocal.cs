using WebApiEntregable2.Interfaces;


namespace WebApiEntregable2.Repositories
{
    //public class TaskRepositoryMemoriaLocal : TaskRepository
    //{
    //    private readonly List<Models.Task> _tasks = new()
    //    {   
    //        new Models.Task { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
    //        new Models.Task { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true },
    //        new Models.Task { Id = 3, Title = "Task 3", Description = "Description 3", IsCompleted = false }
    //    };

    //    public IReadOnlyList<Models.Task> GetAll()
    //    {
    //        return _tasks; 
    //    }

    //    public Models.Task? GetById(int id)
    //    {
    //        return _tasks.FirstOrDefault(t => t.Id == id);
    //    }

    //    public Models.Task Create(Models.Task task)
    //    {
    //        task.Id = (_tasks.Count == 0) ? 1 : _tasks.Max(t => t.Id) + 1;
    //        _tasks.Add(task);
    //        return task;
    //    }

    //    public bool Update(Models.Task task)
    //    {
    //        var index = _tasks.FindIndex(t => t.Id == task.Id);

    //        if ( index == -1)
    //        {
    //            return false;
    //        }

    //        _tasks[index] = task;
    //        return true;
    //    }

    //    public bool Delete(int id)
    //    {
    //        var index = _tasks.FindIndex(t => t.Id == id);
    //        if (index == -1)
    //        {
    //            return false;
    //        }
    //        _tasks.RemoveAt(index);
    //        return true;
    //    }
    //}
}
