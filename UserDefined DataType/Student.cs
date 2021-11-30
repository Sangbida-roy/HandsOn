using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefined_DataType
{
    public class Student
    {
        private string _FN;
        private string _LN;
        private int _rollno;
        private double _marks;

        public string FN
        {
            get
            {
                return _FN;
            }
            set
            {
                _FN = value;
            }
        }

        public string LN
        {
            get
            {
                return _LN;
            }
            set
            {
                _LN = value;
            }
        }

        public int RollNo
        {
            get
            {
                return _rollno;
            }
            set
            {
                _rollno = value;
            }
        }

        public double Marks
        {
            get
            {
                return _marks;
            }
            set
            {
                _marks = value;
            }
        } 
            

    }
}
