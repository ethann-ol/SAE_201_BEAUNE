﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SAE_201_BEAUNE
{
    internal class SexeCoureurToBool : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool rep = value.Equals(parameter);
            return rep;
        }

        /* Convertit la value de la cible dans le type de la source. (Ici,GenrePersonne 
) si IsChecked du radiobouton est true, on renvoie le paramètre pour mettre à jour 
la propriété sinon on stoppe l'action de Binding */
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : Binding.DoNothing;
        }
    }
}
