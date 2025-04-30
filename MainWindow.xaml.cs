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

namespace WpfAppNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();


        }

        /*данный метод необходим для вывода картинки с животными*/
        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐮", "🐮",
                "🐷", "🐷",
                "🐗", "🐗",
                "🐭", "🐭",
                "🐹", "🐹",
                "🐰", "🐰",
                "🐻", "🐻",
                "🐸", "🐸",
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {

                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        //Обработчик событий 
        /*Создаем новую переменную типа TextBlock*/
        TextBlock lastTextBlockClicked;

        /*переменная для совпадения двух элементов*/
        bool findingMatch = false;

        //метод для обработки событий на textBlock
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock textBlock = sender as TextBlock;

            //Если у нас нет совпадений, тогда
            if (findingMatch == false)
            {
                //прячем данный элемент
                textBlock.Visibility = Visibility.Hidden;
                //данный textBlock записываем в переменную, чтобы сравнить со следующим
                lastTextBlockClicked = textBlock;
                //ставим что мы начали сравнение
                findingMatch = true;

            //Если наш последний выбранный элемент совпал с выбранным элементом тогда
            } else if (lastTextBlockClicked.Text == textBlock.Text)
            {
                //новый выбранный элемент мы скрываем
                textBlock.Visibility = Visibility.Hidden;
                //выключаем совпдаения
                findingMatch = false;

                //Если мы не угадали со вторым животным тогда
            } else
            {
                //последнее выбранное животное мы снова делаем видимым
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
