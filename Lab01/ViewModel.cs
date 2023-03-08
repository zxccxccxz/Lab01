using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    sealed class ViewModel : INotifyPropertyChanged, INotifyMsgBoxCreator
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event MsgBoxCreatorEventHandler? MsgBoxCreator;
        private Model _model;
        
        public ViewModel(MsgBoxCreatorEventHandler? msgBoxCreatorHandler)
        {
            _model = new Model();
            MsgBoxCreator += msgBoxCreatorHandler;
        }

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private void OnMsgBoxCreator(string errorMsg)
        {
            if (MsgBoxCreator != null)
            {
                MsgBoxCreator(this, new MsgBoxCreatorEventArgs(errorMsg));
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
                    OnPropertyChange("AsianSign");
                    OnPropertyChange("WesternSign");
                }
            }
        }

        public int Age
        {
            get
            {
                DateTime currDay = DateTime.Today;
                int age = currDay.Year - _model.BirthDate.Year;
                if (_model.BirthDate.AddYears(age) > currDay) age--;
                if (age < 0 || age > 135)
                {
                    OnMsgBoxCreator("Invalid age!");
                }
                if (_model.BirthDate.Month == currDay.Month && _model.BirthDate.Day == currDay.Day)
                {
                    OnMsgBoxCreator("Happy birthday!");
                }
                return Math.Clamp(age, 0, 135);
            }
        }

        public string AsianSign
        {
            get
            {
                int asianHoroscopeIndex = (_model.BirthDate.Year - 4) % 12;
                switch (asianHoroscopeIndex)
                {
                    case 0:
                        return "Rat";
                    case 1:
                        return "Bull";
                    case 2:
                        return "Tiger";
                    case 3:
                        return "Rabbit";
                    case 4:
                        return "Dragon";
                    case 5:
                        return "Snake";
                    case 6:
                        return "Horse";
                    case 7:
                        return "Goat";
                    case 8:
                        return "Monkey";
                    case 9:
                        return "Cock";
                    case 10:
                        return "Dog";
                    case 11:
                        return "Pig";
                    default:
                        return "Invalid date";
                }
            }
        }

        public string WesternSign
        {
            get
            {
                int month = _model.BirthDate.Month;
                int day = _model.BirthDate.Day;
                if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                {
                    return "Aries";
                }
                else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                {
                    return "Taurus";
                }
                else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                {
                    return "Gemini";
                }
                else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                {
                    return "Cancer";
                }
                else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                {
                    return "Leo";
                }
                else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                {
                    return "Virgo";
                }
                else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                {
                    return "Libra";
                }
                else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                {
                    return "Scorpio";
                }
                else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                {
                    return "Sagittarius";
                }
                else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                {
                    return "Capricorn";
                }
                else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                {
                    return "Aquarius";
                }
                else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                {
                    return "Pices";
                }
                else
                {
                    return "Invalid date";
                }
            }
        }
    }
}
