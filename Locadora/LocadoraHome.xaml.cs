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
using MySql.Data.MySqlClient;


namespace Locadora
{
    /// <summary>
    /// Interação lógica para LocadoraHome.xam
    /// </summary>
    public partial class LocadoraHome : Page
    {
        public LocadoraHome()
        {
            InitializeComponent();
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("" +
                "server=localhost;" +
                "User Id=root;" +
                "database=locadora;" +
                "password=''");
            MySqlCommand comando = new MySqlCommand("SELECT * FROM USUARIO", conexao);
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                gdvDados.DataSource = comando.ExecuteReader();
                gdvDados.DataBind();
            }
            finally
            {
                conexao.Close();
            }


            LocadoraCliente cliente = new LocadoraCliente();
            this.NavigationService.Navigate(cliente);

        }
    }
}
