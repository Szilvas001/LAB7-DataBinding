using LAB09_MAUI_DataBindingLab.Model;
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Linq;

namespace LAB09_MAUI_DataBindingLab.View
{
    public partial class NewTransaction : ContentView, INotifyPropertyChanged
    {
        private TransactionList Transactions;
        public CategoryList Categories { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Values entered into the form
        private int selectedCategoryIndex = 0;
        public int SelectedCategoryIndex
        {
            get => selectedCategoryIndex;
            set
            {
                if (selectedCategoryIndex != value)
                {
                    selectedCategoryIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        private int value = 0;
        public int Value
        {
            get => value;
            set
            {
                if (value != value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public NewTransaction()
        {
            this.BindingContext = this;
            InitializeComponent();
        }

        internal void SetModel(ExpenseManager expenseManager)
        {
            this.Transactions = expenseManager.Transactions;
            this.Categories = expenseManager.Categories;
            OnPropertyChanged(nameof(Transactions));
            OnPropertyChanged(nameof(Categories));
        }

        private void AddTransactionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Description) || Value == 0)
            {
                return;
            }

            var transaction = new Transaction
            {
                Description = Description,
                Value = Value,
                Category = Categories[SelectedCategoryIndex]
            };

            Transactions.Add(transaction);

            Description = string.Empty;
            Value = 0;
            SelectedCategoryIndex = 0;
        }

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
