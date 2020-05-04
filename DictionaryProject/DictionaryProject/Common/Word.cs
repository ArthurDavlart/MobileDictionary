namespace Common
{
    public class Word
    {
        public string EnWord { get; set; }
        public string RuWord { get; set; }
        public string Discription { get; set; }

        public Word()
        {

        }
        public Word(string enWord, string ruWord, string discription)
        {
            EnWord = enWord;
            RuWord = ruWord;
            Discription = discription;
        }

        public override string ToString()
        {
            return $"{EnWord} - {RuWord}";
        }
    }
}
