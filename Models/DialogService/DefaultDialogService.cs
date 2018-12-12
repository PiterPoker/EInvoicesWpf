using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EInvoicesWpf.Models.DialogService
{
    class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool SavePdfDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All files (*.*)|*.*|PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.FileName = "Repor" + DateTime.Now.ToString("dd.MM.yyyy");
            saveFileDialog.Title = "Сохранить как...";
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SavePathDialog(int index)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы DBF (*.dbf) | *.dbf| Все файлы (*.*) | *.*";
            openFileDialog.DefaultExt = ".dbf";
            openFileDialog.Title = "Выбор файла с БД";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                switch (index)
                {
                    case 1:
                        Properties.Settings.Default.path_3torg = FilePath;
                        break;
                    case 2:
                        Properties.Settings.Default.path_60chet = FilePath;
                        break;
                    default:
                        Properties.Settings.Default.path_esf = FilePath;
                        break;
                }
                Properties.Settings.Default.Save();  // Сохраняем переменные.
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
