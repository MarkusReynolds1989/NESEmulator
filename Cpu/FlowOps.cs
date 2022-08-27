namespace NES;

public static class FlowOps
{
    // TODO: Check all branch operations, in the instructions it says to go to a two byte address but we don't read the instructions like that.
    /// <summary>
    /// BPL - Branch On Plus
    /// $10
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnPlus(ref VirtualMachine vm, Word instruction)
    {
        if (!vm._statusRegisters[Registers.Negative])
        {
            vm.ProgramCounter = instruction.FirstThreeNibbles;
        }
    }

    /// <summary>
    /// BMI - Branch On Minus
    /// $30
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BranchOnMinus(ref VirtualMachine vm, Word instruction)
    {
        if (vm._statusRegisters[Registers.Negative])
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
    public static void BranchOnOverflowClear(ref VirtualMachine vm, Word instruction)
    {
        if (!vm._statusRegisters[Registers.Overflow])
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
    public static void BranchOnOverflowSet(ref VirtualMachine vm, Word instruction)
    {
        if (vm._statusRegisters[Registers.Overflow])
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
    public static void BranchOnCarryClear(ref VirtualMachine vm, Word instruction)
    {
        if (!vm._statusRegisters[Registers.Carry])
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
    public static void BranchOnCarrySet(ref VirtualMachine vm, Word instruction)
    {
        if (vm._statusRegisters[Registers.Carry])
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
    public static void BranchOnNotEqual(ref VirtualMachine vm, Word instruction)
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
    public static void BranchOnEqual(ref VirtualMachine vm, Word instruction)
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
    public static void Break(ref VirtualMachine vm, Word instruction)
    {
        vm._statusRegisters[Registers.Break] = true;
        vm.ProgramCounter += 1;
    }
}
