﻿using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class InstalledProgramsRepository : BaseRepository<InstalledProgramsResponseModel>
    {
        public InstalledProgramsRepository(MongoDbContext dbContext) : base(dbContext, "ProgramsInfo")
        {
        }
    }
}