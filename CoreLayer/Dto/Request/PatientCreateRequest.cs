using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class PatientCreateRequest
    {
        public PatientCreateRequest() { }

        public PatientCreateRequest(string name, string surname, string phone, string mail, string address, int age, int size, int weight, int bodyMassIndex, int bMI, string? image)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Address = address;
            Age = age;
            Size = size;
            Weight = weight;
            BodyMassIndex = bodyMassIndex;
            BMI = bMI;
            Image = image;
        }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public required string Address { get; set; }
        public required int Age { get; set; }
        public required int Size { get; set; }
        public required int Weight { get; set; }
        public required int BodyMassIndex { get; set; }
        public required int BMI { get; set; }
        public string? Image { get; set; }
    }
}
