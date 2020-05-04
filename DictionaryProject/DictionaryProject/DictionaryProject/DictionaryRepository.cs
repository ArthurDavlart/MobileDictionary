using Common; 
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryProject
{
    public class DictionaryRepository : IDictionaryRepository<DBWord>
    { 
        private Dictionary<string, DBWord> _cacheDictionaryWord;
        private readonly SQLiteAsyncConnection _database;

        public DictionaryRepository(string dbPath)
        {
            _cacheDictionaryWord = new Dictionary<string, DBWord>();
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DBWord>().Wait();
            SetCache(GetWordsAsync().Result);
        }

        public void Delete(string word)
        {
            throw new NotImplementedException();
        }

        public void Insert(DBWord dictionaryWord)
        {
            _cacheDictionaryWord.Add(dictionaryWord.EnWord, dictionaryWord);
            SaveWordAsync(dictionaryWord);
        }

        public void Insert(DBWord[] dectionaryWords)
        {
            throw new NotImplementedException();
        }

        public DBWord[] Select()
        {
            var result = new DBWord[_cacheDictionaryWord.Count];
            var count = 0;
            foreach(var word in _cacheDictionaryWord)
            {
                result[count] = word.Value;
                count++;
            }  

            return result;
        }

        public DBWord Select(string word)
        {
            if (_cacheDictionaryWord.ContainsKey(word))
            {
                return _cacheDictionaryWord[word];
            }
            return null;
        }

        public void Update(DBWord dictionaryWord)
        {
            _cacheDictionaryWord[dictionaryWord.EnWord] = dictionaryWord;
            Update();

        }

        private async void Update()
        { 
        }

        private Task<DBWord[]> GetWordsAsync()
        {
            return _database.Table<DBWord>().ToArrayAsync();
        }

        private void SetCache(DBWord[] locationWords)
        {
            foreach (var locationWord in locationWords)
            {
                _cacheDictionaryWord.Add(locationWord.EnWord, locationWord);
            };
        }

        private Task<int> SaveWordAsync(DBWord locationWord)
        {
            if (locationWord.ID != 0)
            {
                return _database.UpdateAsync(locationWord);
            }
            else
            {
                return _database.InsertAsync(locationWord);
            }
        }
    }
}
