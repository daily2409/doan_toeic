namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<DOCUMENT> DOCUMENTs { get; set; }
        public virtual DbSet<LISTENNING> LISTENNINGs { get; set; }
        public virtual DbSet<NEWS> NEWS { get; set; }
        public virtual DbSet<PART> PARTs { get; set; }
        public virtual DbSet<PICTURE> PICTUREs { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<READING> READINGs { get; set; }
        public virtual DbSet<RESULT> RESULTs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TEST> TESTs { get; set; }
        public virtual DbSet<THEME> THEMEs { get; set; }
        public virtual DbSet<TITLE> TITLEs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<VOCABULARY> VOCABULARies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<LISTENNING>()
                .Property(e => e.LISTEN_URL)
                .IsUnicode(false);

            modelBuilder.Entity<LISTENNING>()
                .Property(e => e.PICTURE_URL)
                .IsUnicode(false);

            modelBuilder.Entity<LISTENNING>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.LISTENNING)
                .HasForeignKey(e => e.LIS_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LISTENNING>()
                .HasMany(e => e.TESTs)
                .WithOptional(e => e.LISTENNING)
                .HasForeignKey(e => e.LIS_ID);

            modelBuilder.Entity<PART>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<PART>()
                .HasMany(e => e.LISTENNINGs)
                .WithRequired(e => e.PART)
                .HasForeignKey(e => e.PAR_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PART>()
                .HasMany(e => e.READINGs)
                .WithRequired(e => e.PART)
                .HasForeignKey(e => e.PAR_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PICTURE>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<PICTURE>()
                .HasOptional(e => e.VOCABULARY)
                .WithRequired(e => e.PICTURE);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.ANSWER_A)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.ANSWER_B)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.ANSWER_C)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.ANSWER_D)
                .IsUnicode(false);

            modelBuilder.Entity<READING>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<READING>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.READING)
                .HasForeignKey(e => e.REA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<READING>()
                .HasMany(e => e.TESTs)
                .WithOptional(e => e.READING)
                .HasForeignKey(e => e.RED_ID);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.USERs)
                .WithRequired(e => e.ROLE)
                .HasForeignKey(e => e.ROL_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEME>()
                .HasMany(e => e.VOCABULARies)
                .WithRequired(e => e.THEME)
                .HasForeignKey(e => e.THE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TITLE>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<TITLE>()
                .HasMany(e => e.PARTs)
                .WithRequired(e => e.TITLE)
                .HasForeignKey(e => e.TIT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PHONE_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<VOCABULARY>()
                .Property(e => e.PIC_ID)
                .IsFixedLength();

            modelBuilder.Entity<VOCABULARY>()
                .Property(e => e.WORD)
                .IsUnicode(false);
        }
    }
}
