using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Filter;
using Filter.Base;
using PropertiesValidation.Base;
using Xamarin.Forms.Sample.BL.Models;
using Xamarin.Forms.Sample.BL.Models.Filters;
using Xamarin.Forms.Sample.Helpers;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class FilterViewModel: Bindable, IFilterable
    {
        public ICommand FilterCommand { get; }
        public ICommand RemoveFilterCommand { get; }
        
        public DynamicValuesDictionary<string, IEnumerable> FilteredData { get; } =
            new DynamicValuesDictionary<string, IEnumerable>();
        
        public List<Person> Persons { get; }

        public FilterViewModel()
        {
            FilterCommand = new Command(Filter);
            RemoveFilterCommand = new Command(RemoveFilterCommandExecute);
            Persons = new List<Person>
            {
                new Person
                {
                    Name = "Oliver",
                    Surname = "Smith"
                },
                new Person
                {
                    Name = "Jake",
                    Surname = "Murphy"
                },
                new Person
                {
                    Name = "Noah",
                    Surname = "Brown"
                },
                new Person
                {
                    Name = "James",
                    Surname = "Williams"
                },
                new Person
                {
                    Name = "Jack",
                    Surname = "O'Sullivan"
                },
                new Person
                {
                    Name = "Connor",
                    Surname = "O'Kelly"
                },
                new Person
                {
                    Name = "Liam",
                    Surname = "Jones"
                }
            };
            ((IFilterable)this).Init(nameof(Persons));
        }

        void RemoveFilterCommandExecute()
        {
            this.SetFilter(nameof(Persons), null);
        }

        void Filter()
        {
            this.SetFilter(nameof(Persons), AlphabetFilter.Instance);
        }
    }
}