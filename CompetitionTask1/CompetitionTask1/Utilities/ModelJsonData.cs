namespace ConsoleApp2.Utilities
{
    public class ModelJsonData
    {

    }
    public class EducationJsonData
    {
        public List<EducationRecords> Create { get; set; }
        public List<EducationRecords> PositiveUpdate1 { get; set; }
        public List<EducationRecords> PositiveUpdate2 { get; set; }
        public List<EducationRecords> NegativeUpdate1 { get; set; }
        public List<EducationRecords> NegativeUpdate2 { get; set; }
        public List<EducationRecords> NegativeUpdate3 { get; set; }
        public List<EducationRecords> NegativeUpdate4 { get; set; }
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
        public List<CertificationRecords> PositiveCreateTest { get; set; }
        public List<CertificationRecords> NegativeCreateTest { get; set; }
        public List<CertificationRecords> PositiveUpdate1 { get; set; }
        public List<CertificationRecords> PositiveUpdate2 { get; set; }
        public List<CertificationRecords> NegativeUpdate1 { get; set; }
        public List<CertificationRecords> NegativeUpdate2 { get; set; }
        public List<CertificationRecords> NegativeUpdate3 { get; set; }
        public List<CertificationRecords> NegativeUpdate4 { get; set; }
        public List<CertificationRecords> Delete1 { get; set; }
    }

    public class CertificationRecords
    {
        public string Certificate { get; set; }
        public string CertifiedFrom { get; set; }
        public int Year { get; set; }

    }
    public class AddCertificationModel
    {
        public string Certificate { get; set; }
        public string CertifiedFrom { get; set; }
        public int Year { get; set; }

    }

}
