namespace NetMentoring.Epam.ReflectionTask
{
    interface IConfigProvider
    {
        T GetSettings<T>() where T : new();
    }
}
