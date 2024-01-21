using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public int BodyMassIndex { get; set; }
        public int BMI { get; set; }
        public string? Image { get; set; }
        public List<DiseaseHistory>? DiseaseHistory { get; set; }
        public List<DrugHistory>? DrugHistory { get; set; }
        public List<SurgeryHistory>? SurgeryHistory { get; set; }
        public List<PreOp>? PreOps { get; set; }
        public List<PostOp>? PostOps { get; set; }
        public List<PeriodicVisitHistory>? PeriodicVisitHistory { get; set; }
        public List<IrregularVisitHistory>? IrregularVisitHistory { get; set; }

        public Patient() { }

        public Patient(string name, string surname, string phone, string mail, string address, int age, int size, int weight, int bodyMassIndex, int bmi, string? image, Guid? organizationId)
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
            BMI = bmi;
            Image = image;
            OrganizationId = organizationId;
        }
    }
}
