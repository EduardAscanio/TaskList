using SQLite;

namespace TaskList.Data
{
   public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
