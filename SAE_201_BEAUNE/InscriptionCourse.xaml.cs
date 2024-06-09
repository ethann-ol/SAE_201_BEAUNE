using Microsoft.VisualBasic;
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
    /// Logique d'interaction pour InscriptionCourse.xaml
    /// </summary>
    public partial class InscriptionCourse : Window
    {
        public InscriptionCourse()
        {
            InitializeComponent();
        }

        private void butInscription_Click(object sender, RoutedEventArgs e)
        {

            bool ok = true;
            foreach (UIElement uie in stackInscri.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (Validation.GetHasError(uie))
                    ok = false;
            }

            //Console.WriteLine(inscri.Num_Course);
            InsccriptionTotale course_totale = new InsccriptionTotale(inscri.Num_course,inscri.Num_coureur,TimeSpan.Parse(inscri.Temps_prevu.ToString()));
            //Inscription2 course2 = new Inscription2(course.Num_inscription, inscri.NumCoureur, TimeSpan.Parse(inscri.TempsPrevu.ToString()));
            ApplicationData.LesInscrits.Add(course_totale);
            ApplicationData.CreateInscription(course_totale);
            this.Close();
        }
    }
}
