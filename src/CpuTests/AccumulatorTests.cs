using Cpu;

namespace CpuTests;

public class AccumulatorTests
{
    [Fact]
    public void LoadAccumulator()
    {
        var vm = new VirtualMachine(TestCart.TestCartBytes)
        {
            StatusRegisters =
            {
                [Registers.Negative] = true
            }
        };

        vm.Process();
        vm.Process();
        
        Assert.Equal(0x03, vm.Accumulator);
    }
}