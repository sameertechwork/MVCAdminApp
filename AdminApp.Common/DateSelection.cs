using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Common
{
    public static class DateSelection
    {
        public static string BuildDate(int PlanDay, int PlanMonth, int PlanYear)
        {
            DateTime dt;
            string FormDate = "";
            try
            {
                dt = new DateTime(PlanYear, PlanMonth, PlanDay);
            }
            catch (Exception excp)
            {
                if (PlanYear % 4 == 0 && PlanMonth == 2)
                {
                    PlanDay = 28;
                }
                else if (PlanYear % 4 == 1 && PlanMonth == 2)
                {
                    PlanDay = 27;
                }
                else if (PlanMonth == 1 || PlanMonth == 3 || PlanMonth == 5 || PlanMonth == 7 || PlanMonth == 8 || PlanMonth == 10 || PlanMonth == 12)
                {
                    PlanDay = 31;
                }
                else if (PlanMonth == 4 || PlanMonth == 6 || PlanMonth == 9 || PlanMonth == 11)
                {
                    PlanDay = 30;
                }
            }
            finally
            {
                FormDate = PlanDay + "-" + new DateTime(PlanYear, PlanMonth, 1).ToString("MMMM", CultureInfo.InvariantCulture) + "-" + PlanYear;
            }

            return FormDate;
        }

        public static string PreviousMonthDate(int PlanDay, int PlanMonth, int PlanYear)
        {

            DateTime dt;
            string FormDate = "";
            try
            {
                dt = new DateTime(PlanYear, PlanMonth, PlanDay);
            }
            catch (Exception excp)
            {
                if (PlanYear % 4 == 0 && PlanMonth == 2)
                {
                    PlanDay = 28;
                }
                else if (PlanYear % 4 == 1 && PlanMonth == 2)
                {
                    PlanDay = 27;
                }
                else if (PlanMonth == 1 || PlanMonth == 3 || PlanMonth == 5 || PlanMonth == 7 || PlanMonth == 8 || PlanMonth == 10 || PlanMonth == 12)
                {
                    PlanDay = 31;
                }
                else if (PlanMonth == 4 || PlanMonth == 6 || PlanMonth == 9 || PlanMonth == 11)
                {
                    PlanDay = 30;
                }
            }
            finally
            {
                FormDate = PlanDay + "-" + new DateTime(PlanYear, PlanMonth, 1).ToString("MMMM", CultureInfo.InvariantCulture) + "-" + PlanYear;
            }

            return FormDate;
        }
    }
}
