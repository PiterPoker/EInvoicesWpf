using EInvoicesWpf.Models.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models.FileService
{
    public class FileService : IFileService
    {
        IDialogService dialogService;
        IFileService fileService;

        public void Save(string pathFile, int index)
        {
            try
            {
                if (dialogService.SavePathDialog(index) == true)
                {
                    fileService.Save(dialogService.FilePath, index);
                    dialogService.ShowMessage("Файл сохранен");
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
    }
}
