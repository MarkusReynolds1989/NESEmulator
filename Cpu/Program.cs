namespace NES;

internal struct Program
{
    private static void Main(string[] args)
    {
        var vm = new VirtualMachine(File.ReadAllBytes(@"C:\Users\marku\Code\C#\nes\nestest.nes"));
        for (var i = 0; i < 100; i += 1)
        {
            vm.Process();
        }
    }
}
