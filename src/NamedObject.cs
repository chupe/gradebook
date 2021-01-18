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

        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Name = value;
                else
                {
                    throw new ArgumentException("Invalid value for book.Name");
                }
            }
        }

    }
}