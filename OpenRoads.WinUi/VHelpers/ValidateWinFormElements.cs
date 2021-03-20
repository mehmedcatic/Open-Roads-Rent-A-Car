using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRoads.WinUI
{
    public static class ValidateWinFormElements
    {
        private const string _requiredField = "Required field!";
        private const string _numberField = "Please fill the field with numbers only!";
        private const string _maxNumbersExceeded = "Maximum numbers count is 12!";
        private const string _workingHoursErr = "Please input in 00-24 format!";
        private const string _exceededRange = "Maximum length is 25!";
        private const string _passwordError = "Password must be from 5 to 25 characters and must include A-a and Number!";
        private const string _emailError = "Please input valid e-mail address!";
        private const string _descriptionError = "Maximum length for description is 100 characters!";
        private const string _dateOfBirthError = "You have to be over 18 to register or birth year under 1940!";
        private const string _hireDateError = "Hire date cannot be higher than todays date or hire year lower than 2000!";


        public static void ValidateTextBox(TextBox textBox, CancelEventArgs e, ErrorProvider err, bool number = false,
            bool workingHours = false, bool password = false, bool email = false, bool description = false)
        {
            bool errorExists = false;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                err.SetError(textBox, _requiredField);
                errorExists = true;
            }

            if (!errorExists && textBox.Text.Length > 25 && !description)
            {
                e.Cancel = true;
                err.SetError(textBox, _exceededRange);
                errorExists = true;
            }

            if (!errorExists && description)
            {
                if (textBox.Text.Length > 100)
                {
                    e.Cancel = true;
                    err.SetError(textBox, _descriptionError);
                    errorExists = true;
                }
            }

            if (!errorExists && number)
            {
                string charArr = textBox.Text;
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if ((charArr[i] >= 'A' && charArr[i] <= 'Z') ||
                        (charArr[i] >= 'a' && charArr[i] <= 'z'))
                    {
                        e.Cancel = true;
                        err.SetError(textBox, _numberField);
                        errorExists = true;
                        break;
                    }
                }

                if (textBox.Text.Length > 12)
                {
                    e.Cancel = true;
                    err.SetError(textBox, _maxNumbersExceeded);
                    errorExists = true;
                }

                if (workingHours)
                {
                    if(textBox.Text.Length > 2 || (int.Parse(textBox.Text) < 0 || int.Parse(textBox.Text) > 24))
                    {
                        e.Cancel = true;
                        err.SetError(textBox, _workingHoursErr);
                        errorExists = true;
                    }
                }
            }

            if (!errorExists && password)
            {
                if (textBox.Text.Length < 5)
                {
                    e.Cancel = true;
                    err.SetError(textBox, _passwordError);
                    errorExists = true;
                }

                bool lowerCase = false, upperCase = false, numberExists = false;
                string charArr = textBox.Text;
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (charArr[i] >= 'A' && charArr[i] <= 'Z')
                    {
                        upperCase = true;
                    }

                    if (charArr[i] >= 'a' && charArr[i] <= 'z')
                    {
                        lowerCase = true;
                    }

                    if (charArr[i] >= 48 && charArr[i] <= 57)
                    {
                        numberExists = true;
                    }
                }

                if (!lowerCase || !upperCase || !numberExists)
                {
                    e.Cancel = true;
                    err.SetError(textBox, _passwordError);
                    errorExists = true;
                }
            }

            if (!errorExists && email)
            {
                if (!textBox.Text.Contains("@"))
                {
                    e.Cancel = true;
                    err.SetError(textBox, _emailError);
                    errorExists = true;
                }
            }

            if(!errorExists)
            {
                err.SetError(textBox, null);
            }
        }

        public static void ValidateComboBox(ComboBox cmb, CancelEventArgs e, ErrorProvider err)
        {
            if (cmb.SelectedValue == null || cmb.SelectedValue.ToString() == "0")
            {
                e.Cancel = true;
                err.SetError(cmb, _requiredField);
            }
            else
            {
                err.SetError(cmb, null);
            }
        }

        public static void ValidateDateTimePicker(DateTimePicker dtp, CancelEventArgs e, ErrorProvider err, 
            bool dateOfBirth = false, bool hireDate = false)
        {
            bool errorExists = false;

            if (!dtp.Checked)
            {
                e.Cancel = true;
                err.SetError(dtp, _requiredField);
                errorExists = true;
            }

            if (!errorExists && dateOfBirth)
            {
                var date = dtp.Text;
                int day, month, year;
                var dateParts = date.Split('.');
                day = int.Parse(dateParts[0]);
                month = int.Parse(dateParts[1]);
                year = int.Parse(dateParts[2]);

                int daysCount = 0;
                if ((DateTime.Today.Year - year) > 18)
                    daysCount = ((DateTime.Today.Year - year) * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month > month)
                    daysCount = (18 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month == month && DateTime.Today.Day >= day)
                    daysCount = (18 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month < month)
                    daysCount = (17 * 365) + (month * 30) + day;
                if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month == month && DateTime.Today.Day < day)
                    daysCount = (17 * 365) + (month * 30) + day;
                //if ((DateTime.Today.Year - year) == 18 && DateTime.Today.Month == month && DateTime.Today.Day == day)
                    //daysCount = (18 * 365) + (month * 30) + day;
                
                if (daysCount <= 6570 || year < 1940)
                {
                    e.Cancel = true;
                    err.SetError(dtp, _dateOfBirthError);
                    errorExists = true;
                }
            }

            if (!errorExists && hireDate)
            {
                var date = dtp.Text;
                var dateParts = date.Split('.');
                var year = int.Parse(dateParts[2]);

                if (DateTime.Now < dtp.Value || year < 2000)
                {
                    e.Cancel = true;
                    err.SetError(dtp, _hireDateError);
                    errorExists = true;
                }
            }

            if(!errorExists)
            {
                err.SetError(dtp, null);
            }
        }

        public static void ValidateCheckBox(CheckBox cb, CancelEventArgs e, ErrorProvider err)
        {
            if (!cb.Checked)
            {
                e.Cancel = true;
                err.SetError(cb, _requiredField);
            }
            else
            {
                err.SetError(cb, null);
            }
        }
    }
}
