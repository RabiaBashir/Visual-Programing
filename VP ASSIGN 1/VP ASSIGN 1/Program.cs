using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_ASSIGN_1
{
    
        public class Age
        {
            public int Years;
            public int Months;
            public int Days;
            public Age()
            {

            }
            public Age(DateTime Birthday) // constructor 1--- only birthdate
            {
                this.Count(Birthday);
            }

            public Age(DateTime Birthday, DateTime Cdate) // constructor 2-- birthdate , currentdate
            {
                this.Count(Birthday, Cdate);
            }

            public Age Count(DateTime Birthday)
            {
                return this.Count(Birthday, DateTime.Today);
            }

            public Age Count(DateTime Birthday, DateTime Currentday)
            {
                if ((Currentday.Year - Birthday.Year) > 0 ||
                    (((Currentday.Year - Birthday.Year) == 0) && ((Birthday.Month < Currentday.Month) ||
                      ((Birthday.Month == Currentday.Month) && (Birthday.Day <= Currentday.Day)))))
                {
                    int DaysInBirthdayMonth = DateTime.DaysInMonth(Birthday.Year, Birthday.Month); //no of days in birthday month
                    int DaysRemainInBirthDay = Currentday.Day + (DaysInBirthdayMonth - Birthday.Day);    //days remaining in birthday 
                    Console.WriteLine(DaysInBirthdayMonth);
                    Console.WriteLine(DaysRemainInBirthDay);

                    if (Currentday.Month > Birthday.Month)
                    {
                        this.Years = Currentday.Year - Birthday.Year;
                        this.Months = Currentday.Month - (Birthday.Month + 1) + Math.Abs(DaysRemainInBirthDay / DaysInBirthdayMonth);
                        this.Days = (DaysRemainInBirthDay % DaysInBirthdayMonth + DaysInBirthdayMonth) % DaysInBirthdayMonth;
                    }
                    else if (Currentday.Month == Birthday.Month)
                    {
                        if (Currentday.Day >= Birthday.Day)
                        {
                            this.Years = Currentday.Year - Birthday.Year;
                            this.Months = 0;
                            this.Days = Currentday.Day - Birthday.Day;
                        }
                        else
                        {
                            this.Years = (Currentday.Year - 1) - Birthday.Year;
                            this.Months = 11;
                            this.Days = DateTime.DaysInMonth(Birthday.Year, Birthday.Month) - (Birthday.Day - Currentday.Day);
                        }
                    }
                    else
                    {
                        this.Years = (Currentday.Year - 1) - Birthday.Year;
                        this.Months = Currentday.Month + (11 - Birthday.Month) + Math.Abs(DaysRemainInBirthDay / DaysInBirthdayMonth);

                        this.Days = (DaysRemainInBirthDay % DaysInBirthdayMonth + DaysInBirthdayMonth) % DaysInBirthdayMonth;
                    }
                }
                else
                {
                    throw new ArgumentException("Birthday date must be earlier than current date");
                }
                return this;
            }
        }
        class Program
        {
            public static void Main(string[] args)
            {
                Age[] objAge = new Age[10];
                int noSiblings;
                string message;
                Console.Write("Enter number of your siblings : ");  //ENTER SIBILING NO
                noSiblings = int.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------------------------");
                for (int i = 0; i < noSiblings; i++)
                {
                    Console.Write("\nPlease enter date of birth of sibling(MM-DD-YYYY) " + (i + 1) + " : "); //ENTER DateOfBirth
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());
                    objAge[i] = new Age(birthDate, DateTime.Now);
                }

                Console.WriteLine("-----------------------------------------------------------------------");
                /// printing age of siblings
                for (int i = 0; i < noSiblings; i++)
                {
                    message = "Age of Sibling " + (i + 1) + "is " + objAge[i].Years + " years  " + objAge[i].Months + " months " + objAge[i].Days + "Days";
                    Console.WriteLine(message);
                }
                Console.WriteLine("-----------------------------------------------------------------------");

                //difference between siblings
                for (int i = 0; i < noSiblings - 1; i++)
                {
                    if (objAge[i].Days < objAge[i + 1].Days)
                    {
                        objAge[i].Months = objAge[i].Months - 1;
                        objAge[i].Days = objAge[i].Days + 30;
                    }
                    if (objAge[i].Months < objAge[i + 1].Months)
                    {
                        objAge[i].Years = objAge[i].Years - 1;
                        objAge[i].Months = objAge[i].Months + 12;
                    }
                    message = "Difference between sibling " + (i + 1) + " and " + (i + 2) + " is ";
                    message += (objAge[i].Years - objAge[i + 1].Years) + " years  " + (objAge[i].Months - objAge[i + 1].Months) + " months " + (objAge[i].Days - objAge[i + 1].Days) + "Days";
                    Console.WriteLine(message);
                }
                Console.Read();
            }
        }
    }

