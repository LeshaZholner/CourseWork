using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Client.Helpers;
using Xamarin.Forms;

namespace WebApp.Client.Behaviors
{
    public class RegisterPageValidationBehavior : Behavior<Entry>
    {
        public static BindableProperty PasswordProperty = BindableProperty.Create(nameof(Password), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static BindableProperty ConfirmPasswordProperty = BindableProperty.Create(nameof(ConfirmPassword), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static BindableProperty PhonenumberProperty = BindableProperty.Create(nameof(Phonenumber), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static BindableProperty FirstNameProperty = BindableProperty.Create(nameof(FirstName), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static BindableProperty LastNameProperty = BindableProperty.Create(nameof(LastName), typeof(string), typeof(RegisterPageValidationBehavior), "", BindingMode.OneWayToSource);
        public static readonly BindableProperty IsValidPropperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(RegisterPageValidationBehavior), false, BindingMode.OneWayToSource);

        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set
            {
                SetValue(EmailProperty, value);
            }
        }
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }
        public string ConfirmPassword
        {
            get { return (string)GetValue(ConfirmPasswordProperty); }
            set
            {
                SetValue(ConfirmPasswordProperty, value);
            }
        }
        public string Phonenumber
        {
            get { return (string)GetValue(PhonenumberProperty); }
            set
            {
                SetValue(PhonenumberProperty, value);
            }
        }
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set
            {
                SetValue(FirstNameProperty, value);
            }
        }
        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set
            {
                SetValue(LastNameProperty, value);
            }
        }
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidPropperty); }
            set { SetValue(IsValidPropperty, ValidationHelper.IsRegisterPageValidation(Email, Password, ConfirmPassword, Phonenumber, FirstName, LastName)); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            switch (entry.AutomationId)
            {
                case "email":
                    {
                        entry.BackgroundColor = ValidationHelper.IsEmailvalidation(entry.Text) ? Color.Default : Color.Salmon;
                        break;
                    }
                case "password":
                    {
                        entry.BackgroundColor = ValidationHelper.IsPasswordValidation(entry.Text) ? Color.Default : Color.Salmon;
                        break;
                    }
                case "confirmPassword":
                    {
                        entry.BackgroundColor = ValidationHelper.IsCompareValidation(entry.Text, ConfirmPassword) ? Color.Default : Color.Salmon;
                        break;
                    }
                case "firstname":
                    {
                        entry.BackgroundColor = ValidationHelper.IsRequiredValidation(entry.Text) ? Color.Default : Color.Salmon;
                        break;
                    }
                case "lastname":
                    {
                        entry.BackgroundColor = ValidationHelper.IsRequiredValidation(entry.Text) ? Color.Default : Color.Salmon;
                        break;
                    }
                case "phonenumber":
                    {
                        entry.BackgroundColor = ValidationHelper.IsPhonenumberValidation(entry.Text) ? Color.Default : Color.Salmon;
                        break;
                    }
            }
        }

        protected override void OnDetachingFrom(Entry binable)
        {
            binable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(binable);
        }

    }
}
