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
using System.Windows.Shapes;

namespace SAE_201_BEAUNE
{
    /// <summary>
    /// Logique d'interaction pour AjouterUnAmi.xaml
    /// </summary>
    public partial class AjouterUnAmi : Window
    {
        public AjouterUnAmi()
        {
            InitializeComponent();
        }

        private void butAjoutAmi_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in stackAjoutAmi.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (Validation.GetHasError(uie))
                    ok = false;
            }
            Envoi_SMS newsms = new Envoi_SMS(sms.Num_ami,sms.Num_inscription,sms.Portable_sms);
            ApplicationData.LesEnvois_SMS.Add(newsms);
            ApplicationData.CreateEnvoisSms(newsms);
            this.Close();
        }
    }
}
