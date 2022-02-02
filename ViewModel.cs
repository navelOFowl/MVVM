using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    class ViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string rezultChanged
        {
            get
            {
                return Model.rezult.ToString();
            }
        }
        public List<string> operCombo
        {
            get
            {
                return Model.operList;
            }
        }
        public int operInd
        {
            set
            {
                Model.operId = value;
            }
        }
        public static string frstNum
        {
            set
            {
                Model.frst = Convert.ToInt32(value);
            }
        }
        public static string scndNum
        {
            set
            {
                Model.scnd = Convert.ToInt32(value);
            }
        }
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch(Model.operId)
            {
                case 0:
                    Model.rezult = Model.frst + Model.scnd;
                    break;
                case 1:
                    Model.rezult = Model.frst - Model.scnd;
                    break;
                case 2:
                    Model.rezult = Model.frst * Model.scnd;
                    break;
                case 3:
                    Model.rezult = Model.frst / Model.scnd;
                    break;
                default:
                    Model.rezult = 404;
                    break;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("rezultChanged"));
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
