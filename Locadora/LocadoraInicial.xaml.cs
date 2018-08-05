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
    /// Interação lógica para LocadoraInicial.xam
    /// </summary>
    public partial class LocadoraInicial : Page
    {
        public LocadoraInicial()
        {
            InitializeComponent();
        }

        private void goToNewClient(object sender, RoutedEventArgs e)
        {
            LocadoraCliente cliente = new LocadoraCliente();
            this.NavigationService.Navigate(cliente);

        }

        private void goToNewFilm(object sender, RoutedEventArgs e)
        {
            LocadoraFilme filme = new LocadoraFilme();
            this.NavigationService.Navigate(filme);

        }

        private void goToLocacoes(object sender, RoutedEventArgs e)
        {
            
        }

        private void goToDetalhe(object sender, RoutedEventArgs e)
        {
            var Id = ((Button)sender).Tag;
            Detalhe detalhe = new Detalhe(Id.ToString());
            this.NavigationService.Navigate(detalhe);
        }
     
        private void buscaFilme(object sender, KeyEventArgs e)
        {
            try
            {
                Filme result = null;
                using (locadoraEntities contexto = new locadoraEntities())
                {
                    List<Filme> filmes = new List<Filme>();

                    var query = from filme in contexto.Filme
                                where filme.titulo.Contains(busca.Text)
                                select filme;
                    filmes.AddRange(query.ToList<Filme>());
                    stackPanel.Children.Clear();

                    foreach (var item in filmes)
                    {
                        Button btn = new Button();                        
                        btn.Content = item.titulo;
                        btn.Click += new RoutedEventHandler(goToDetalhe);
                        btn.Margin = new Thickness(0, 10, 0, 10);
                        btn.Tag = item.id;
                        stackPanel.Children.Add(btn);
                    }
                }
            }
            catch
            {

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    
  
    }
}
