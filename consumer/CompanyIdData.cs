namespace Consumer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// .
    /// </summary>
    public class CompanyIdData
    {
        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public ICollection<EnergyData> EnergyDatas { get; }
    }
}
