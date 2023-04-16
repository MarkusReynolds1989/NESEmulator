namespace Cpu;

internal static class Program
{
    private static void Main(string[] args)
    {
        // TODO: I don't like this setup and mutation, I want to have a stack and a new VM for every operation.
        // TODO: Then I can push the new vm to the stack and pop off for going back and forth.
        var vm = new VirtualMachine(File.ReadAllBytes(@"C:\Users\marku\home\code\c#\NesEmulator\CpuTests\nestest.nes"));
        for (var i = 0; i < 100; i += 1)
        {
            vm.Process();
        }
    }
}