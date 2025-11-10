using MedVault.BE.Data.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Context
{
    public static class ModelBuilderExtension
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
                    new Hospital
                    {
                        Id = 1,
                        HospitalName = "Wockhardt Hospital",
                        Address = " Kalawad Road Near St. Mary's High School, Rajkot, Gujarat 360007",
                        ContactNumber = 9876543210
                    },
                    new Hospital
                    {
                        Id = 2,
                        HospitalName = "CIGIS Hospital",
                        Address = "Mahapujadham Chowk, 150 Ft. Ring Road. Near Balaji Hall, Dholakiya School Road. Rajkot (Gujarat) India — 360004",
                        ContactNumber = 7896520143
                    },
                    new Hospital
                    {
                        Id = 3,
                        HospitalName = "Sterling Hospital",
                        Address = "Plot No.251, Police Station, 150 Feet Ring Rd, opp. Gandhigram, Dharam Nagar, Rajkot, Gujarat 360007",
                        ContactNumber = 9845671520
                    }
            );

            modelBuilder.Entity<DocumentCategory>().HasData(
                    new DocumentCategory
                    {
                        Id = 1,
                        DocumentCategoryName = "Consultation Report",
                    },
                    new DocumentCategory
                    {
                        Id = 2,
                        DocumentCategoryName = "Pathology"
                    },
                    new DocumentCategory
                    {
                        Id = 3,
                        DocumentCategoryName = "Radiology",
                    },
                    new DocumentCategory
                    {
                        Id = 4,
                        DocumentCategoryName = "Discharge Summary",
                    },
                    new DocumentCategory
                    {
                        Id = 5,
                        DocumentCategoryName = "Treatment Report",
                    },
                    new DocumentCategory
                    {
                        Id = 6,
                        DocumentCategoryName = "Prescription",
                    },
                    new DocumentCategory
                    {
                        Id = 7,
                        DocumentCategoryName = "Prescription",
                    }
            );
        }
    }
}