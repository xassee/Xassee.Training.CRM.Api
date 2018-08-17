using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Xassee.Training.CRM.Api.Models
{
    public class XasseeTrainingCRMApiContext : DbContext
    {
        public XasseeTrainingCRMApiContext (DbContextOptions<XasseeTrainingCRMApiContext> options)
            : base(options)
        {
        }

        public DbSet<Xassee.Training.CRM.Api.Models.Feedback> Feedback { get; set; }
    }
}
