﻿using Cpu;

namespace CpuTests;

public class OpCodeTests
{
    [Fact]
    public static void RightShiftTest()
    {
        var vm = new VirtualMachine(TestCart.TestCartBytes);
        OpCodeFunctions.LogicalRightShiftAbsolute(vm);
        Assert.True(vm.StatusRegisters[Registers.Interrupt]);
        Assert.False(vm.StatusRegisters[Registers.Break]);
    }
}