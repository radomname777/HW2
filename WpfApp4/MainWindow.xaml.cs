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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Tag)
                {
                    case "Open":
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Text Files|*.txt";
                        if (openFileDialog.ShowDialog() == true)
                        {
                            TextRich.Document.Blocks.Add(new Paragraph(new Run(File.ReadAllText(openFileDialog.FileName))));
                        }
                        break;
                    case "Save":
                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.Filter ="Text Files|*.txt";
                        if (saveFile.ShowDialog() == true)
                        {
                            using StreamWriter sw = new StreamWriter(saveFile.FileName);
                            sw.Write(TextRich.Document.Blocks);
                        }
                        break;
                    default:
                        break;
                }
            }
           
        }
    }
}
