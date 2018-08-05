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


namespace Locadora
{
   
    public partial class LocadoraHome : Page
    {
        public LocadoraHome()
        {
            InitializeComponent();
        }

  
        private void btnEntrar(object sender, RoutedEventArgs e)
        {
            
            LocadoraInicial inicial = new LocadoraInicial();
            try
            {
                using (locadoraEntities contexto = new locadoraEntities())
                {
                    foreach (var user in contexto.Usuario)
                    {
                        if(user.nickname == login.Text && user.senha == senha.Password.ToString())
                        {
                            incorretos.Visibility = Visibility.Hidden;
                            this.NavigationService.Navigate(inicial);
                        }
                    }
                    incorretos.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
        }
    }
}
