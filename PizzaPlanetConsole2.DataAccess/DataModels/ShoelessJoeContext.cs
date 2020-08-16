using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaPlanetConsole.DataAccess.DataModels
{
    public partial class ShoelessJoeContext : DbContext
    {
        public ShoelessJoeContext()
        {
        }

        public ShoelessJoeContext(DbContextOptions<ShoelessJoeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<FoodGroup> FoodGroup { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SecretConfig.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__CartItem__727E838B441DDCAD");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__CartId__3AD6B8E2");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__FoodId__3BCADD1B");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Comments__C3B4DFCA6FBDA2DE");

                entity.HasIndex(e => e.BuyerId);

                entity.HasIndex(e => e.ShoeId);

                entity.Property(e => e.CommentDate).HasColumnType("date");

                entity.Property(e => e.MessageBody)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MessageHead)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_Comments_Users");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comments_Shoes");
            });

            modelBuilder.Entity<FoodGroup>(entity =>
            {
                entity.Property(e => e.FoodGroups)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__Foods__856DB3EBDB51F486");

                entity.Property(e => e.FoodTitle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.FoodGroup)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Foods__FoodGroup__09746778");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__FoodI__2D7CBDC4");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__2C88998B");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF30569DAE");

                entity.Property(e => e.TotaLprice)
                    .HasColumnName("TotaLPrice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CartId__408F9238");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasIndex(e => e.CommentId);

                entity.HasIndex(e => e.ReplyUserId);

                entity.Property(e => e.ReplyBody)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyDate).HasColumnType("date");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Reply_Comments");

                entity.HasOne(d => d.ReplyUser)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.ReplyUserId)
                    .HasConstraintName("FK_Reply_Users");
            });

            modelBuilder.Entity<Shoes>(entity =>
            {
                entity.HasKey(e => e.ShoeId);

                entity.HasIndex(e => e.ShoeId)
                    .HasName("UQ__Shoes__5A835BF4B6C5383A")
                    .IsUnique();

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LeftSize).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Manufacter)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RightSize).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Shoes_Users");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Shopping__51BCD7B719BC83F1");

                entity.Property(e => e.TimeStamp).HasColumnType("date");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__Store__3DB3258D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__UserI__37FA4C37");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Orders__1788CC4C1FA06CB1");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
