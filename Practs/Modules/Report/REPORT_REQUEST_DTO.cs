using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.Report
{
    public class REPORT_REQUEST_DTO
    {
        [Key]
        public int ReportId { get; set; }

        public FirstPart? FirstPart { get; set; }
        public SecondPart? SecondPart { get; set; }
    }
}
