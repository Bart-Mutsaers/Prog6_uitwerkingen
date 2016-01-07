using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LeagueManager.WPF.ViewModel
{
    class ChampToMapImg : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (String.IsNullOrEmpty((string)value))
            {
                return "Resources/unknown.jpg";
            }
            else
            {
                return String.Format("http://ddragon.leagueoflegends.com/cdn/5.23.1/img/champion/{0}.png", (string)value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
