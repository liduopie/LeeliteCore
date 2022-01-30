using Leelite.AspNetCore.Host;

try
{
    do
    {
        HostManager.Start(args);

    } while (HostManager.Restarting);
}
catch (Exception e)
{
    Console.WriteLine($"Error:{e.Message}");
    throw;
}
