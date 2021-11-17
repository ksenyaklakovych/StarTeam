using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StarForum.Domain.Abstract;

namespace StarForum.Infrastructure
{
    public class StarForumContext : DbContext
    {
        public StarForumContext(DbContextOptions<StarForumContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarForumContext).Assembly);
        }
    }
}