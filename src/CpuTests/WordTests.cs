using Cpu;

namespace CpuTests;

public class WordTests
{
    private static readonly Word TestWord = new(0x1234);

    [Fact]
    public void NibbleOne()
    {
        Assert.Equal(0x04, TestWord.FirstNibble);
    }

    [Fact]
    public void NibbleTwo()
    {
        Assert.Equal(0x03, TestWord.SecondNibble);
    }

    [Fact]
    public void NibbleThree()
    {
        Assert.Equal(0x02, TestWord.ThirdNibble);
    }

    [Fact]
    public void NibbleFour()
    {
        Assert.Equal(0x01, TestWord.FourthNibble);
    }

    [Fact]
    public void FirstByte()
    {
        Assert.Equal(0x34, TestWord.FirstByte);
    }

    [Fact]
    public void SecondByte()
    {
        Assert.Equal(0x12, TestWord.SecondByte);
    }

    [Fact]
    public void FirstThreeNibbles()
    {
        Assert.Equal(0x0234, TestWord.FirstThreeNibbles);
    }

    [Fact]
    public void CombineInstructionTest()
    {
        Assert.Equal(0x1234, Word.CombineInstructions(0x0012, 0x0034));
    }
}