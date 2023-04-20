using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Word_task_with_Proxy_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WordsProxy wordsProxy = new WordsProxy();

        List<string> Words = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            wordsProxy.SetWords();
            string text = File.ReadAllText(@"~/../../..\Notes.txt");
            var splitted = text.Split('\n');
            foreach (var item in splitted)
            {
                Words.Add(item.Trim());
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string text = Search.Text;
            SubmittedWords.Items.Add(text);
            wordsProxy.AddWord(text);
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            var text = tb.Text.ToLower();
            if (text == String.Empty)
            {
                SuggestedWords.Items.Clear();
            }

            List<string> suggestedwords = wordsProxy.GetValues(text);

            if (suggestedwords.Count > 0)
            {
                SuggestedWords.Items.Clear();
                foreach (var item in suggestedwords)
                {
                    SuggestedWords.Items.Add(item);
                }
            }
            else
            {
                SuggestedWords.Items.Clear();
                foreach (var item in Words)
                {
                    if (item.StartsWith(text))
                    {
                        SuggestedWords.Items.Add(item);
                    }
                }
            }
        }

        private void Words_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            Search.Text = listbox.SelectedItem.ToString();
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            Search.Text = string.Empty;
        }
    }
}
