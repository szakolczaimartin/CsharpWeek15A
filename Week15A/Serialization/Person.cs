using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Serialization
{
        [Serializable]
        class Person : IDeserializationCallback, ISerializable
        {

            [NonSerialized]
            private int _age;

            public string Name { get; set; }
            public DateTime BirthDate { get; set; }

            public Person()
            {

            }

            public Person(string name, DateTime birthDate)
            {
                this.Name = name;
                this.BirthDate = birthDate;
                CalculateAge();
            }

            public Person(SerializationInfo info, StreamingContext context)
            {
                Name = info.GetString("Name");
                BirthDate = info.GetDateTime("DOB");
            }

            public override string ToString()
            {
                return ($"name: {Name}, birthdate: {BirthDate.ToShortDateString()}, age: {_age}");
            }

            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Name", Name);
                info.AddValue("DOB", BirthDate);
                Name = info.GetString("Name");
                BirthDate = info.GetDateTime("DOB");
            }

            public void OnDeserialization(object sender)
            {
                CalculateAge();
            }

            private void CalculateAge()
            {
                this._age = DateTime.Now.Year - BirthDate.Year;
            }

        }
    }