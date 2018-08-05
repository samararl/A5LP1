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
    /// Interação lógica para LocadoraFilme.xam
    /// </summary>
    public partial class LocadoraFilme : Page
    {
        public LocadoraFilme()
        {
            InitializeComponent();
        }
        
        public LocadoraFilme(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }

        public void btnSalvar(object sender, RoutedEventArgs e)
        {
            Filme filme = new Filme();
            LocadoraInicial inicio = new LocadoraInicial();

            filme.titulo = nome.Text;
            filme.nota = Convert.ToInt32(nota.Text);
            filme.duracao = duracao.Text;
            filme.dt_lancamento = DateTime.Today;
            filme.dt_inclusao = DateTime.Today;
            filme.sinopse = sinopse.Text;
            filme.sub_titulo = subtitulo.Text;
            filme.valor = 10;
            
            try
            {
                //gravar no banco de dados
                using (locadoraEntities contexto = new locadoraEntities())
                {
                    contexto.Filme.Add(filme);
                    contexto.SaveChanges();
                    this.NavigationService.Navigate(inicio);
                }

            }
            catch (Exception)
            {


            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
