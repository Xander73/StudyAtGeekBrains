using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson5
{
    class Person
    {
        private string fio = default;
        public string Fio { get => fio; set => fio = value; }

        private string position = default;
        public string Position { get => position; set => position = value; }

        private string email = default;
        public string Email { get => email; set => email = value; }

        private string phoneNumber = default;
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        private int payment = default;
        public int Payment { get => payment; 
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Ошибка!\nЗарплата должна быть больше 0.");
                }
                else payment = value;
            } 
        }

        private int age = default;
        public int Age { get => age;
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Ошибка!\nВозраст должен быть больше 18 лет.");
                }
                else
                {
                    age = value;
                }
            }
        }


        public Person(string fio, string position, string email, string phoneNumber, int payment, int age)
        {
            Fio = fio;
            Position = position;
            Email = email;
            PhoneNumber = phoneNumber;
            Payment = payment;
            Age = age;                        
        }


        public void Info ()
        {
            Console.WriteLine("ФИО\t\t" + "Должность\t" + "Электронная почта\t" + "Теелфон\t\t" + "Зарплата\t" + "Возраст");
            Console.WriteLine(Fio + '\t' + Position + '\t' + Email + "\t\t" + PhoneNumber + "\t" + Payment + "\t\t" + Age + '\n');
        }

    }
}
