using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// Fonksiyonlar az satırdan oluşmalıdır.
    /// 
    /// “The first rule of functions is that they should be small.
    /// The second rule of functions is that they should be smaller than that.” — Robert C. Martin
    /// </summary>

    //BAD
    public enum EStudentActivity
    {
        Study,
        Homework,
        Exercise
    }
    public class BadStudent
    {
        public string Name { get; set; }
        public List<EStudentActivity> Activities { get; set; }

        //Her aktiviteyi işleyen kodlar PrintStudentActivities metodunda karmaşık bir şekilde yazılmış.
        public void PrintStudentActivities()
        {
            foreach (var activity in Activities)
            {
                switch (activity)
                {
                    case EStudentActivity.Study:
                        Console.WriteLine($"{Name} is studying.");
                        break;
                    case EStudentActivity.Homework:
                        Console.WriteLine($"{Name} is doing homework.");
                        break;
                    case EStudentActivity.Exercise:
                        Console.WriteLine($"{Name} is exercising.");
                        break;
                    default:
                        Console.WriteLine($"{Name} is not doing anything.");
                        break;
                }
            }
        }
    }

    //GOOD

    //PrintStudentActivities metodunu parçalara ayırarak metodun daha kısa olmasını sağlayalım.
    //(PrintStudyActivity, PrintHomeworkActivity, PrintExerciseActivity, PrintDefaultActivity) ayrılarak kod tekrarı önlendi.
    //Aynı zamanda her bir metodun görevi daha spesifik hale getirilmiş oldu.

    public class GoodStudent
    {
        public string Name { get; set; }
        public List<EStudentActivity> Activities { get; set; }

        public void PrintStudentActivities()
        {
            foreach (var activity in Activities)
            {
                PrintActivity(activity);
            }
        }
        private void PrintActivity(EStudentActivity activity)
        {
            switch (activity)
            {
                case EStudentActivity.Study:
                    PrintStudyActivity();
                    break;
                case EStudentActivity.Homework:
                    PrintHomeworkActivity();
                    break;
                case EStudentActivity.Exercise:
                    PrintExerciseActivity();
                    break;
                default:
                    PrintDefaultActivity();
                    break;
            }
        }

        private void PrintStudyActivity()
        {
            Console.WriteLine($"{Name} is studying.");
        }

        private void PrintHomeworkActivity()
        {
            Console.WriteLine($"{Name} is doing homework.");
        }

        private void PrintExerciseActivity()
        {
            Console.WriteLine($"{Name} is exercising.");
        }

        private void PrintDefaultActivity()
        {
            Console.WriteLine($"{Name} is not doing anything.");
        }
    }
}
