﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace elj.appdata
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class elJournalEntities : DbContext
    {
        public elJournalEntities()
            : base("name=elJournalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Shedule> Shedule { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentPerfomance> StudentPerfomance { get; set; }
        public virtual DbSet<StudGroup> StudGroup { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeachSubject> TeachSubject { get; set; }
        public virtual DbSet<TimeTable> TimeTable { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WeekDay> WeekDay { get; set; }
    }
}
