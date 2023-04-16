namespace Cpu;

public readonly struct Word
{
    private const byte ByteMask = 0x0F;
    private const byte FourthAddress = 0x0C;
    private const byte ThirdAddress = 0x08;
    private const byte SecondAddress = 0x04;
    private const byte MaxByteMask = 0xFF;

    public readonly byte FirstNibble;
    public readonly byte SecondNibble;
    public readonly ushort ThirdNibble;
    public readonly ushort FourthNibble;

    public readonly byte FirstByte;
    public readonly ushort SecondByte;

    public readonly ushort FirstThreeNibbles;

    public Word(ushort instruction)
    {
        FirstNibble = CalcFirstNibble(instruction);
        SecondNibble = CalcSecondNibble(instruction);
        ThirdNibble = CalcThirdNibble(instruction);
        FourthNibble = CalcFourthNibble(instruction);
        FirstByte = CalcFirstByte(instruction);
        SecondByte = CalcSecondByte(instruction);
        FirstThreeNibbles = CalcFirstThreeNibbles(instruction);
    }

    private static byte CalcFirstNibble(ushort instruction) => (byte) (instruction & ByteMask);

    private static byte CalcSecondNibble(ushort instruction) => (byte) (instruction >> SecondAddress & ByteMask);

    private static ushort CalcThirdNibble(ushort instruction) => (ushort) (instruction >> ThirdAddress & ByteMask);

    private static ushort CalcFourthNibble(ushort instruction) => (ushort) (instruction >> FourthAddress & ByteMask);

    private static byte CalcFirstByte(ushort instruction) => (byte) (instruction & MaxByteMask);

    private static ushort CalcSecondByte(ushort instruction) => (ushort) (instruction >> ThirdAddress);

    private static ushort CalcFirstThreeNibbles(ushort instruction)
    {
        var third = CalcThirdNibble(instruction) * Math.Pow(16, 2);
        var second = CalcSecondNibble(instruction) * 16;
        var first = CalcFirstNibble(instruction);
        return (ushort) (third + second + first);
    }

    // Given two instructions as bytes, combine them into one word (u16) and pass them back in a higher level format.
    public static ushort CombineInstructions(ushort instructionOne, ushort instructionTwo)
    {
        // Most significant.
        var firstByteWord = new Word(instructionOne);
        // Least significant.
        var secondByteWord = new Word(instructionTwo);

        var nibFour = firstByteWord.SecondNibble * Math.Pow(16, 3);
        var nibThree = firstByteWord.FirstNibble * Math.Pow(16, 2);
        var nibTwo = secondByteWord.SecondNibble * 16;
        var nibOne = secondByteWord.FirstNibble;

        return (ushort) (nibFour + nibThree + nibTwo + nibOne);
    }

    public override string ToString() =>
        $"Fourth Nib: {FourthNibble:x}, Third Nib: {ThirdNibble:x}, Second Nib: {SecondNibble:x}, First Nib: {FirstNibble:x}\nSecond Byte: {SecondByte:x}, First Byte: {FirstByte:x}, First Three Nibbles: {FirstThreeNibbles:x}";
}