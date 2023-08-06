using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Utilities
{
    public class ModelJsonData
    {
        
    }
    public class EducationJsonData
    {
        public List<EducationRecords> Create { get; set; }
        public List<EducationRecords> Update1 { get; set; }
        public List<EducationRecords> Update2 { get; set; }
        public List<EducationRecords> Update3 { get; set; }
        public List<EducationRecords> Update4 { get; set; }
        public List<EducationRecords> Update5 { get; set; }
        public List<EducationRecords> Update6 { get; set; }
        public List<EducationRecords> Delete1 { get; set; }
    }

    public class EducationRecords
    {
        public string UniversityName { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string? Degree { get; set; }
        public int Year { get; set; }

    }

    public class CertificationJsonData
    {
        public List<CertificationRecords> Create { get; set; }       
        public List<CertificationRecords> Update1 { get; set; }
        public List<CertificationRecords> Update2 { get; set; }
        public List<CertificationRecords> Update3 { get; set; }
        public List<CertificationRecords> Update4 { get; set; }
        public List<CertificationRecords> Update5 { get; set; }
        public List<CertificationRecords> Update6 { get; set; }
        public List<CertificationRecords> Delete1 { get; set; }
    }

    public class CertificationRecords
    {
        public string Certificate { get; set; }
        public string CertifiedFrom { get; set; }       
        public int Year { get; set; }

    }
}
