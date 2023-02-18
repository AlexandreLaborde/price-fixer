using System;
using System.Diagnostics;
using System.Xml.Linq;

public class Product
{
    public uint ID { get; init; }
    public string Name { get; init; }
    public string Brand { get; init; }
    //public string Description { get; init; }
    public float Price { get; init; }

    public string Unit { get; init; }

    public string PriceUnit { get; init; }

    public override string ToString()
    {
        return $"{ID}\t{Name}\t{Brand}\t{Price}\t{Unit}\t{PriceUnit}";
    }
}