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
    /// <summary>
    /// Interação lógica para Detalhe.xam
    /// </summary>
    public partial class Detalhe : Page
    {
        public Detalhe(string id)
        {
            InitializeComponent();
            this.getMovie(id);
        }

        private void getMovie(string id)
        {
            try
            {
                Filme result = null;
                using (locadoraEntities contexto = new locadoraEntities())
                {
                    Filme f = contexto.Filme.Find(Convert.ToInt32(id));
                    labelMovie.Content = f.titulo;
                    labelMovie.HorizontalAlignment = HorizontalAlignment.Center;
                    sinopse.Text = f.sinopse;
                }
            }
            catch
            {

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
