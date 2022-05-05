using System.Reflection;

namespace Restaurant.Models
{

    public class DaysOfTheWeek
    {
        public List<Opening>? Monday { get; set; }
        public List<Opening>? Tuesday { get; set; }
        public List<Opening>? Wednesday { get; set; }
        public List<Opening>? Thursday { get; set; }
        public List<Opening>? Friday { get; set; }
        public List<Opening>? Saturday { get; set; }
        public List<Opening>? Sunday { get; set; }

        public List<Schedule> GetReadableFormat(DaysOfTheWeek model)
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (PropertyInfo property in model.GetType().GetProperties())
            {
              var arr = new int[]{2, 3, 4, 5, 1};
              InversePermutation(arr,arr.Length);
                var thisSchedule = new Schedule() { Day = property.Name };
                if (property.PropertyType == typeof(List<Opening>))
                {
                    List<Opening> value = (List<Opening>)property.GetValue(model);
                    if (value.Count <= 0)
                    {
                        thisSchedule.ClosedAllDay = true;
                        schedules.Add(thisSchedule);
                        continue;
                    }

                    foreach (Opening opening in value)
                    {
                        var formatedTimeString = UnixTimeStampToDateTime(opening.Value);
                        if (thisSchedule.Openings == null)
                            thisSchedule.Openings = new List<FormatedOpening>();

                        //deceare a boolean variable to stare if the previous day opening closed 
                        //check if day has open without close,
                        //if not the look in the next item in the array for a closing for that day and update the lat item in the schedule arrray with the closing dat.

                        if (opening.Type == OpeningType.open.ToString())
                        {
                            thisSchedule.Openings.Add(new FormatedOpening() { Type = opening.Type, Time = formatedTimeString });
                        }
                        else if (opening.Type == OpeningType.close.ToString())
                        {
                            thisSchedule.Openings.Add(new FormatedOpening() { Type = opening.Type, Time = formatedTimeString });
                        }
                    }
                    schedules.Add(thisSchedule);
                }
            }
            return schedules;
        }


        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime.ToString("hh:mm tt");
        }

        private int[] InversePermutation(int[] permutation,int size)
        {

            int[] inverse = new int[size];
            for (int i = 0; i < size; i++)
            {
                inverse[permutation[i] - 1] = i + 1;
            }
            return inverse;
        }
        //nested loop solution
        //loop over the parameter
        //create another array to store results
        // doa loop over the array and check if the value is in the array and put the index of the upper array in the neww array at the value's position
        //2 at index 1
    }
}