namespace CpuTests;

using System.IO;

public static class TestCart
{
    public static readonly byte[] TestCartBytes =
        File.ReadAllBytes("test.nes");
}