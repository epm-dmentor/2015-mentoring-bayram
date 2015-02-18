using System;

namespace Epam.NetMentoring.HashTable
{
    public class WordEntity : IEquatable<WordEntity>
    {
        public enum WordType{ Adjective, Noun, Verb};
        public string Word { get; set; }
        public WordType Type { get; set; }

        public override int GetHashCode()
        {
            return Word.GetHashCode() ^ Type.GetHashCode();
        }

        //IT: кстати говоря этот метод есть в интерфейсе IEquatable<WordEntity>
        public bool Equals(WordEntity entity)
        {
            if (entity == null) return false;

            return (Word == entity.Word) && (Type == entity.Type);
        }

        public override bool Equals(object obj)
        {
            //IT: отлично что добавил типизированный Equals
            if (obj == null) return false;
            
            var wordEntity = obj as WordEntity;
            if (wordEntity == null) return false;
            
            return (Word == wordEntity.Word) && (Type == wordEntity.Type);
        }
    }
}
