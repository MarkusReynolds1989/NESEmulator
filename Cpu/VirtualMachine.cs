namespace NES;

public class VirtualMachine
{
    public readonly byte[] Cart;
    public ushort[] Memory;

    // Registers
    public ushort Accumulator;
    public byte X;
    public byte Y;
    public readonly byte _stackPointer;
    public ushort ProgramCounter;
    public readonly BitArray _statusRegisters;

    public VirtualMachine(byte[] cart)
    {
        Cart = cart;
        Memory = new ushort[ushort.MaxValue];
        Accumulator = 0;
        X = 0;
        Y = 0;
        _stackPointer = 1;
        ProgramCounter = 0;
        _statusRegisters = new BitArray(8);
    }

    // Add two or one to the process counter and move on.
    public void Process()
    {
        var word = new Word(
            Word.CombineInstructions(Cart[ProgramCounter], Cart[ProgramCounter + 1])
        );

        Console.Write($"{word.SecondByte:x} {word.FirstByte:x} --");

        switch (word.FourthNibble)
        {
            case 0x00:
                OpCodeFunctions.NoOp();
                break;
            case 0x01:
                OpCodeFunctions.BranchOnPlus(_statusRegisters);
                break;
            case 0x04:
                switch (word.ThirdNibble)
                {
                    case 0x04:
                        break;
                    case 0x0e:
                        OpCodeFunctions.LogicalRightShiftAbsolute(_statusRegisters);
                        break;
                }

                break;

            case 0x08:
                switch (word.ThirdNibble)
                {
                    case 0x0d:
                        OpCodeFunctions.StoreAccumulatorAbsolute(Memory, word, Accumulator);
                        break;
                }

                break;

            case 0x0a:
                switch (word.ThirdNibble)
                {
                    case 0x09:
                        OpCodeFunctions.LoadAccumulatorImmediate(word, ref Accumulator);
                        break;

                    case 0x0d:
                        OpCodeFunctions.LoadAccumulatorAbsolute(Memory, word, ref Accumulator);
                        break;
                }

                break;
            case 0x0d:
                switch (word.ThirdNibble)
                {
                    case 0x08:
                        OpCodeFunctions.ClearDecimal(_statusRegisters);
                        break;
                }

                break;
        }

        ProgramCounter += 2;
    }
}
