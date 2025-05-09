using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace DartsAssistant.Models
{
    public interface IPlayer
    {
        public int Score { get; set;}
        public List<int> Throws { get; set;}
        public double Average { get; set;}
        public double First9Average{ get; set;}
        public void Throw(int points);
        public void RegisterThrow(int points);
    }
}
