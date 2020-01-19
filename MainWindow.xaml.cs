using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;

namespace XmlAssign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            update();


        }

        private void addbtn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                XDocument xDocument = XDocument.Load(@"..\..\Data\items.xml");
                XElement root = xDocument.Element("root");
                IEnumerable<XElement> rows = root.Descendants("item");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                    new XElement("item",
                        new XElement("title", txtbox2.Text),
                        new XElement("category", txtbox1.Text),
                        new XElement("price", txtbox3.Text)
                        ));
                xDocument.Save(@"..\..\Data\items.xml");

                MessageBox.Show(txtbox2.Text+ " Added");
                clear();
                update();


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void clear() {
            txtbox1.Text="";
            txtbox2.Text = "";
        }
        public void update() {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\Data\items.xml");
            dataGid1.ItemsSource = dataSet.Tables[0].DefaultView;
        }
        private void deletebtn_click(object sender, RoutedEventArgs e)
        {
            string title = txtbox2.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Data\items.xml");
            XmlNodeList nodeList = doc.GetElementsByTagName("title");
            XmlNode node = nodeList[0];
            XmlNode parentNode = node.ParentNode;
            parentNode.ParentNode.RemoveChild(parentNode);
            doc.Save(@"..\..\Data\items.xml");
            MessageBox.Show(title+ " Removed!");
            update();
        }

        private void updatebtn_clicked(object sender, RoutedEventArgs e)
        {
            string title = txtbox2.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Data\items.xml");
            XmlNodeList nodeList = doc.GetElementsByTagName("title");
            XmlNode node = nodeList[0];
            XmlNode parentNode = node.ParentNode;
            parentNode.SelectSingleNode("//title").InnerText = txtbox2.Text;
            parentNode.SelectSingleNode("//category").InnerText = txtbox1.Text;
            parentNode.SelectSingleNode("//price").InnerText = txtbox3.Text;

            doc.Save(@"..\..\Data\items.xml");
            MessageBox.Show(title + " updated!");
            update();

        }
    }
}
