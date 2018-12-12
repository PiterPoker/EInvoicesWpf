using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EInvoicesWpf.Models
{
    public class Supplier : INotifyPropertyChanged
    {
        private string name;
        private int unp;
        private List<KirmashDBF> kirmashDB { get; set; }
        private List<EInvocesXML> invoicesXML { get; set; }

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

        public List<KirmashDBF> KirmashDB
        {
            get { return kirmashDB; }
            set
            {
                kirmashDB = value;
                OnPropertyChanged("KirmashDB");
            }
        }

        public List<EInvocesXML> EInvaiceXML
        {
            get { return invoicesXML; }
            set
            {
                invoicesXML = value;
                OnPropertyChanged("EInvaiceXML");
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
