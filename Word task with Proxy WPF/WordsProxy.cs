using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_task_with_Proxy_WPF
{
    public class WordsProxy
    {
        public List<string> WordProxy;
        public WordsProxy()
        {
            WordProxy = new List<string>();
        }

        public List<string> GetValues(string value)
        {
            List<string> values = new List<string>();
            foreach (var word in WordProxy)
            {
                if (word.ToLower().StartsWith(value))
                {
                    values.Add(word);
                }
            }
            return values;
        }

        public void AddWord(string word)
        {
            WordProxy.Add(word);
        }

        public void SetWords()
        {
            WordProxy.Add("apple");
            WordProxy.Add("anonymus");
            WordProxy.Add("antivirus");
            WordProxy.Add("brand");
            WordProxy.Add("black");
            WordProxy.Add("burberry");
            WordProxy.Add("calvin");
            WordProxy.Add("cook");
            WordProxy.Add("carrot");
        }
    }
}
