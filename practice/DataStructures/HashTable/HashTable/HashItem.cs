﻿namespace Epam.NetMentoring.HashTable
{
    internal class HashItem
    {
       public HashItem(WordEntity key, WordDefinition value)
       {
            Key = key;
            Value = value;
       }

       public WordEntity Key { get; set; }
       public WordDefinition Value { get; set; }
    }
}
