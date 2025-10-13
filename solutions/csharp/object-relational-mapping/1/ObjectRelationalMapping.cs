public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        try
        {
            database.BeginTransaction();
        }
        catch
        {
            database.Dispose();
            throw;
        }
    }

    public void Write(string data)
    {
        // Deve começar em TransactionStarted
        if (database.DbState != Database.State.TransactionStarted)
            database.Dispose();
            //throw new InvalidOperationException();

        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException)
        {
            // Se falhar, fecha e lança InvalidOperationException
            database.Dispose();
            //Console.WriteLine($"database has an internal state of {database.DbState}");
        }
    }

    public void Commit()
    {
        if (database.DbState != Database.State.DataWritten)
            database.Dispose();
            //throw new InvalidOperationException();
        
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}