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
    }
}
