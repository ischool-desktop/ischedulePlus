using System;
using System.ComponentModel;
using ischedulePlus;

namespace ischedulePlus
{
    internal class CalendarBindingList : SortableBindingList<CalendarRecord>
    {
        protected override Comparison<CalendarRecord> GetComparer(PropertyDescriptor prop)
        {
            Comparison<CalendarRecord> comparer = null;

            switch (prop.Name)
            {
                case "Status":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return ((""+x.Status).CompareTo((""+y.Status)));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "Date":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.StartDateTime.CompareTo(y.StartDateTime));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "DisplayWeekday":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.Weekday.CompareTo(y.Weekday));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "Period":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.Period.CompareTo(y.Period));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "Subject":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.Subject.CompareTo(y.Subject));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "TeacherName":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.TeacherName.CompareTo(y.TeacherName));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "ClassName":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.ClassName.CompareTo(y.ClassName));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "ClassroomName":
                    comparer = new Comparison<CalendarRecord>(delegate(CalendarRecord x, CalendarRecord y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.ClassroomName.CompareTo(y.ClassroomName));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
            }

            return comparer;
        }
    }
}