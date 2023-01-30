using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace ptpm_pr1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnVichisl_Click(object sender, RoutedEventArgs e)
        {
            //Обработчик событий
            try
            {
                //Переменные ввода
                double x = double.Parse(TxtBox_X.Text);
                double y = double.Parse(TxtBox_Y.Text);
                double z = double.Parse(TxtBox_Z.Text);


                //Переменные для расчет миним и максим значений
                double yz_minimum = Math.Min(y, z);
                double yz_maximum = Math.Max(y, z);

                //Обработчик кнопок 
                if (Rb_shx.IsChecked == true)
                {
                    TxtBl_Answer.Text = Convert.ToString(Math.Round((Math.Min(Math.Sinh(x), yz_minimum)) / (Math.Max(x, yz_maximum)), 10));
                    //TxtBl_Answer.Text = "1";
                }
                else if (Rb_x2.IsChecked == true)
                {
                    TxtBl_Answer.Text = Convert.ToString(Math.Round((Math.Min(Math.Pow(x, 2), yz_minimum)) / (Math.Max(x, yz_maximum)), 10));
                    //TxtBl_Answer.Text = "2";
                }
                else if (Rb_e2.IsChecked == true)
                {
                    TxtBl_Answer.Text = Convert.ToString(Math.Round((Math.Min(Math.Pow(Math.Exp(1), x), yz_minimum)) / (Math.Max(x, yz_maximum)), 10));
                    //TxtBl_Answer.Text = "3";
                }

            }
            catch //Проверка на пустую/ые строку/и    или на то, что указаны какие либо др знач не явл цифрами
            {
                if (TxtBox_X.Text == "" || TxtBox_Y.Text == "" || TxtBox_Z.Text == "")
                {
                    MessageBox.Show("Вы оставили одну или не сколько строк пустыми, исправьте это!", "Ошибка пустой строки!");
                }
                else
                {
                    MessageBox.Show("Вы ввели не допустимые значения, исправьте это!", "Ошибка не правильного значения!");
                }
                 
            }
         
        }
        
        //Кнопка очищения
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtBox_X.Clear();
            TxtBox_Y.Clear();
            TxtBox_Z.Clear();
            TxtBl_Answer.Text = string.Empty;
        }

        //Кнопка с выходом
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Закрыть приложение ?", "Выход", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes) { Environment.Exit(0); }
            else { }
        }
    }
}
