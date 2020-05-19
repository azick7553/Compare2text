using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Compare2text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CompareBtn_Click(object sender, RoutedEventArgs e)
        {
            var textR1 = new TextRange(text1.Document.ContentStart, text1.Document.ContentEnd).Text;
            var textR2 = new TextRange(text2.Document.ContentStart, text2.Document.ContentEnd).Text;

            if (caseSens.IsChecked.Value)
            {
                textR1 = textR1.ToLower();
                textR2 = textR2.ToLower();
            }
            if (trimSens.IsChecked.Value)
            {
                textR1 = textR1.Trim();
                textR2 = textR2.Trim();
            }

            var result = Levenshtein.LevenshteinMatch(textR1, textR2);
            resultTxb.Content = Math.Round(result * 100, 2) + "%";
        }
    }
}
