using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace FineFabrics.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<Customer> Customers { get; } = new();

        public Customer? SelectedCustomer 
        { 
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                { 
                    _selectedCustomer = value;
                    RaisePropertyChanges();
                }
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
        }

    }
}
