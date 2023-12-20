using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace actors_site
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        XDocument doc1;
        XDocument doc2;
        XDocument doc3;
        public ObservableCollection<object> ACTORSCollection;
        public ObservableCollection<object> PERFORMANCESCollection;
        public ObservableCollection<object> EMPLOYMENTCollection;
        private int counter = 0;
        private bool yesno = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

       private void MenuItem_Click(object sender, RoutedEventArgs e)
       {
            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavline5.Visibility = Visibility.Visible;
            dobavline6.Visibility = Visibility.Visible;
            Actors.Visibility = Visibility.Visible;
            Performances.Visibility = Visibility.Hidden;
            Employment.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;
            text.Visibility = Visibility.Hidden;

            counter = 1;
            doc1 = XDocument.Load("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Actors.xml");
            var ACTORS = (from x in doc1.Element("Actors").Elements("Actor")
                orderby x.Element("Kod").Value
                select new
                {
                    Код = x.Element("Kod").Value,
                    Фамилия = x.Element("Surname").Value,
                    Имя = x.Element("Name").Value,
                    Отчество = x.Element("Patronymic").Value,
                    Статус = x.Element("Status").Value,
                    Стаж = x.Element("Experience").Value
                }).ToList();

            var ACTORSCollection = new ObservableCollection<object>(ACTORS);
            dg.ItemsSource = ACTORSCollection;
       }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavline5.Visibility = Visibility.Hidden;
            dobavline6.Visibility = Visibility.Hidden;
            Actors.Visibility = Visibility.Hidden;
            Performances.Visibility = Visibility.Visible;
            Employment.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;
            text.Visibility = Visibility.Hidden;


            counter = 2;
            doc2 = XDocument.Load("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Performances.xml");
            var PERFORMANCES = (from x in doc2.Element("Performances").Elements("Performance")
                          orderby x.Element("Kod").Value
                          select new
                          {
                              Код = x.Element("Kod").Value,
                              Имя = x.Element("Name").Value,
                              Год = x.Element("Year").Value,
                              Бюджет = x.Element("Budget").Value
                          }).ToList();

            var PERFORMANCESCollection = new ObservableCollection<object>(PERFORMANCES);
            dg.ItemsSource = PERFORMANCESCollection;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            dobavlenie1.Visibility = Visibility.Visible;
            dobavlenie2.Visibility = Visibility.Visible;
            dobavlenie3.Visibility = Visibility.Visible;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavline5.Visibility = Visibility.Hidden;
            dobavline6.Visibility = Visibility.Hidden;
            Actors.Visibility = Visibility.Hidden;
            Performances.Visibility = Visibility.Hidden;
            Employment.Visibility = Visibility.Visible;
            dg.Visibility = Visibility.Visible;
            text.Visibility = Visibility.Hidden;

            counter = 3;
            doc3 = XDocument.Load("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Employment.xml");
            var EMPLOYMENT = (from x in doc3.Element("Employments").Elements("Employment")
                          orderby x.Element("KodA").Value
                          select new
                          {
                              Код__актера = x.Element("KodA").Value,
                              Код__спектакля = x.Element("KodP").Value,
                              Роль = x.Element("Role").Value,
                              Цена = x.Element("Price").Value
                          }).ToList();

            var EMPLOYMENTCollection = new ObservableCollection<object>(EMPLOYMENT);
            dg.ItemsSource = EMPLOYMENTCollection;
        }
        private void MenuItemDobav_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Visible;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Hidden;
        }
        private void MenuItemRed_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Visible;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Hidden;
        }
        private void MenuItemDel_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Visible;
            poisk.Visibility = Visibility.Hidden;
        }
        private void MenuItemPoisk_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Visible;
        }

        private void buttonDobav_Click(object sender, RoutedEventArgs e)
        {

            if (counter == 1)
            {
                doc1.Element("Actors").Add(new XElement("Actor",
                new XElement("Kod", dobavlenie1.Text),
                new XElement("Surname", dobavlenie2.Text),
                new XElement("Name", dobavlenie3.Text),
                new XElement("Patronymic", dobavlenie4.Text),
                new XElement("Status", dobavline5.Text),
                new XElement("Experience", dobavline6.Text)));

                doc1.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Actors.xml");

                MessageBox.Show("Новые данные добавлены!");

                var ACTORS = (from x in doc1.Element("Actors").Elements("Actor")
                              orderby x.Element("Kod").Value
                              select new
                              {
                                  Код = x.Element("Kod").Value,
                                  Фамилия = x.Element("Surname").Value,
                                  Имя = x.Element("Name").Value,
                                  Отчество = x.Element("Patronymic").Value,
                                  Статус = x.Element("Status").Value,
                                  Стаж = x.Element("Experience").Value
                              }).ToList();

                var ACTORSCollection = new ObservableCollection<object>(ACTORS);
                dg.ItemsSource = ACTORSCollection;
            }
            if (counter == 2)
            {
                doc2.Element("Performances").Add(new XElement("Performance",
                new XElement("Kod", dobavlenie1.Text),
                new XElement("Name", dobavlenie2.Text),
                new XElement("Year", dobavlenie3.Text),
                new XElement("Budget", dobavlenie4.Text)));

                doc2.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Performances.xml");

                MessageBox.Show("Новые данные добавлены!");

                var PERFORMANCES = (from x in doc2.Element("Performances").Elements("Performance")
                                    orderby x.Element("Kod").Value
                                    select new
                                    {
                                        Код = x.Element("Kod").Value,
                                        Имя = x.Element("Name").Value,
                                        Год = x.Element("Year").Value,
                                        Бюджет = x.Element("Budget").Value
                                    }).ToList();

                var PERFORMANCESCollection = new ObservableCollection<object>(PERFORMANCES);
                dg.ItemsSource = PERFORMANCESCollection;
            }
            if (counter == 3)
            {
                doc3.Element("Employments").Add(new XElement("Employment",
                new XElement("KodA", dobavlenie1.Text),
                new XElement("KodP", dobavlenie2.Text),
                new XElement("Role", dobavlenie3.Text),
                new XElement("Price", dobavlenie4.Text)));

                doc3.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Employment.xml");

                MessageBox.Show("Новые данные добавлены!");

                var EMPLOYMENT = (from x in doc3.Element("Employments").Elements("Employment")
                                  orderby x.Element("KodA").Value
                                  select new
                                  {
                                      Код_актера = x.Element("KodA").Value,
                                      Код_спектакля = x.Element("KodP").Value,
                                      Роль = x.Element("Role").Value,
                                      Цена = x.Element("Price").Value
                                  }).ToList();

                var EMPLOYMENTCollection = new ObservableCollection<object>(EMPLOYMENT);
                dg.ItemsSource = EMPLOYMENTCollection;
            }
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                IEnumerable<XElement> test =
                from el in doc1.Element("Actors").Elements("Actor")
                where (string)el.Element("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Surname", dobavlenie2.Text);
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Surname", dobavlenie3.Text);
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Surname", dobavlenie4.Text);
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Surname", dobavline5.Text);
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Surname", dobavline6.Text);

                    doc1.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Actors.xml");

                    var ACTORS = (from x in doc1.Element("Actors").Elements("Actor")
                                  orderby x.Element("Kod").Value
                                  select new
                                  {
                                      Код = x.Element("Kod").Value,
                                      Фамилия = x.Element("Surname").Value,
                                      Имя = x.Element("Name").Value,
                                      Отчество = x.Element("Patronymic").Value,
                                      Статус = x.Element("Status").Value,
                                      Стаж = x.Element("Experience").Value
                                  }).ToList();

                    var ACTORSCollection = new ObservableCollection<object>(ACTORS);
                    dg.ItemsSource = ACTORSCollection;

                    MessageBox.Show("Данные отредактированы!");
                    yesno = false;
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavline5.Clear();
                dobavline6.Clear();

            }
            if (counter == 2)
            {
                IEnumerable<XElement> test =
                from el in doc2.Element("Performances").Elements("Performance")
                where (string)el.Element("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc2.Element("Performances").Elements("Performance").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Name", dobavlenie2.Text);
                    doc2.Element("Performances").Elements("Performance").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Year", dobavlenie3.Text);
                    doc2.Element("Performances").Elements("Performance").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).SetElementValue("Budget", dobavlenie4.Text);

                    doc2.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Performances.xml");

                    var PERFORMANCES = (from x in doc2.Element("Performances").Elements("Performance")
                                        orderby x.Element("Kod").Value
                                        select new
                                        {
                                            Код = x.Element("Kod").Value,
                                            Имя = x.Element("Name").Value,
                                            Год = x.Element("Year").Value,
                                            Бюджет = x.Element("Budget").Value
                                        }).ToList();

                    var PERFORMANCESCollection = new ObservableCollection<object>(PERFORMANCES);
                    dg.ItemsSource = PERFORMANCESCollection;

                    MessageBox.Show("Данные отредактированы!");
                    yesno = false;
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();

            }
            if (counter == 3)
            {
                IEnumerable<XElement> test =
                from el in doc3.Element("Employments").Elements("Employment")
                where (string)el.Element("KodA") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc3.Element("Employments").Elements("Employment").First(b => ((string)b.Element("KodA")) == dobavlenie1.Text).SetElementValue("KodP", dobavlenie2.Text);
                    doc3.Element("Employments").Elements("Employment").First(b => ((string)b.Element("KodA")) == dobavlenie1.Text).SetElementValue("Role", dobavlenie3.Text);
                    doc3.Element("Employments").Elements("Employment").First(b => ((string)b.Element("KodA")) == dobavlenie1.Text).SetElementValue("Price", dobavlenie4.Text);

                    doc3.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Employment.xml");

                    var EMPLOYMENT = (from x in doc3.Element("Employments").Elements("Employment")
                                      orderby x.Element("KodA").Value
                                      select new
                                      {
                                          Код_актера = x.Element("KodA").Value,
                                          Код_спектакля = x.Element("KodP").Value,
                                          Роль = x.Element("Role").Value,
                                          Цена = x.Element("Price").Value
                                      }).ToList();

                    var EMPLOYMENTCollection = new ObservableCollection<object>(EMPLOYMENT);
                    dg.ItemsSource = EMPLOYMENTCollection;

                    MessageBox.Show("Данные отредактированы!");
                    yesno = false;
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();

            }
        }
        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                IEnumerable<XElement> test =
                from el in doc1.Element("Actors").Elements("Actor")
                where (string)el.Element("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc1.Element("Actors").Elements("Actor").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).Remove();

                    doc1.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Actors.xml");

                    var ACTORS = (from x in doc1.Element("Actors").Elements("Actor")
                                  orderby x.Element("Kod").Value
                                  select new
                                  {
                                      Код = x.Element("Kod").Value,
                                      Фамилия = x.Element("Surname").Value,
                                      Имя = x.Element("Name").Value,
                                      Отчество = x.Element("Patronymic").Value,
                                      Статус = x.Element("Status").Value,
                                      Стаж = x.Element("Experience").Value
                                  }).ToList();

                    var ACTORSCollection = new ObservableCollection<object>(ACTORS);
                    dg.ItemsSource = ACTORSCollection;

                    MessageBox.Show("Данные удалены!");
                    yesno = false;
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavline5.Clear();
                dobavline6.Clear();

            }
            if (counter == 2)
            {
                IEnumerable<XElement> test =
                from el in doc2.Element("Performances").Elements("Performance")
                where (string)el.Element("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc2.Element("Performances").Elements("Performance").First(b => ((string)b.Element("Kod")) == dobavlenie1.Text).Remove();

                    doc2.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Performances.xml");

                    var PERFORMANCES = (from x in doc2.Element("Performances").Elements("Performance")
                                        orderby x.Element("Kod").Value
                                        select new
                                        {
                                            Код = x.Element("Kod").Value,
                                            Имя = x.Element("Name").Value,
                                            Год = x.Element("Year").Value,
                                            Бюджет = x.Element("Budget").Value
                                        }).ToList();

                    var PERFORMANCESCollection = new ObservableCollection<object>(PERFORMANCES);
                    dg.ItemsSource = PERFORMANCESCollection;

                    MessageBox.Show("Данные удалены!");
                    yesno = false;
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavline5.Clear();
                dobavline6.Clear();

            }
            if (counter == 3)
            {
                IEnumerable<XElement> test =
                from el in doc3.Element("Employments").Elements("Employment")
                where (string)el.Element("KodA") == dobavlenie1.Text
                select el;
                foreach (XElement el in test)
                    yesno = true;
                if (yesno == true)
                {
                    doc3.Element("Employments").Elements("Employment").First(b => ((string)b.Element("KodA")) == dobavlenie1.Text).Remove();

                    doc3.Save("D:\\учеба\\2 курс\\верстка\\c#\\actors_site\\actors_site\\Employment.xml");

                    var EMPLOYMENT = (from x in doc3.Element("Employments").Elements("Employment")
                                      orderby x.Element("KodA").Value
                                      select new
                                      {
                                          Код_актера = x.Element("KodA").Value,
                                          Код_спектакля = x.Element("KodP").Value,
                                          Роль = x.Element("Role").Value,
                                          Цена = x.Element("Price").Value
                                      }).ToList();

                    var EMPLOYMENTCollection = new ObservableCollection<object>(EMPLOYMENT);
                    dg.ItemsSource = EMPLOYMENTCollection;

                    MessageBox.Show("Данные удалены!");
                    yesno = false;
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavline5.Clear();
                dobavline6.Clear();

            }
        }
        private void buttonPoisk_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                if (dobavlenie1 != null && dobavlenie3.Text == "" && dobavline6.Text == "" ) 
                {
                    var kod = (from x in doc1.Element("Actors").Elements("Actor")
                               where (string)x.Element("Kod") == dobavlenie1.Text
                               select new
                               {
                                   Код = x.Element("Kod").Value,
                                   Фамилия = x.Element("Surname").Value,
                                   Имя = x.Element("Name").Value,
                                   Отчество = x.Element("Patronymic").Value,
                                   Статус = x.Element("Status").Value,
                                   Стаж = x.Element("Experience").Value
                               }).ToList();
                    dg.ItemsSource = kod;
                }
                if (dobavlenie1.Text == "" && dobavline5.Text == "группировать")
                {
                    var type = (from x in doc1.Element("Actors").Elements("Actor")
                                group x by x.Element("Status").Value into g
                                select new
                                {
                                    Статус = g.Key
                                }).ToList();
                    dg.ItemsSource = type;
                }
                if (dobavlenie1.Text == "" && dobavline5 != null && dobavline6.Text == "")
                {
                    var type = (from x in doc1.Element("Actors").Elements("Actor")
                                where (string)x.Element("Status") == dobavline5.Text
                                group x by x.Element("Status").Value into g
                                select new
                                {
                                    Статус = g.Key,
                                    Количество = g.Count()
                                }).ToList();
                    dg.ItemsSource = type;
                }
                if (dobavline6.Text == "Больше 18 лет опыта")
                {
                    var type = (from x in doc1.Element("Actors").Elements("Actor")
                                  let experienceString = (string)x.Element("Experience")
                                  where !string.IsNullOrEmpty(experienceString) && experienceString.Any(char.IsDigit) &&
                                        int.TryParse(new string(experienceString.Where(char.IsDigit).ToArray()), out int experienceValue) &&
                                        experienceValue > 18
                                  select new 
                                  {
                                      Имя = (string)x.Element("Name"),
                                      Фамилия = (string)x.Element("Surname")
                                  }).ToList();
                    dg.ItemsSource = type;
                }
                if (dobavline5.Text == "Народные артисты")
                {
                    var type = (from x in doc1.Element("Actors").Elements("Actor")
                                let status = (string)x.Element("Status")
                                where status == "Народный артист"
                                select new
                                {
                                    Имя = (string)x.Element("Name"),
                                    Фамилия = (string)x.Element("Surname")
                                }).ToList();
                    dg.ItemsSource = type;
                }
            }
            if (counter == 2)
            {
                if (dobavlenie1 != null && dobavlenie3.Text == "" && dobavlenie4.Text == "")
                {
                    var kod = (from x in doc2.Element("Performances").Elements("Performance")
                               where (string)x.Element("Kod") == dobavlenie1.Text
                               select new
                               {
                                   Код = x.Element("Kod").Value,
                                   Имя = x.Element("Name").Value,
                                   Год = x.Element("Year").Value,
                                   Бюджет = x.Element("Budget").Value
                               }).ToList();
                    dg.ItemsSource = kod;
                }
            }
            if (counter == 3)
            {
                if (dobavlenie1 != null && dobavlenie3.Text == "" && dobavlenie4.Text == "")
                {
                    var kod = (from x in doc3.Element("Employments").Elements("Employment")
                               where (string)x.Element("KodA") == dobavlenie1.Text
                               select new
                               {
                                   Код__актера = x.Element("KodA").Value,
                                   Код__спектакля = x.Element("KodP").Value,
                                   Роль = x.Element("Role").Value,
                                   Цена = x.Element("Price").Value
                               }).ToList();
                    dg.ItemsSource = kod;
                }
            }
        }
    }
}
