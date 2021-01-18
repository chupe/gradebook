using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                {
                    throw new ArgumentException("Invalid value for book.Name");
                }
            }
        }

    }
}