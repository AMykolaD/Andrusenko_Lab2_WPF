using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Andrusenko_Lab2_WPF.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object>? commandA;
        private string isAdultText;
        private string sunSignText;
        private string chineseSignText;
        private string isBirthdayText;
        private DateTime? birthdate;
        private string nameTextBox;
        private string surnameTextBox;
        private string emailTextBox;
        private string birthdateTextBox;
        private string nameTextBlock;
        private string surnameTextBlock;
        private string emailTextBlock;
        private string birthdateTextBlock;

        private bool isEnabled = true;

        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindowViewModel()
        {
            isAdultText =
            sunSignText =
            chineseSignText =
            isBirthdayText =

            nameTextBlock =
            surnameTextBlock =
            emailTextBlock =
            birthdateTextBlock =

            nameTextBox =
            surnameTextBox =
            emailTextBox =
            birthdateTextBox = "";
        }
        public RelayCommand<object> CommandA
        {
            get
            {
                return commandA ??= new RelayCommand<object>(_ => ExecuteProceed(), CanExecute);
            }
        }

        public string IsAdultText {
            get => isAdultText;
            set {
                isAdultText = value; 
                OnPropertyChanged();
            }
        }

        public string SunSignText {
            get => sunSignText; 
            set {
                sunSignText = value; 
                OnPropertyChanged();
            }
        }
        public string ChineseSignText
        {
            get => chineseSignText;
            set {
                chineseSignText = value;
                OnPropertyChanged();
            }
        }
        public string IsBirthdayText
        {
            get => isBirthdayText; set
            {
                isBirthdayText = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birthdate
        {
            get => birthdate; set
            {
                birthdate = value;
                OnPropertyChanged();
            }
        }
        public string NameTextBox
        {
            get => nameTextBox; set
            {
                nameTextBox = value;
                OnPropertyChanged();
            }
        }
        public string SurnameTextBox
        {
            get => surnameTextBox; set
            {
                surnameTextBox = value;
                OnPropertyChanged();
            }
        }
        public string EmailTextBox
        {
            get => emailTextBox; set
            {
                emailTextBox = value;
                OnPropertyChanged();
            }
        }
        public string BirthdateTextBox
        {
            get => birthdateTextBox; set
            {
                birthdateTextBox = value;
                OnPropertyChanged();
            }
        }
        public string NameTextBlock
        {
            get => nameTextBlock; set
            {
                nameTextBlock = value;
                OnPropertyChanged();
            }
        }
        public string SurnameTextBlock
        {
            get => surnameTextBlock; set
            {
                surnameTextBlock = value;
                OnPropertyChanged();
            }
        }
        public string EmailTextBlock
        {
            get => emailTextBlock; set
            {
                emailTextBlock = value;
                OnPropertyChanged();
            }
        }
        public string BirthdateTextBlock { get => birthdateTextBlock; set
            {
                birthdateTextBlock = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled { get => isEnabled; set {
                isEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool CanExecute(object obj)
        {
            return (NameTextBox != null && SurnameTextBox != null && EmailTextBox != null && BirthdateTextBox != null &&
                NameTextBox.Length != 0 && SurnameTextBox.Length != 0 && EmailTextBox.Length != 0 && Birthdate != null);
        }
        private async void ExecuteProceed()
        {
            IsEnabled = false;
            await Task.Run(ExecuteAsync);
            IsEnabled = true;
        }

        private void ExecuteAsync()
        {
            {
                int age = Person.Age((DateTime)Birthdate);
                if (age > 135 || age < 0)
                {
                    if (age > 135)
                        MessageBox.Show("Your age is too high", "Something's wrong");
                    else
                        MessageBox.Show("You are born in the future", "Something's wrong");
                    IsAdultText = "";
                    SunSignText = "";
                    ChineseSignText = "";
                    IsBirthdayText = "";

                    NameTextBlock = "";
                    SurnameTextBlock = "";
                    EmailTextBlock = "";
                    BirthdateTextBlock = "";
                    return;
                }
                Person person;
                person = new Person(NameTextBox, SurnameTextBox, EmailTextBox, (DateTime)Birthdate);
                if (person.IsBirthday) MessageBox.Show($"You have a birthday today, {NameTextBox}!", "Congratulations!");

                NameTextBlock = $"Name: {NameTextBox}";

                SurnameTextBlock = $"Surname: {SurnameTextBox}";

                EmailTextBlock = $"Email: {EmailTextBox}";

                BirthdateTextBlock = $"Date of birth: {((DateTime)Birthdate).Day}." +
                    $"{((DateTime)Birthdate).Month}." +
                    $"{((DateTime)Birthdate).Year}";

                IsAdultText = "You are " + (person.IsAdult ? "adult" : "children");

                SunSignText = "Your sun sign is " + person.SunSign;

                if (((DateTime)Birthdate).Year > 1900) ChineseSignText = "Your chinese sign is " + person.ChineseSign;
                else ChineseSignText = "";

                IsBirthdayText = (person.IsBirthday ? "You have birthday today" : "Your birthday isn't today");

            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            //Check if current thread is main
            if(App.Current.Dispatcher.Thread == Thread.CurrentThread) CommandA.RaiseCanExecuteChanged();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
