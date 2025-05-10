using apbd12_cw4.Models;

namespace apbd12_cw4;

public static class Database
{
    public static List<Test> Tests = new List<Test>()
    {
        new Test() { Id = 1, Name = "Test1" },
        new Test() { Id = 2, Name = "Test2" },
        new Test() { Id = 3, Name = "Test3" }
    };
}