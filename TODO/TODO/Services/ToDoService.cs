using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.Services
{
    public static class ToDoService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<WorkTask>();
        }

        public static async Task AddWorkTask(string title)
        {
            await Init();
            var workTask = new WorkTask
            {
                TaskTitle = title
            };
            var id = await db.InsertAsync(workTask);
        }

        public static async Task SaveDetails(WorkTask workTask)
        {
            await Init();

            if (workTask.ID != 0)
            {
                var existingTask = await db.FindAsync<WorkTask>(workTask.ID);

                if (existingTask != null)
                {
                    existingTask.TaskTitle = workTask.TaskTitle;
                    existingTask.Description = workTask.Description;

                    await db.UpdateAsync(existingTask);
                }
            }
        }

        public static async Task RemoveWorkTask(int id)
        {
            await Init();

            await db.DeleteAsync<WorkTask>(id);
        }

        public static async Task<IEnumerable<WorkTask>> GetTask()
        {
            await Init();

            var workTask = await db.Table<WorkTask>().ToListAsync();
            return workTask;
        }
    }
}
