using Cpu;

namespace CpuTests;

public class FlowOpsTests
{
    [Fact]
    public void DontBranchOnPlus()
    {
        var word = new Word(0x0123);
        var cart = new byte[] {0x12, 0x34};
        var vm = new VirtualMachine(cart)
        {
            StatusRegisters =
            {
                [Registers.Negative] = true
            }
        };
        FlowOps.BranchOnPlus(vm, word);
        Assert.Equal(0, vm.ProgramCounter);
    }
}