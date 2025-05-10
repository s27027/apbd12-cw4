namespace apbd12_cw4.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // np. pies, kot
    public double Weight { get; set; }
    public string FurColor { get; set; } = string.Empty;
    public List<Visit> Visits { get; set; } = new();
}