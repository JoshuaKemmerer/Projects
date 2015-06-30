﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Plasty.Models;

namespace Plasty.DAL
{
    public class PlastyDBInitializer : DropCreateDatabaseAlways<PlastyDbContext>
    {
        protected override void Seed(PlastyDbContext context)
        {

            context.Courses.AddOrUpdate(c => c.Id,
                new Course() { Id = 1, SubjectCode = "CS", CourseNumber = "360", Title = "Computer Systems Programming"},
                new Course() { Id = 2, SubjectCode = "CS", CourseNumber = "350", Title = "Systems Programming"},
                new Course() { Id = 3, SubjectCode = "CS", CourseNumber = "340", Title = "Web Application Development"} 
                );
            context.CoursesAvail.AddOrUpdate(c => c.Id,
                new CourseAvail()
                {
                    Id = 1,
                    TermId = 1,
                    CourseId = 1,
                    Section = "001",
                    Crn = "123456",
                    Days = "MWF",
                    Time = "11:00 AM - 11:50 AM",
                    Instructor = "William Mongan",
                    InstructionMethod = "Face-to-Face",
                    InstructionType = "Lecture",
                },
                new CourseAvail()
                {
                    Id= 2,
                    TermId = 1,
                    CourseId = 2,
                    Section = "001",
                    Crn = "123457",
                    Days = "TR",
                    Time = "11:00 AM - 11:50 AM",
                    Instructor = "Cody Smith",
                    InstructionMethod = "Face-to-Face",
                    InstructionType = "Lecture",
                },
                new CourseAvail()
                {
                    Id = 3,
                    TermId = 1,
                    CourseId = 3,
                    Section = "002",
                    Crn = "143457",
                    Days = "TR",
                    Time = "10:00 AM - 11:50 AM",
                    Instructor = "Joe Smith",
                    InstructionMethod = "Face-to-Face",
                    InstructionType = "Lecture",
                }
                );
            context.CoursesTaken.AddOrUpdate(c => c.Id,
                new CourseTaken()
                {
                    Id = 1,
                    UserId = 1,
                    CourseId = 1
                },
                new CourseTaken()
                {
                    Id = 1,
                    UserId = 1,
                    CourseId = 2
                });
            context.DegreeRequirements.AddOrUpdate(d => d.Id,
                new DegreeRequirement()
                {
                    Id = 1,
                    MajorId = 1,
                    EffectiveTermId = 1,
                    CourseId = 1
                });
            context.Enrollments.AddOrUpdate(e => e.Id,
                new Enrollment()
                {
                    Id = 1,
                    UserId = Guid.NewGuid(),
                    MajorId = 1,
                    TermId = 1
                });
            context.Majors.AddOrUpdate(m => m.Id,
                new Major()
                {
                    Id = 1,
                    Name = "Computer Science"
                });
            context.Terms.AddOrUpdate(t => t.Id,
                new Term()
                {
                    Id = 1,
                    Name = "Spring 2015",
                    Identity = "120125"
                });
        }
    }
}