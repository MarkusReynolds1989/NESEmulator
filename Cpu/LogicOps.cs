namespace Cpu;

public static class LogicOps
{
    /// <summary>
    /// AND - Bitwise and the accumulator with value and then store in accumulator.
    /// $29 Immediate, $25 Zero Page, $35 Zero Page X, $2D Absolute, $3D Absolute X, $39 Absolute Y, $21 Indirect X, $31 Indirect Y
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BitwiseAndWithAccumulator(ref VirtualMachine vm, Word instruction)
    {
        // $29 Immediate.
        vm.Accumulator &= instruction.SecondByte;
    }

    /// <summary>
    /// ASL - Shift left.
    /// $0A Accumulator, $06 Zero Page, $16 Zero Page X, $0E Absolute, $1E Absolute X
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void ArithmeticShiftLeft(ref VirtualMachine vm, Word instruction)
    {
        // TODO: Get the 7th bit to see what to set the carry to.
        vm.StatusRegisters[Registers.Carry] = true; // <- Actually get the bit, I will program this into the Word module.
        // $0A Accumulator.
        vm.Accumulator <<= 0x01;
    }

    /// <summary>
    /// BIT - Test Bits
    /// $24 Zero Page, $2C Absolute
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void BitTest(ref VirtualMachine vm, Word instruction)
    {
        // TODO: Come back to this, not immediately useful.
    }

    /// <summary>
    /// CMP - Compare accumulator.
    /// $C9 Immediate, $C5 Zero Page, $D5 Zero Page X, $CD Absolute, $DD Absolute X, $D9 Absolute Y, $C1 Indirect X, $D1 Indirect Y
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void Compare(ref VirtualMachine vm, Word instruction)
    {
        // Compare set flags as if subtraction has been carried out.
        // If the value in the accumulator is equal or greater than the compared value, the Carry will be set. Z and N will be set based on equality of lack
        // thereof and the sign of the accumulator.
    }

    /// <summary>
    /// CPX - Compare X Register
    /// $E0 Immediate, $E4 Zero Page, $EC Absolute
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void CompareX(ref VirtualMachine vm, Word instruction)
    {
        // Same as CMP but with X instead of accumulator.
    }

    /// <summary>
    /// CPY - Compare Y Register
    /// $C0 Immediate, $C4 Zero Page, $CC Absolute
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void CompareY(ref VirtualMachine vm, Word instruction)
    {
        // Same as CMP but with X instead of accumulator.
    }

    /// <summary>
    /// EOR - Bitwise exclusive Or
    /// $49 Immediate, $45 Zero Page, $55 Zero Page X, $4D Absolute, $5D Absolute X, $59 Absolute Y, $41 Indirect X, $52 Indirect Y
    /// </summary>
    /// <param name="vm"></param>
    /// <param name="instruction"></param>
    public static void ExclusiveOr(ref VirtualMachine vm, Word instruction) { }
}
