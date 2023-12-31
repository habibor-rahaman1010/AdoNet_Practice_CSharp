﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkExample
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public uint Fees { get; set; }
        public Instructor CourseInstructor {  get; set; }
        public List<Topic> Topics { get; set; }
        public List<CourseStudent> Students { get; set; }
    }
} 
