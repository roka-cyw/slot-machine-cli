namespace SlotMachine.Cli;

public static class CliOptionsParser
{
    public static CliOptions Parse(string[] args)
    {
        if (args.Length == 0)
            return new CliOptions();

        if (args[0] != "--stops")
            throw new ArgumentException("Use --stops key to reach specific slot screen!");

        return new CliOptions
        {
            StopPositions = args.Skip(1).Select(int.Parse).ToList()
        };
    }
}