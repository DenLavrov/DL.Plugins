using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms.Markup;

namespace Xamarin.Forms.Sample.UI.Controls
{
    class ValidatableEntry: Grid
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidatableEntry),
            propertyChanged: (bindable, value, newValue) =>
            {
                var view = (ValidatableEntry) bindable;
                if ((bool) newValue)
                {
                    view._underline.Color = Color.Black;
                    view._errorLabel.Opacity = 0;
                }
                else
                {
                    view._underline.Color = Color.Red;
                    view._errorLabel.Opacity = 1;
                }
            });

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ValidatableEntry), defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (bindable, value, newValue) =>
            {
                ((ValidatableEntry) bindable)._entry.Text = newValue?.ToString();
            });

        public string Text
        {
            get => GetValue(TextProperty)?.ToString();
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ValidatableEntry),
            propertyChanged: (bindable, value, newValue) =>
            {
                ((ValidatableEntry)bindable)._errorLabel.Text = newValue?.ToString();
            });

        public string ErrorText
        {
            get => GetValue(ErrorTextProperty)?.ToString();
            set => SetValue(ErrorTextProperty, value);
        }

        public static readonly BindableProperty ValidateCommandProperty = BindableProperty.Create(nameof(ValidateCommand), typeof(ICommand), typeof(ValidatableEntry));

        public ICommand ValidateCommand
        {
            get => (ICommand)GetValue(ValidateCommandProperty);
            set => SetValue(ValidateCommandProperty, value);
        }

        public object ValidateCommandParameter { get; set; }

        readonly NoUnderlineEntry _entry;
        readonly BoxView _underline;
        readonly Label _errorLabel;

        public ValidatableEntry()
        {
            RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Auto, 1, GridLength.Auto);
            RowSpacing = 4;
            Children.Add(new NoUnderlineEntry
            {
                TextColor = Color.Black,
                FontSize = 16
            }.Assign(out _entry).Invoke(entry => entry.TextChanged += OnEntryTextChanged));
            Children.Add(new BoxView{Color = Color.Black}.Row(1).Assign(out _underline));
            Children.Add(new Label
            {
                FontSize = 14,
                TextColor = Color.Red
            }.Row(2).Assign(out _errorLabel));
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
                _entry.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = _entry.Text;
            if(ValidateCommand?.CanExecute(null) ?? false)
                ValidateCommand.Execute(ValidateCommandParameter);
        }
    }
}
