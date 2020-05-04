using Common;
using System;
using System.Linq;

namespace DictionaryServices
{
    public class DictionaryService<T> : IDictionaryService<T> where T : DictionaryWord, new()
    {
        private readonly IDictionaryRepository<T> _dictionaryRepository;
        public DictionaryService(IDictionaryRepository<T> dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }

        public T GetDictionaryWord(string word)
        {
            throw new NotImplementedException();
        }

        public T[] GetDictionaryWords()
        {
            return _dictionaryRepository.Select();
        }

        public bool TryAddWord(Word word, out T dictionaryWord)
        {
            dictionaryWord = _dictionaryRepository.Select(word.EnWord);

            if (dictionaryWord == null)
            {                
                dictionaryWord = new T();
                dictionaryWord.RuWord = word.RuWord;
                dictionaryWord.EnWord = word.EnWord;

                _dictionaryRepository.Insert(dictionaryWord);
                return true;
            }

            if (!ContainsWord(dictionaryWord.RuWord, word.RuWord))
            {
                dictionaryWord.RuWord = $"{dictionaryWord.RuWord}, {word.RuWord}";
            }

            dictionaryWord.AddCounter++;
            _dictionaryRepository.Update(dictionaryWord);

            return false;
        }

        public bool TryAddWord(T dictionaryWord)
        {
            T oldDictionaryWord = _dictionaryRepository.Select(dictionaryWord.EnWord);

            if (oldDictionaryWord == null)
            {
                _dictionaryRepository.Insert(dictionaryWord);
                return true;
            }

            if (!ContainsWord(dictionaryWord.RuWord, oldDictionaryWord.RuWord))
            {
                oldDictionaryWord.RuWord = $"{dictionaryWord.RuWord}, {oldDictionaryWord.RuWord}";
            }

            oldDictionaryWord.AddCounter++;
            _dictionaryRepository.Update(oldDictionaryWord);

            return false;
        }

        private bool ContainsWord(string ruWordsLine, string word)
        {
            ruWordsLine = ruWordsLine.Replace(" ", "");
            string[] ruWords = ruWordsLine.Split(',');
            
            return ruWords.Contains(word);
        }
    }
}
