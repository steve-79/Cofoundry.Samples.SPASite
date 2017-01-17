﻿using Cofoundry.Core;
using Cofoundry.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Samples.SPASite.Data
{
    public partial class SPASiteDbContext : DbContext
    {
        #region constructor

        static SPASiteDbContext()
        {
            Database.SetInitializer<SPASiteDbContext>(null);
        }

        public SPASiteDbContext()
            : base(DbConstants.ConnectionStringName)
        {
            DbContextConfigurationHelper.SetDefaults(this);
        }

        #endregion

        #region properties

        public DbSet<CatLike> CatLikes { get; set; }
        public DbSet<CatLikeCount> CatLikeCounts { get; set; }

        #endregion

        #region mapping

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .UseDefaultConfig()
                .MapCofoundryUsers()
                .MapCofoundryEntityDefinitions()
                .MapCofoundryImageAssets()
                .MapCofoundryCustomEntities()
                .Map(new PageTemplateMap())
                .Map(new PageTemplateSectionMap())
                .Map(new ModuleTemplateMap())
                .Map(new PageModuleTypeMap())
                .Map(new PageGroupItemMap())
                .Map(new PageGroupMap())
                .Map(new PageVersionModuleMap())
                .Map(new PageMap())
                .Map(new PageTagMap())
                .Map(new PageVersionMap())
                .Map(new CatLikeMap())
                .Map(new CatLikeCountMap());
        }

        #endregion
    }
}