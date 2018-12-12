using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models.DialogService
{
    public interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; set; }   // путь к выбранному файлу
        bool SavePdfDialog();  // открытие файла
        bool SavePathDialog(int index);  // сохранение файла
    }
}
