using System;
using System.Collections.Generic;
using lib_postgres.CRUD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace lib_postgres
{
    public partial class libContext : DbContext
    {
        public StreamWriter logStream = new StreamWriter(DEPLOY.Deploy.Output_Directory + "\\libermundi.log", true);
        public override void Dispose()
        {
            logStream.Close();
            base.Dispose();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(DB_Agent.Get_Connection_String());
                optionsBuilder.LogTo(logStream.WriteLine, Microsoft.Extensions.Logging.LogLevel.Warning);
            }
        }
    }
}
