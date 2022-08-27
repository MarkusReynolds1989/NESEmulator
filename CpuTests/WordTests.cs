using NES;

namespace CpuTests;

public class WordTests
{
    private readonly Word _testWord = new(0x1234);

    [Fact]
    public void NibbleOne()
    {
        Assert.Equal(0x04, _testWord.FirstNibble);
    }

    [Fact]
    public void NibbleTwo()
    {
        Assert.Equal(0x03, _testWord.SecondNibble);
    }

    [Fact]
    public void NibbleThree()
    {
        Assert.Equal(0x02, _testWord.ThirdNibble);
    }

    [Fact]
    public void NibbleFour()
    {
        Assert.Equal(0x01, _testWord.FourthNibble);
    }

    [Fact]
    public void FirstByte()
    {
        Assert.Equal(0x34, _testWord.FirstByte);
    }

    [Fact]
    public void SecondByte()
    {
        Assert.Equal(0x12, _testWord.SecondByte);
    }

    [Fact]
    public void FirstThreeNibbles()
    {
        Assert.Equal(0x0234, _testWord.FirstThreeNibbles);
    }

    [Fact]
    public void CombineInstructionTest()
    {
        Assert.Equal(0x1234, Word.CombineInstructions(0x0012, 0x0034));
    }
}
