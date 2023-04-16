namespace Cpu;

public class VirtualMachine
{
    public readonly byte[] Cart;
    private readonly ushort[] _memory;

    // Registers
    public ushort Accumulator;
    private byte _x;
    private byte _y;
    private readonly byte _stackPointer;
    public ushort ProgramCounter;
    public readonly BitArray StatusRegisters;

    public VirtualMachine(byte[] cart)
    {
        Cart = cart;
        _memory = new ushort[ushort.MaxValue];
        Accumulator = 0;
        _x = 0;
        _y = 0;
        _stackPointer = 1;
        ProgramCounter = 0;
        StatusRegisters = new BitArray(8);
    }

    // Add two or one to the process counter and move on.
    public void Process()
    {
        var word = new Word(
            Word.CombineInstructions(Cart[ProgramCounter], Cart[ProgramCounter + 1])
        );

        switch (word.FourthNibble)
        {
            case 0x00:
                OpCodeFunctions.NoOp();
                break;
            case 0x01:
                OpCodeFunctions.BranchOnPlus(StatusRegisters);
                break;
            case 0x04:
                switch (word.ThirdNibble)
                {
                    case 0x04:
                        break;
                    case 0x0e:
                        OpCodeFunctions.LogicalRightShiftAbsolute(this);
                        break;
                }

                break;

            case 0x08:
                switch (word.ThirdNibble)
                {
                    case 0x0d:
                        OpCodeFunctions.StoreAccumulatorAbsolute(_memory, word, this);
                        break;
                }

                break;

            case 0x0a:
                switch (word.ThirdNibble)
                {
                    case 0x09:
                        OpCodeFunctions.LoadAccumulatorImmediate(word, this);
                        break;

                    case 0x0d:
                        OpCodeFunctions.LoadAccumulatorAbsolute(_memory, word, this);
                        break;
                }

                break;
            case 0x0d:
                switch (word.ThirdNibble)
                {
                    case 0x08:
                        OpCodeFunctions.ClearDecimal(StatusRegisters);
                        break;
                }

                break;
        }

        ProgramCounter += 2;
    }
}