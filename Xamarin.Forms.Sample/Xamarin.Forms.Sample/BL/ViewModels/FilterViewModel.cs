using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Filter.Base;
using Xamarin.Forms.Sample.BL.Models;
using Xamarin.Forms.Sample.BL.Models.Filters;
using Xamarin.Forms.Sample.Helpers;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class FilterViewModel: Bindable
    {
        public ICommand FilterCommand { get; }
        public ICommand RemoveFilterCommand { get; }

        public IFilterableObject<Person> Persons { get; }

        public FilterViewModel()
        {
            FilterCommand = new Command(Filter);
            RemoveFilterCommand = new Command(RemoveFilterCommandExecute);
            Persons = new BindableFilterableObject<Person>
            {
                Value = new List<Person>
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
                },
                Filters = { new AlphabetFilter<Person>() }
            };
        }

        void RemoveFilterCommandExecute()
        {
            Persons.RemoveFiltering();
        }

        void Filter()
        {
            Persons.Filter();
        }
    }
}