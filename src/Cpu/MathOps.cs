namespace Cpu;

public static class MathOps
{
    /// <summary>
    /// Add with carry.
    /// $69 Immediate, $65 Zero Page, $75 Zero Page X, $6D Absolute, $7D Absolute X, $79 Absolute Y, $61 Absolute X, $71 Absolute Y
    /// </summary>
    /// <param name="word"></param>
    /// <param name="vm"></param>
    public static void AddWithCarryImmediate(Word word, VirtualMachine vm)
    {
        var operand = word.FirstByte;

        // Get carry.
        var carryIn = vm.StatusRegisters[Registers.Carry] ? 1 : 0;
        // Perform addition in 16 bit (32 bit) to catch overflow.
        var result = vm.Accumulator + operand + carryIn;

        // Calc accumulator for lower 8 bits.
        var newAccumulator = (byte)(result & 0xFF);

        // Update Flags.
        // If result > 255 we add carry.
        vm.StatusRegisters[Registers.Carry] = (result > 0xFF);

        // Set zero flag if the result is zero.
        vm.StatusRegisters[Registers.Zero] = (newAccumulator == 0);

        // Negative flag if bit 7 of the result is 1 (negative).
        vm.StatusRegisters[Registers.Negative] = ((newAccumulator & 0x80) != 0);

        // Overflow is confusing, I will get more info. Something about the sign is incorrect.
        vm.StatusRegisters[Registers.Overflow] =
            (((~(vm.Accumulator ^ operand)) & (vm.Accumulator ^ result)) & 0x80) != 0;

        // $69 Immediate.
        vm.Accumulator += newAccumulator;
    }

    /// <summary>
    /// DEC - Decrement Memory
    /// $C6 Zero Page, $D6 Zero Page X, $CE Absolute, $DE Absolute X
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void DecrementMemory(VirtualMachine vm, Word instruction)
    {
    }
}