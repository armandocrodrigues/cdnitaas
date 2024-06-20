using CandidateTesting.ArmandoRodrigues.Converters;
using CandidateTesting.ArmandoRodrigues.Helper;
using CandidateTesting.ArmandoRodrigues.interfaces;
using CandidateTesting.ArmandoRodrigues.Specialistcs;

namespace CandidateTesting.ArmandoRodrigues
{

    public class Solution
    {
        public IFormatConverter ConverterSpecialist { get; set; }
        protected IFinalFormat FinalFormatSpecialist { get; set; }

        public string Start(string url, string path, string typeFrom, string typeTo)
        {
            FileManager fm = new FileManager(url, path);
            
            if (Validator.StartIsValid(url, path, typeFrom, typeTo))
            {
                fm.GetFileFromWeb();

                if (typeTo == Constants.FinalFormatNames.Agora || string.IsNullOrEmpty(typeTo))
                    FinalFormatSpecialist = new AgoraFormatSpecialist();

                if (typeFrom == Constants.ConverterProvidersNames.MinhaCDN || string.IsNullOrEmpty(typeFrom))
                    ConverterSpecialist = new MinhaCDNConverter(FinalFormatSpecialist);

                Converter convert = new Converter(ConverterSpecialist);
                string converted = convert.Execute(fm.GetFileLines());

                fm.Dispose();
                fm.WriteFile(converted);

                return "Conversion completed";
            }
            else
                return "Something is wrong\nCheck out the parameters"; ;

        }
    }
}
