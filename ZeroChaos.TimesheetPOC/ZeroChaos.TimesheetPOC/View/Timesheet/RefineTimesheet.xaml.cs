using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC
{
    public partial class RefineTimesheet : ContentPage
    {
        Entry setEntryValue;
        void entryDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            if (setEntryValue != null)
            {
                setEntryValue.Text = datePickervalue.Date.ToString();
                setEntryValue = null;
            }
        }

        void textBoxFocuse(object sender, EventArgs e)
        {
            //d <DatePicker x:Name="datePicker"></DatePicker>ate
            datePickervalue.IsVisible = true;
            datePickervalue.IsEnabled = true;
            setEntryValue = (Entry)sender;
        }

        public RefineTimesheet()
        {
            InitializeComponent();

            txtMinSubmitDate.Focused += (sender, e) =>
            {
                // date.Focus();
            };
        }


    }

}
