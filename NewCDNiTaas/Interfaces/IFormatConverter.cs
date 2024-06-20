using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.ArmandoRodrigues.interfaces
{
    public interface IFormatConverter
    {
        string HeaderBuilder();
        string FooterBuilder();
        string Converter(string[] originalFileLines);
    }
}
