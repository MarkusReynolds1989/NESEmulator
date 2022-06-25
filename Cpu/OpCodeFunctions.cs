using System.Diagnostics.CodeAnalysis;

namespace NES;

[SuppressMessage("ReSharper", "RedundantAssignment")]
public struct OpCodeFunctions
{
    // 0x00
    public static void NoOp()
    {
        Console.Write(" No Op.");
    }

    // 0x01
    public static void BranchOnPlus(BitArray statusRegisters)
    {
        Console.Write(" Branch On Plus");
        Console.Write(statusRegisters[0] ? " N register is negative." : " N register is positive.");
    }

    // 0x4e
    public static void LogicalRightShiftAbsolute(BitArray statusRegisters)
    {
        Console.Write(" LSR Logical Shift Right Absolute");
        statusRegisters.RightShift(1);
        statusRegisters[2] = true;
    }

    // 0x8d
    public static void StoreAccumulatorAbsolute(ushort[] memory, Word word, ushort accumulator)
    {
        Console.Write(" STA Store Accumulator Absolute");
        memory[word.SecondByte] = accumulator;
        Console.Write($"\n\t{memory[word.SecondByte]} stored at {word.SecondByte}");
    }

    // 0xa9
    public static void LoadAccumulatorImmediate(Word word, ref ushort accumulator)
    {
        Console.Write(" LDA Load Accumulator Immediate");
        accumulator = word.FirstByte;
    }

    // 0xad
    public static void LoadAccumulatorAbsolute(ushort[] memory, Word word, ref ushort accumulator)
    {
        Console.Write(" LDA Load Accumulator Absolute");
        accumulator = memory[word.SecondByte];
    }

    // 0xd8
    public static void ClearDecimal(BitArray statusRegisters)
    {
        Console.Write(" Clear decimal");
        statusRegisters[4] = false;
    }
}