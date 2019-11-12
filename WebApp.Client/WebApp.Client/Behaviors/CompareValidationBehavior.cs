using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WebApp.Client.Behaviors
{
    public class CompareValidationBehavior : Behavior<Entry>
    {
        public static BindableProperty TextProperty = BindableProperty.Create<CompareValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty IsValidPropperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(RegisterPageValidationBehavior), false, BindingMode.OneWayToSource);
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidPropperty); }
            set { SetValue(IsValidPropperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = e.NewTextValue == Text;

            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Salmon;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
