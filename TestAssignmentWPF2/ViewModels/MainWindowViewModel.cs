//using Mvvm.Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestAssignmentWPF2.Models;
using TestAssignmentWPF2.Models.Command;
using TestAssignmentWPF2.Views;

namespace TestAssignmentWPF2.ViewModels
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private SearchDictionary dictionary;
        private ObservableCollection<WordData> words;

        private Command getDictionaryData;
        private Command getNewWords;
        private Command clearData;

        public event PropertyChangedEventHandler PropertyChanged;
         
        public MainWindowViewModel()
        {
            words = new ObservableCollection<WordData>();

            dictionary = new SearchDictionary();
            getDictionaryData = new DelegateCommand(GetDictionaryData);
            getNewWords = new DelegateCommand(GetNewWords);
            clearData = new DelegateCommand(ClearData);
        }
         
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private void GetDictionaryData()
        {
            string fileData = GetDataFromFileDialog();
            fileData = fileData.Replace("\r", "");
            string[] newWords = fileData.Split('\n');

            foreach (var word in newWords) 
                dictionary.AddWord(word); 
        }
         
        private void GetNewWords()
        {
            string fileData = GetDataFromFileDialog();
            fileData = fileData.Replace("\r", ""); 
            string[] newWords = fileData.Split('\n');

            foreach (var word in newWords)
                words.Add(dictionary.GetParsedWord(word));
        }
         

        private string GetDataFromFileDialog()
        {

            string fileData = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                fileData = File.ReadAllText(openFileDialog.FileName);
            return fileData;
        }

        private void ClearData()
        {
            dictionary.Clear();
            words.Clear();
        }

        public IEnumerable<WordData> Words => words;

        public ICommand GetDictionaryDataCommand => getDictionaryData;

        public ICommand GetNewWordsCommand => getNewWords;

        public ICommand ClearDataCommand => clearData;
    }
}