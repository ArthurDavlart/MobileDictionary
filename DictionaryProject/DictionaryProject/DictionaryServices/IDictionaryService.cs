using Common;
using JetBrains.Annotations;

namespace DictionaryServices
{
    public interface IDictionaryService<T> where T : DictionaryWord
    {

        bool TryAddWord(Word word, out T dictionaryWord);
        bool TryAddWord(T dictionaryWord);
        [CanBeNull]
        T GetDictionaryWord(string word);
        T[] GetDictionaryWords();        

    }
}
