using System;
using System.Diagnostics;
using System.Xml.Linq;

public class Item
{
    public string Name { get; init; }
    public string Brand { get; init; }
    public string Description { get; init; }
    public float Price { get; init; }
    public uint ID { get; init; }

    public override string ToString()
    {
        return $"{ID}\t{Name}\t{Brand}\t{Description}\t{Price}";
    }
}