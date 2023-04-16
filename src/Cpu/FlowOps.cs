namespace Cpu;

public static class FlowOps
{
    /// <summary>
    /// BPL - Branch On Plus
    /// $10
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnPlus(VirtualMachine vm, Word instruction)
    {
        if (!vm.StatusRegisters[Registers.Negative])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BMI - Branch On Minus
    /// $30
    /// </summary>
    /// <param name="vm">The virtual machine.</param>
    /// <param name="instruction">The instruction as a word.</param>
    public static void BranchOnMinus(VirtualMachine vm, Word instruction)
    {
        if (vm.StatusRegisters[Registers.Negative])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BVC - Branch On Overflow Clear
    /// $50
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnOverflowClear(VirtualMachine vm, Word instruction)
    {
        if (!vm.StatusRegisters[Registers.Overflow])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BVS - Branch On Overflow Set
    /// $70
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnOverflowSet(VirtualMachine vm, Word instruction)
    {
        if (vm.StatusRegisters[Registers.Overflow])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BCC - Branch On Carry Clear
    /// $90
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnCarryClear(VirtualMachine vm, Word instruction)
    {
        if (!vm.StatusRegisters[Registers.Carry])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BCS - Branch On Carry Set
    /// $B0
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnCarrySet(VirtualMachine vm, Word instruction)
    {
        if (vm.StatusRegisters[Registers.Carry])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BNE - Branch On Not Equal
    /// $D0
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnNotEqual(VirtualMachine vm, Word instruction)
    {
        if (vm.Accumulator != instruction.FirstThreeNibbles)
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BEQ - Branch On Equal
    /// $F0
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnEqual(VirtualMachine vm, Word instruction)
    {
        if (vm.Accumulator == instruction.FirstThreeNibbles)
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BRK - Break
    /// $00
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void Break(VirtualMachine vm, Word instruction)
    {
        vm.StatusRegisters[Registers.Break] = true;
        vm.ProgramCounter += 1;
    }
}