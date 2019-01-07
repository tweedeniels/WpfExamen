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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MyCon = "server=localhost;user id=root;persistsecurityinfo=True;database=voorraad;SslMode=none";
        string Query = "";

        public MainWindow()
        {
            InitializeComponent();
            Select();
        }
        public void Select()
        {
            try
            {
                Query = "SELECT * FROM producten";
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dGrid.ItemsSource = dTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Insert()
        {
            try
            {
                //Assemble query values
                string QueryValue = "'" + tbNaam.Text + "'," + "'" + tbAantal.Text + "'," + "'" + tbStreef.Text + "'," + "'" + tbMaximum.Text + "'," + "'" + tbGroep.Text + "'," + "'" + tbOmschrijving.Text + "'";
                //Assign values to query
                Query = "INSERT INTO producten (productnaam, productaantal, streefniveau, maximumaantal, productgroep, productomschrijving) VALUES (" + QueryValue + ");";
                //Make connection
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                //Make command
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                //Make data reader
                MySqlDataReader MyReader2;
                //Open connection
                MyCon2.Open();
                //Execute command into reader
                MyReader2 = MyCommand2.ExecuteReader();
                //Wait for command finish
                while(MyReader2.Read())
                {
                }
                //Close connection
                MyCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Select();
        }
        public void Update(string val)
        {
            try
            {
                Query = val;
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataReader MyReader2;
                MyCon2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Select();
        }
        public void Delete()
        {
            try
            {
                Query = "DELETE FROM producten WHERE productcode=" + tbProductCode.Text;
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataReader MyReader2;
                MyCon2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Select();
        }

        private void bProdToevoegen_Click(object sender, RoutedEventArgs e) => Insert();

        private void bProdVerwijderen_Click(object sender, RoutedEventArgs e) => Delete();
        
        //Update query constructor
        public void UpdateQuery()
        {
            string uNaam = "", uAantal = "", uStreef = "", uMaximum = "", uGroep = "", uOmschrijving = "";

            if (tbNaamU.Text != "")
            {
                uNaam = "productnaam=" + "'" + tbNaamU.Text + "',";
            }
            if (tbAantalU.Text != "")
            {
                uAantal = "productaantal=" + "'" + tbAantalU.Text + "',";
            }
            if (tbStreefU.Text != "")
            {
                uStreef = "streefniveau=" + "'" + tbStreefU.Text + "',";
            }
            if (tbMaximumU.Text != "")
            {
                uMaximum = "maximumaantal=" + "'" + tbMaximumU.Text + "',";
            }
            if (tbGroepU.Text != "")
            {
                uGroep = "productgroep=" + "'" + tbGroepU.Text + "',";
            }
            if (tbOmschrijvingU.Text != "")
            {
                uOmschrijving = "productomschrijving=" + "'" + tbOmschrijvingU.Text + "',";
            }

            string val1 = $"UPDATE producten SET {uNaam}{uAantal}{uStreef}{uMaximum}{uGroep}{uOmschrijving}";
            string val2 = val1.Substring(0, val1.Length-1) + $"WHERE productcode ={tbProductCodeU.Text};";

            Update(val2);
        }

        private void bProdAanpassen_Click(object sender, RoutedEventArgs e) => UpdateQuery();

        private void btnGroepToevoegen_Click(object sender, RoutedEventArgs e) => GroepToevoegen();

        public void GroepToevoegen()
        {
            try
            {
                //Assign values to query
                Query = $"INSERT INTO productgroepen (groepnaam, groepomschrijving) VALUES ('{tbGroepToevoegenNaam.Text}', '{tbGroepToevoegenOmschrijving.Text}');";
                //Make connection
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                //Make command
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                //Make data reader
                MySqlDataReader MyReader2;
                //Open connection
                MyCon2.Open();
                //Execute command into reader
                MyReader2 = MyCommand2.ExecuteReader();
                //Wait for command finish
                while (MyReader2.Read())
                {
                }
                //Close connection
                MyCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SelectGroep();
        }
        public void SelectGroep()
        {
            try
            {
                Query = "SELECT * FROM productgroepen";
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dGrid.ItemsSource = dTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SelectGroepNaam()
        {
            try
            {
                Query = "SELECT groepnaam FROM productgroepen";
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                MySqlDataReader MyReader2;
                MyCon2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    cbProductGroepenVerwijderen.Items.Add(MyReader2.GetString("groepnaam"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbProductGroepen_Loaded(object sender, RoutedEventArgs e) => SelectGroepNaam();

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tcTabs.SelectedIndex == 4)
            {
                SelectGroep();
            }
            else
            {
                Select();
            }
        }
        public void DeleteGroep()
        {
            try
            {
                Query = $"DELETE FROM productgroepen WHERE groepnaam='{ cbProductGroepenVerwijderen.SelectedValue}';";
                MySqlConnection MyCon2 = new MySqlConnection(MyCon);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyCon2);
                MySqlDataReader MyReader2;
                MyCon2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SelectGroep();
        }
        private void btnGroepVerwijderen_Click(object sender, RoutedEventArgs e) => DeleteGroep();
    }
}
