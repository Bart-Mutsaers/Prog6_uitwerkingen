using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LeagueManager.WPF.ViewModel
{
    class ChampToLoadingImg : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (String.IsNullOrEmpty((string)value))
            {
                return "Resources/defaultLoading.png";
            }
            else
            {
                return String.Format("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{0}_0.jpg", (string)value);
            }
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
