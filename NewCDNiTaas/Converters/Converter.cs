using CandidateTesting.ArmandoRodrigues.interfaces;

namespace CandidateTesting.ArmandoRodrigues.Converters
{
    public class Converter
    {
        IFormatConverter converterSpecialist { get; set; }
        public Converter(IFormatConverter specialist)
        {
            converterSpecialist = specialist;
        }
        public string Execute(string[] lines)
        {
            return converterSpecialist.HeaderBuilder() + converterSpecialist.Converter(lines) + converterSpecialist.FooterBuilder();
        }
    }
}
