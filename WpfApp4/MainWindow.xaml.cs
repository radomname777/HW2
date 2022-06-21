using Microsoft.Win32;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextRich.Document.Blocks.Clear();
        }
        private void SaveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files|*.txt";
            if (saveFile.ShowDialog() == true)
            {
                using StreamWriter sw = new StreamWriter(saveFile.FileName);
                string richText = new TextRange(TextRich.Document.ContentStart, TextRich.Document.ContentEnd).Text;
                sw.Write(richText);
            }
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == true)
                TextRich.Document.Blocks.Add(new Paragraph(new Run(File.ReadAllText(openFileDialog.FileName))));
        }
        private void CopyText()
        {
            TextRich.Copy();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Tag)
                {
                    case "Open":OpenFile();break;
                    case "Save": SaveFile();break;
                    case "Cut": TextRich.Cut(); break;
                    case "Copy": TextRich.Copy(); break;
                    case "Paste": TextRich.Paste(); break;
                    case "Select": TextRich.SelectAll(); break;
                    default:
                        break;
                }
            }
           
        }
    }
}
