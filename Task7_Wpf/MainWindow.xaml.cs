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
using System.Windows.Xps.Packaging;

namespace Task7._1_Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // создаем привязку команды
            CommandBinding commandBtnBold = new CommandBinding();
            CommandBinding commandBtnItalic = new CommandBinding();
            CommandBinding commandBtnUnderline = new CommandBinding();
            // устанавливаем команду
            commandBtnBold.Command = EditingCommands.ToggleBold;
            commandBtnItalic.Command = EditingCommands.ToggleItalic;
            commandBtnUnderline.Command = EditingCommands.ToggleUnderline;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBtnBold.Executed += CommandBinding_Executed1;
            commandBtnItalic.Executed += CommandBinding_Executed2;
            commandBtnUnderline.Executed += CommandBinding_Executed3;
            // добавляем привязку к коллекции привязок элемента Button
            BtnBold.CommandBindings.Add(commandBtnBold);
            BtnItalic.CommandBindings.Add(commandBtnItalic);
            BtnUnderline.CommandBindings.Add(commandBtnUnderline);
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*" };

            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*" };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                MessageBox.Show("Файл сохранён.");
            }
        }

        private void SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file (*.pdf)|*.pdf|Все файлы (*.*)|*.*" };

            //if (saveFileDialog.ShowDialog() == true)
            //{
            //    File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            //}
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(textBox, "Безымянный");
            }
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    printDialog.PrintDocument(
            //           ((IDocumentPaginatorSource)textBox.Document).DocumentPaginator,
            //           "A Flow Document");
            //}
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            string messageBoxText = "Вы хотите сохранить изменения?";
            string caption = "Текстовый редактор";

            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*" };

                        if (saveFileDialog.ShowDialog() == true)
                        {
                            File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                        }
                        break;
                    }
                case MessageBoxResult.No:
                    {
                        Application.Current.Shutdown();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
           
        }

        private void CommandBinding_Executed1(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void CommandBinding_Executed2(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void CommandBinding_Executed3(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox.TextDecorations == TextDecorations.Underline)
            {
                textBox.TextDecorations = null;
            }
            else
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;

            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;

            if (int.TryParse(fontSize, out int newValue))
            {
                if (textBox != null)
                {
                    textBox.FontSize = newValue;
                }
            }
        }

        private void Rb1_Checked(object sender, RoutedEventArgs e)
        {
            if (Rb1.IsChecked == true)
            {
                if (textBox != null)
                {
                    textBox.Foreground = Brushes.Black;
                }
            }
            else if (Rb2.IsChecked == true)
            {
                if (textBox != null)
                {
                    textBox.Foreground = Brushes.Red;
                }
            }
        }
    }
}
