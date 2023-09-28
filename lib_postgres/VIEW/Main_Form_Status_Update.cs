using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VIEW
{
    public class Main_Form_Status_Update : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string message;
        private bool toolStripMenuItem__Book_Edit = false;

        public Main_Form_Status_Update()
        {


        }

        public bool ToolStripMenuItem__Book_Edit
        {
            get { return toolStripMenuItem__Book_Edit; }
            set
            {
                toolStripMenuItem__Book_Edit = value;
                OnPropertyChanged("ToolStripMenuItem__Book_Edit");
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }





        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
