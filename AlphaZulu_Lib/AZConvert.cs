using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaZulu_Lib
{
    public class AZConvert
    {
        public Vars _vars = new Vars();
        public AZConvert(Vars vars)
        {
            _vars = vars;
        }

        public string ConvertLetter(char letter)
        {
            var azMapping = new Dictionary<char, string>
            {
                { 'A', "Alpha" },
                { 'B', "Bravo" },
                { 'C', "Charlie" },
                { 'D', "Delta" },
                { 'E', "Echo" },
                { 'F', "Foxtrot" },
                { 'G', "Golf" },
                { 'H', "Hotel" },
                { 'I', "India" },
                { 'J', "Juliett" },
                { 'K', "Kilo" },
                { 'L', "Lima" },
                { 'M', "Mike" },
                { 'N', "November" },
                { 'O', "Oscar" },
                { 'P', "Papa" },
                { 'Q', "Quebec" },
                { 'R', "Romeo" },
                { 'S', "Sierra" },
                { 'T', "Tango" },
                { 'U', "Uniform" },
                { 'V', "Victor" },
                { 'W', "Whiskey" },
                { 'X', "Xray" },
                { 'Y', "Yankee" },
                { 'Z', "Zulu" },
                { '1', "One" },
                { '2', "Two" },
                { '3', "Three" },
                { '4', "Four" },
                { '5', "Five" },
                { '6', "Six" },
                { '7', "Seven" },
                { '8', "Eight" },
                { '9', "Nine" },
                { '0', "Zero" },
                { '.', "Dot" },
                { ' ', "[SPACE]" }
            };

            return azMapping[letter];
        }

        public void WriteOutput(string input)
        {
            _vars.Output = "";
            input = input.ToUpper();
            for (int index = 0; index < input.Count(); index++)
            {
                char c = input[index];
                try
                {
                    string s = ConvertLetter(c);
                    _vars.Output += (index == input.Count() - 1) ? s : s + "-";
                }
                catch (Exception e)
                {
                    _vars.Output += c + "-";
                }
            }
        }
    }

    public class Vars : INotifyPropertyChanged
    {
        private string _Output;
        public string Output
        {
            get { return _Output; }
            set { if (_Output != value) { _Output = value; OnPropertyChanged("Output"); } }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
