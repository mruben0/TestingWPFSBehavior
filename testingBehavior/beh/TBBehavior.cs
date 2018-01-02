using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace testingBehavior.beh
{
    public class TBBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Text = SelectedInt.ToString();
        }

        private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            AssociatedObject.Text = SelectedInt.ToString();
        }

        protected override void OnChanged()
        {
            base.OnChanged();
            if (SelectedInt > -1 && AssociatedObject != null)
            {
                if (SelectedInt == 0)
                {
                    AssociatedObject.Text = FirstValue;
                }
                else if (SelectedInt == 1)
                {
                    AssociatedObject.Text = SecondValue;
                } 
            }       
        }

        public static string sd = DateTime.Now.Second.ToString();

        public int SelectedInt
        {
            get { return (int)GetValue(SelectedIntProperty); }
            set { SetValue(SelectedIntProperty, value); }
        }



        public string FirstValue
        {
            get { return (string)GetValue(FirstValueProperty); }
            set { SetValue(FirstValueProperty, value); }
        }

        public static readonly DependencyProperty FirstValueProperty =
            DependencyProperty.Register("FirstValue", typeof(string), typeof(TBBehavior), new PropertyMetadata(string.Empty));



        public string SecondValue
        {
            get { return (string)GetValue(SecondValueProperty); }
            set { SetValue(SecondValueProperty, value); }
        }

        public static readonly DependencyProperty SecondValueProperty =
            DependencyProperty.Register("SecondValue", typeof(string), typeof(TBBehavior), new PropertyMetadata(string.Empty));



        public static readonly DependencyProperty SelectedIntProperty =
            DependencyProperty.Register("SelectedInt", typeof(int), typeof(TBBehavior), new PropertyMetadata(0, new PropertyChangedCallback(SelectedIntPropertyChanged)));

        private static void SelectedIntPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(d.GetValue(SelectedIntProperty));
        }        
    }
}
