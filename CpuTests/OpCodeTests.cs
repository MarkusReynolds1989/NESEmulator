namespace CpuTests;

public class OpCodeTests
{
    [Fact]
    public static void RightShiftTest()
    {
        var vm = new VirtualMachine(TestCart.TestCartBytes);
        OpCodeFunctions.LogicalRightShiftAbsolute(vm);
        
    }
}