using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControls
{
    [ContentProperty("Selected")]
    /// <summary>
    /// Interaction logic for RadioGroup.xaml
    /// </summary>
    public partial class RadioGroup : UserControl, INotifyPropertyChanged
    {

        //Dependency Property: propdp

        #region RadioButtonStyle
        public Style RadioButtonStyle
        {
            get { return (Style)GetValue(RadioButtonStyleProperty); }
            set { SetValue(RadioButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadioButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadioButtonStyleProperty =
            DependencyProperty.Register("RadioButtonStyle", typeof(Style), typeof(RadioGroup), new PropertyMetadata(null,StyleChanged));

        private static void StyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is RadioGroup group)
            {
                foreach (RadioButton button in group.wrapPanel.Children)
                {

                    button.Style = group.RadioButtonStyle;
                }
            }
        }
        #endregion

        #region SelectedAsBrush
        public Brush SelectedAsBrush
        {
            get
            {
                if(Selected == null)
                {
                    return Brushes.Aqua;
                }

                string colorAsString = Selected.ToString();
                Brush brush = (Brush)new BrushConverter().ConvertFromString(colorAsString);
                return brush ?? Brushes.Aqua;
            }
        }
        #endregion

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(RadioGroup), new PropertyMetadata(Orientation.Vertical));
        #endregion

        #region EnumType
        public Type EnumType
        {
            get { return (Type)GetValue(EnumTypeProperty); }
            set { SetValue(EnumTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnumType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.Register("EnumType", typeof(Type), typeof(RadioGroup), new PropertyMetadata(null, EnumTypeChanged));

        private static void EnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RadioGroup radiogroup && e.NewValue is Type enumType)
            {
                var values = Enum.GetValues(enumType);

                foreach (var item in values)
                {
                    RadioButton newButton = new RadioButton
                    {
                        Content = item,
                    };

                    radiogroup.wrapPanel.Children.Add(newButton);
                }
            }
        }
        #endregion

        #region Selected
        public object Selected
        {
            get { return (object)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(object), typeof(RadioGroup), new PropertyMetadata(null, SelectedChanged));


        private static void SelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RadioGroup radiogroup && e.NewValue != null && !e.NewValue.Equals(e.OldValue))
            {
                foreach (RadioButton button in radiogroup.wrapPanel.Children)
                {
                    if (button.Content.Equals(e.NewValue))
                    {
                        button.IsChecked = true;
                    }
                    //radiogroup.RadioButtonStyle.BasedOn = (Style)radiogroup.FindResource(typeof(RadioButton));
                    button.Style = radiogroup.RadioButtonStyle;
                }
                radiogroup.PropertyChanged?.Invoke(radiogroup, new PropertyChangedEventArgs(nameof(SelectedAsBrush)));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public RadioGroup()
        {
            InitializeComponent();
            rootContainer.DataContext = this;
            RadioButtonStyle = (Style)this.Resources["radioButtonStyle"];
        }

        private void WrapPanel_Checked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton button)
            {
                Selected = button.Content;
            }
        }
    }
}
