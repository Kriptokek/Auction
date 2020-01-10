
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Entities;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DALContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DALContext db)
        {
        }
    } 
}