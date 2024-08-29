//using WebApiShop.DLL.Entites;

//namespace WebApiShop.Extension
//{
//    public class CalculateAgeExtension
//    {
//        public static (int Years, int Months, int Days) CalculateAge(this Student student)
//        {
//            if (student.DateOfBirth == null)
//            {
//                throw new ArgumentNullException(nameof(student.DateOfBirth), "Date of birth is required.");
//            }

//            var today = DateTime.Today;
//            var ageYears = today.Year - student.DateOfBirth.Year;
//            var ageMonths = today.Month - student.DateOfBirth.Month;
//            var ageDays = today.Day - student.DateOfBirth.Day;

//            if (ageDays < 0)
//            {
//                ageDays += DateTime.DaysInMonth(today.Year, today.AddMonths(-1).Month);
//                ageMonths--;
//            }

//            if (ageMonths < 0)
//            {
//                ageMonths += 12;
//                ageYears--;
//            }

//            return (ageYears, ageMonths, ageDays);
//        }
//    }
//}
