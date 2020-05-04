using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IDictionaryRepository<T> where T : DictionaryWord
    {
        void Insert(T dictionaryWord);
        void Insert(T[] dictionaryWords);
        void Delete(string word);
        void Update(T dictionaryWord);
        T Select(string word);
        T[] Select();
        
    }
}
