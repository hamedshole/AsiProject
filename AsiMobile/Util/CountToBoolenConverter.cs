using Asi.Model;
using System;
using Xamarin.Forms;
using Cnvrt = System.Convert;

namespace AsiMobile.Util
{
    public class NoteColumnCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //var x = false;
            try
            {
                FormDataGroupModel formDataGroup = value as FormDataGroupModel;
                int columncount = formDataGroup.AnswerColumns.Count;
                if (formDataGroup.HasNote)
                {
                    return (Cnvrt.ToInt32(columncount) - 1) >= Cnvrt.ToInt32(parameter);
                }
                else
                {
                    return Cnvrt.ToInt32(columncount) >= Cnvrt.ToInt32(parameter);
                }
            }
            catch (Exception)
            {

                return true;

            }
            ////int count = Cnvrt.ToInt32(value);
            ////int index = Cnvrt.ToInt32(parameter);
            ////if (index <= count)
            ////    x = true;
            //////else
            //////    return false;
            //return x;
            //int count = 
            //int index = Cnvrt.ToInt32(parameter);
            //var x = count >= index;
            //return x;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class CountToBoolenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //var x = false;

            var x= Cnvrt.ToInt32(value) >= Cnvrt.ToInt32(parameter);
            return x;
            
            ////int count = Cnvrt.ToInt32(value);
            ////int index = Cnvrt.ToInt32(parameter);
            ////if (index <= count)
            ////    x = true;
            //////else
            //////    return false;
            //return x;
            //int count = 
            //int index = Cnvrt.ToInt32(parameter);
            //var x = count >= index;
            //return x;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PlusOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //var x = false;

            return Cnvrt.ToInt32(value) + 1;

            ////int count = Cnvrt.ToInt32(value);
            ////int index = Cnvrt.ToInt32(parameter);
            ////if (index <= count)
            ////    x = true;
            //////else
            //////    return false;
            //return x;
            //int count = 
            //int index = Cnvrt.ToInt32(parameter);
            //var x = count >= index;
            //return x;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class IsNote : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool x = Cnvrt.ToBoolean(value);
            if (x && Cnvrt.ToInt16(parameter) == 1)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class CollectionVisibleConverter : IValueConverter
    {
        public object Convert(object Goup, Type targetType, object kind, System.Globalization.CultureInfo culture)
        {
            bool value = false;
            FormDataGroupModel group = (FormDataGroupModel)Goup;
            if (group != null)
            {
                if (!group.IsCheckBox && group.QuestionHeaders.Count == 1 && string.Equals(kind, "questiononeheader"))
                {
                    value = true;
                }
                if (!group.IsCheckBox && group.QuestionHeaders.Count == 1 && string.Equals(kind, "questiontwoheader"))
                {
                    value = true;
                }
                if (!group.IsCheckBox && group.QuestionHeaders.Count == 1 && string.Equals(kind, "questionthreeheader"))
                {
                    value = true;
                }
                if (group.IsCheckBox && group.QuestionHeaders.Count == 1 && group.AnswerColumns.Count == 1 && string.Equals(kind, "checklistonequestiononeheader"))
                {
                    value = true;
                }
                if (group.IsCheckBox && group.QuestionHeaders.Count == 2 && group.AnswerColumns.Count == 1 && string.Equals(kind, "checklisttwoquestiononeheader"))
                {
                    value = true;
                }
                if (group.IsCheckBox && group.QuestionHeaders.Count == 3 && group.AnswerColumns.Count == 1 && string.Equals(kind, "checklistthreequestiononeheader"))
                {
                    value = true;
                }
            }
            

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
