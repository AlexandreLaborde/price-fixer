using System;

public class Item
{
    public Item()
    {
        public readonly string Name { get; init; }
        public readonly string Brand { get; init; }
        public readonly string Description { get; init; }
        public readonly float Price { get; init; }
        public readonly uint ID { get; init; }
    }
}