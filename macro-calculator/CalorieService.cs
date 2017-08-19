
using Macro.Models;

namespace Macro.Services
{
    public class CalorieService
    {
        public int CalcuateRestingEnergyExpenditure(Person person)
        {
            double weightKg = convertPoundsToKilograms(person.WeightPounds);
            double heightCm = convertFeetToCentimeters(person.HeightFeet) + convertInchesToCentimeters(person.HeightInches);

            double calories = 10 * weightKg + 6.25 * heightCm - 5 * person.Age;

            if (person.Gender == Gender.Male)
                return (int)calories + 5;
            
            return (int)calories - 161;
        }

        private double convertFeetToCentimeters(int feet)
        {
            return feet * 30.48;
        }

        private double convertInchesToCentimeters(int inches)
        {
            return inches * 2.54;
        }

        private double convertPoundsToKilograms(double pounds)
        {
            return pounds * 0.453592;
        }
    }
}
