namespace NES;

public class VirtualMachine
{
    public readonly byte[]   Cart;
    public          ushort[] Memory;

    // Registers
    private ushort   _accumulator;
    private byte     _x;
    private byte     _y;
    private byte     _stackPointer;
    private ushort   _programCounter;
    private BitArray _statusRegisters;

    public VirtualMachine(byte[] cart)
    {
        Cart = cart;
        Memory = new ushort[ushort.MaxValue];
        _accumulator = 0;
        _x = 0;
        _y = 0;
        _stackPointer = 1;
        _programCounter = 0;
        _statusRegisters = new BitArray(8);
    }

    private static void WriteProgramInformation(ushort accumulator, ushort programCounter, byte stackPointer)
    {
        Console.WriteLine($"\n\tAcc: {accumulator} Program: {programCounter} Stack: {stackPointer}");
    }

    private static void WriteRegisterInformation(IReadOnlyList<ushort> statusRegisters)
    {
        Console.WriteLine(
            $"\tCarry: {statusRegisters[Registers.Carry]} Zero: {statusRegisters[Registers.Zero]} Interrupt: {statusRegisters[Registers.Interrupt]} " +
            $"Decimal: {statusRegisters[Registers.Decimal]} Break: {statusRegisters[Registers.Break]}\n\tOverflow: {statusRegisters[Registers.Overflow]} " +
            $"Negative: {statusRegisters[Registers.Negative]}");
    }

    // Add two or one to the process counter and move on.
    public void Process()
    {
        var word = new Word(Word.CombineInstructions(Cart[_programCounter], Cart[_programCounter + 1]));

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
                        OpCodeFunctions.StoreAccumulatorAbsolute(Memory, word, _accumulator);
                        break;
                }

                break;

            case 0x0a:
                switch (word.ThirdNibble)
                {
                    case 0x09:
                        OpCodeFunctions.LoadAccumulatorImmediate(word, ref _accumulator);
                        break;

                    case 0x0d:
                        OpCodeFunctions.LoadAccumulatorAbsolute(Memory, word, ref _accumulator);
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

        _programCounter += 2;
        WriteProgramInformation(_accumulator, _programCounter, _stackPointer);
        WriteRegisterInformation(Memory);
    }
}