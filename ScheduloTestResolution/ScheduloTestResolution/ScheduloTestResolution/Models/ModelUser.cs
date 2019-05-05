using System;
using System.Runtime.CompilerServices;
namespace ScheduloTestResolution.Models
{
    public class ModelUser
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ModelUser(string name, int id)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
