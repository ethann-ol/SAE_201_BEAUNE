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

            Inscription course = new Inscription(inscri.Num_course,DateTime.Today);
            ApplicationData.LesInscriptions.Add(course);
            Inscription2 course2 = new Inscription2(course.Num_inscription, inscri.NumCoureur, TimeSpan.Parse(inscri.TempsPrevu.ToString()));
            ApplicationData.LesInscriptions2.Add(course2);
            ApplicationData.CreateInscription(course, course2);
        }
    }
}
