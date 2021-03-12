using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.ViewModels
{
    class MainWindowViewModel:BaseViewModel
    {
        private string _address;
        private int _dotsCount;
        private string _filename;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }

        public int DotsCount
        {
            get
            {
                return _dotsCount;
            }
            set
            {
                _dotsCount = value;
                OnPropertyChanged(nameof(DotsCount));
            }
        }
    }
}
