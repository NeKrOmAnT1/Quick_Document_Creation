using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quick_Document_Creation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ICommand CreatDocCommand { get; set; }
        public ICommand PrintDocCommand { get; set; }
        public ComboBoxItem SelectDoc { get; set; }
        public ComboBoxItem Forma { get; set; }
        public string FIO { get; set; }
        public string Date { get; set; }
       
        public string Group { get; set; }
        public string Сourse { get; set; }
         public MainWindowViewModel()
         {
            CreatDocCommand = new DelegateCommand(() => Models.Methods.SelectDoc(SelectDoc, Сourse, FIO, Group, Forma, Date ));
         }
    }
}
