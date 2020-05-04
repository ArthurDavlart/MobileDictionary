using System;
using System.Text;

namespace Common
{
    public class DictionaryWord : Word
    {

        public int AddCounter { get; set; } 
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DictionaryWord() : base()
        {
            AddCounter = 1;
        }

        public DictionaryWord(Word word) : base(word.EnWord, word.RuWord, word.Discription)
        {
            AddCounter = 1;
        }

        public DictionaryWord(string enWord, string ruWord): base(enWord, ruWord, "") { 
            AddCounter = 1;
        }

        public DictionaryWord(string enWord, string ruWord, string discription) : base(enWord, ruWord, discription)
        {
            AddCounter = 1;
        }

        public DictionaryWord(string enWord, string ruWord, string discription, double latitude, double longitude) : base(enWord, ruWord, discription)
        {
            Latitude = latitude;
            Longitude = longitude;
            AddCounter = 1;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString() + "\t\n");
            stringBuilder.Append(AddCounter);
            return stringBuilder.ToString();
        }
    }
}
