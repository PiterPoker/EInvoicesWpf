using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models
{
    public class EInvocesXML : INotifyPropertyChanged
    {
        private string name;
        private int unp;
        private int ttn;
        private string dateTransaction;
        private decimal totalCost;
        private decimal totalVat;
        private decimal totalCostVat;
        private bool error;
        private int supplierId;


        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Unp
        {
            get { return unp; }
            set
            {
                unp = value;
                OnPropertyChanged("Unp");
            }
        }
        public int Ttn
        {
            get { return ttn; }
            set
            {
                ttn = value;
                OnPropertyChanged("Ttn");
            }
        }

        /// <summary>
        /// можно использовать string 
        /// </summary>
        public string DateTransaction
        {
            get { return dateTransaction; }
            set
            {
                dateTransaction = value;
                OnPropertyChanged("DateTransaction");
            }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set
            {
                totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public decimal TotalVat
        {
            get { return totalVat; }
            set
            {
                totalVat = value;
                OnPropertyChanged("TotalVat");
            }
        }

        public decimal TotalCostVat
        {
            get { return totalCostVat; }
            set
            {
                totalCostVat = value;
                OnPropertyChanged("TotalCostVat");
            }
        }

        public bool Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }

        public int SupplierId
        {
            get { return supplierId; }
            set
            {
                supplierId = value;
                OnPropertyChanged("SupplierId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
