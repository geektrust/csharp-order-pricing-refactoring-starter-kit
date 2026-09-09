/*
 * This is the driver code. Don't change it!!!
 */

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            throw new Exception("No command line arguments passed");
        }

        OrderProcessor.ProcessOrder(args[0]);
    }
}