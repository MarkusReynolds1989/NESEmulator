namespace Cpu;

public static class OpCodeFunctions
{
    /// 0x00
    public static void NoOp()
    {
    }

    /// 0x01
    public static void BranchOnPlus(BitArray statusRegisters)
    {
    }

    // 0x4e
    public static void LogicalRightShiftAbsolute(VirtualMachine vm)
    {
        vm.StatusRegisters.RightShift(1);
        vm.StatusRegisters[2] = true;
    }

    // 0x8d
    public static void StoreAccumulatorAbsolute(ushort[] memory, Word word, VirtualMachine vm)
    {
        memory[word.SecondByte] = vm.Accumulator;
    }

    // 0xa9
    public static void LoadAccumulatorImmediate(Word word, VirtualMachine vm)
    {
        vm.Accumulator = word.FirstByte;
    }

    // 0xad
    public static void LoadAccumulatorAbsolute(ushort[] memory, Word word, VirtualMachine vm)
    {
        vm.Accumulator = memory[word.SecondByte];
    }

    // 0xd8
    public static void ClearDecimal(BitArray statusRegisters)
    {
        statusRegisters[4] = false;
    }
}