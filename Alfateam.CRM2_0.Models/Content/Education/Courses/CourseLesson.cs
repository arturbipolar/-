﻿using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses
{
    /// <summary>
    /// Сущность урока курса
    /// </summary>
    public class CourseLesson : AbsModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgPath { get; set; }

        public List<CourseLessonPart> Parts { get; set; } = new List<CourseLessonPart>();
    }
}
