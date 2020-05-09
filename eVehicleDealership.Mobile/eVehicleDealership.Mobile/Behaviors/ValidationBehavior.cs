using eVehicleDealership.Mobile.Validators.Contracts;
using eVehicleDealership.Mobile.Validators.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace eVehicleDealership.Mobile.Behaviors
{

    public class ValidationBehavior : Behavior<View>
    {
        IErrorStyle _style = new BasicErrorStyle();
        View _view;
        public string PropertyName { get; set; }
        public ValidationGroupBehavior Group { get; set; }
        public ObservableCollection<IValidator> Validators { get; set; } = new ObservableCollection<IValidator>();

        public bool Validate()
        {
            bool isValid = true;
            string errorMessage = "";

            foreach (IValidator validator in Validators)
            {
                bool result;
                var isPicker = (_view as Picker);
                if (isPicker != null)
                {
                    if(isPicker.SelectedIndex == -1)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    var value = _view.GetType()
                                           .GetProperty(PropertyName)
                                           .GetValue(_view) as string;
                    result = validator.Check(value);
                }

                isValid = isValid && result;

                if (!result)
                {
                    errorMessage = validator.Message;
                    break;
                }
            }

            if (!isValid)
            {
                _style.ShowError(_view, errorMessage);

                return false;
            }
            else
            {
                _style.RemoveError(_view);

                return true;
            }

        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            _view = bindable as View;
            _view.PropertyChanged += OnPropertyChanged;
            _view.Unfocused += OnUnFocused;

            if (Group != null)
            {
                Group.Add(this);
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            _view.PropertyChanged -= OnPropertyChanged;
            _view.Unfocused -= OnUnFocused;

            if (Group != null)
            {
                Group.Remove(this);
            }
        }

        void OnUnFocused(object sender, FocusEventArgs e)
        {
            Validate();

            if (Group != null)
            {
                Group.Update();
            }
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName)
            {
                Validate();
            }
        }
    }
}
