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
using Correios.Net;

namespace Locadora
{
    /// <summary>
    /// Interação lógica para LocadoraCliente.xam
    /// </summary>
    public partial class LocadoraCliente : Page
    {
     
        public LocadoraCliente()
        {
            InitializeComponent();
        }


        private void cep_Leave(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            
            cliente.nome = nome.Text;
            
            cliente.email = email.Text;
            cliente.celular = telefone.Text;
            cliente.dt_inclusao = DateTime.Today;
            cliente.status = "A";

            //gravar no banco de dados
            using (locadoraEntidade contexto = new locadoraEntidade())
            {
                contexto.Cliente.Add(cliente);
                contexto.SaveChanges();
            }
        }

        private void LocalizarCEP()
        {
            if (!string.IsNullOrWhiteSpace(cep.Text))
            {
                Address endereco = SearchZip.GetAddress(cep.Text);
                if (endereco.Zip != null)
                {
                    uf.Text = endereco.State;
                    cidade.Text = endereco.City;
                    logradouro.Text = endereco.Street;
                }
                else
                {
                    MessageBox.Show("Cep não localizado...");
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }
    }
}
