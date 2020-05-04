using Common;
using SQLite;

namespace DictionaryProject
{
    public class DBWord : DictionaryWord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } 
        public DBWord() : base()
        {
        }
        public DBWord(DictionaryWord dictionaryWord) : 
            base(dictionaryWord.EnWord,
                dictionaryWord.RuWord,
                dictionaryWord.Discription,
                dictionaryWord.Latitude,
                dictionaryWord.Longitude)
        {
        }
    }
}
