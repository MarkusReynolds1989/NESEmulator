namespace NES;

public static class MathOps
{
    /// <summary>
    /// Add with carry.
    /// $69 Immediate, $65 Zero Page, $75 Zero Page X, $6D Absolute, $7D Absolute X, $79 Absolute Y, $61 Absolute X, $71 Absolute Y
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void AddWithCarry(ref VirtualMachine vm, Word instruction)
    {
        // $69 Immediate.
        vm.Accumulator += instruction.SecondByte;
    }

    /// <summary>
    /// DEC - Decrement Memory
    /// $C6 Zero Page, $D6 Zero Page X, $CE Absolute, $DE Absolute X
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void DecrementMemory(ref VirtualMachine vm, Word instruction) { }
}
