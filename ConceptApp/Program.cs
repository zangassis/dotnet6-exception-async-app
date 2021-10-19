await ValidateException();

static async Task ValidateException() =>
    await PersonalException();

static async Task PersonalException()
{
    Task task = Task.Run(() => throw new ArgumentException("Exception Task 1"));
    Task secondTask = Task.Run(() => throw new NullReferenceException("Exception Task 2"));

    try
    {
      Task.WaitAll(task, secondTask);
    }
    catch (AggregateException ex)
    {
        ex.InnerExceptions.ToList().ForEach(x => Console.WriteLine(x.Message));
    }
}