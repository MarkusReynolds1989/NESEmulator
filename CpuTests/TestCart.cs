namespace CpuTests;

using System.IO;

public static class TestCart
{
    public static readonly byte[] TestCartBytes =
        File.ReadAllBytes(@"C:\Users\marku\Code\C#\NesEmulator\CpuTests\nestest.nes");
}