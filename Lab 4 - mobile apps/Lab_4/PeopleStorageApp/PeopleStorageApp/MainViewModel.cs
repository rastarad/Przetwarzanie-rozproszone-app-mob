using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PeopleStorageApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string name = string.Empty;
        string lastName = string.Empty;
        string phoneNumber = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if(name == value)
                    return;

                name = value;
                OnPropertyChaneged(nameof(Name));
                OnPropertyChaneged(nameof(DisplayName));
                
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value)
                    return;

                lastName = value;
                OnPropertyChaneged(nameof(lastName));
                OnPropertyChaneged(nameof(DisplayLastName));

            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber == value)
                    return;

                phoneNumber = value;
                OnPropertyChaneged(nameof(phoneNumber));
                OnPropertyChaneged(nameof(DisplayPhoneNumber));

            }
        }

        public string DisplayName => $"Name entered: {Name}";
        public string DisplayLastName => $"Last name entered: {lastName}";
        public string DisplayPhoneNumber => $"Phone number entered: {phoneNumber}";

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChaneged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
