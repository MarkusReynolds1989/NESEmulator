namespace CpuTests;

using System.IO;

public static class TestCart
{
    public static readonly byte[] TestCartBytes =
        File.ReadAllBytes(@"C:\Users\marku\home\code\c#\NesEmulator\CpuTests\nestest.nes");
}