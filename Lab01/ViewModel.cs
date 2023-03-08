using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    sealed class ViewModel : INotifyPropertyChanged, INotifyDataInputInvalid
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event DataInputInvalidEventHandler? DataInputInvalid;
        private Model _model;
        
        public ViewModel(DataInputInvalidEventHandler? errorHandler)
        {
            _model = new Model();
            DataInputInvalid += errorHandler;
        }

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private void OnDataInputInvalid(string errorMsg)
        {
            if (DataInputInvalid != null)
            {
                DataInputInvalid(this, new DataInputInvalidEventArgs(errorMsg));
            }
        }

        public DateTime BirthDate
        {
            get { return _model.BirthDate; }
            set
            {
                if (_model.BirthDate != value)
                {
                    _model.BirthDate = value;
                    OnPropertyChange("BirthDate");
                    OnPropertyChange("Age");
                }
            }
        }

        public int Age
        {
            get
            {
                DateTime currDay = DateTime.Today;
                int age = currDay.Year - _model.BirthDate.Year;
                if (age < 0 || age > 135)
                {
                    OnDataInputInvalid("Invalid age!");
                }
                //if (_model.BirthDate > currDay.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
