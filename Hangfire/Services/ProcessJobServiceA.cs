namespace Hangfire.Services
{
    public class ProcessJobServiceA
    {
        public void Process()
        {
            Console.WriteLine($"running job at: {DateTime.UtcNow}");
        }
    }
}
