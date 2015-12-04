using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard
{
    public class Tovenaar
    {
        private Kookpot _kookpot { get; set; }

        private IToverstaf _staf { get; set; }


        public Tovenaar(IToverstaf pStaf)
        {
            this._kookpot = new Kookpot("zwart");
            this._staf = pStaf;

        }

    
        public String Toverspreuk(List<String> ing, List<String> words)
        {
            if (ing == null || ing.Count == 0)
            {
                throw new GeenIngredientenException();
            }
            else
            {

                if (words.Count == 3)
                {
                    //Fora mis Forameur
                    if(words[0] == "Fora" && words[1] == "mis" && words[2] == "Forameur"){
                        if(ing.Count == 3 && ing.Contains("spinneweb") && ing.Contains("oorlel") && ing.Contains("slangegif"))
                        {
                            return "doe open die poort";
                        }
                        else{throw new VerkeerdeIngredientenException();}
                    }  //Ban Da Ladik
                    else if (words[0] == "Ban" && words[1] == "da" && words[2] == "ladik"){
                        if (ing.Contains("Kikkerbil") && ing.Contains("oorlel") &&ing.Contains("rattenstaart") && ing.Contains("slangegif")){
                            _staf.Omhoog();
                            _staf.Omlaag();
                            return "best friends for life";
                        }
                        else { throw new VerkeerdeIngredientenException(); }
                    }
                    else if (words[0] == "Flim" && words[1] == "Flam" && words[2] == "Fluister")
                    {
                        if (ing.Contains("Kikkerbil") && ing.Contains("oorlel") && ing.Contains("rattenstaart") && ing.Contains("krokodillenoog"))
                        {
                            _staf.Links();
                            _staf.Rechts();
                            return "Er was licht, en hij zag dat het goed was!";
                        }
                        else { throw new VerkeerdeIngredientenException(); }
                    }
                    else if (words[0] == "Arma" && words[1] == "kro" && words[2] == "dilt")
                    {
                        if (ing.Contains("Kikkerbil") && ing.Contains("spinneweb") && ing.Contains("oorlel") &&
                            ing.Contains("rattenstaart") && ing.Contains("slangegif") && ing.Contains("mensenhaar") && ing.Contains("krokodillenoog"))
                        {
                            if (_kookpot.Kleur == "zilver")
                            {
                                return "upgrades";
                            }
                            else
                            {
                                //Als het geen zilvere ketel is ontploft het!
                                return "BOOM!";
                            }
                        }
                        else { throw new VerkeerdeIngredientenException(); }
                    }
                    else { 
                        throw new VerkeerdeWoordenException(); 
                    }
                }
                else if (words.Count == 4)
                {
                    //Bal Sam Sala Bond
                    if (words[0] == "Bal" && words[1] == "sam" && words[2] == "sala" && words[3] == "bond")
                    {
                        if (ing.Contains("Kikkerbil") && ing.Contains("spinneweb") && ing.Contains("mensenhaar") && ing.Contains("krokodillenoog"))
                        {
                            _staf.Links();
                            _staf.Omhoog();
                            _staf.Rechts();
                            _staf.Omlaag();
                            return "Je bent genezen met " + _staf.HoeveelheidEnergie + " energiepunten";
                        }
                        else { throw new VerkeerdeIngredientenException(); }
                    }
                    else { throw new VerkeerdeWoordenException(); }
                }

                throw new GeenToverspreukException("Er is geen toverspreuk met " + words.Count + " woorden");
            }
        }
    }
}
