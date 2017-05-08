
namespace gmcscoServices.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    public class ContactMessage
    {
        [DataMember]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Company { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [DataMember]
        [MaxLength(12)]
        [Column(TypeName = "varchar")]
        public string PhoneNo { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Subject { get; set; }
        [DataMember]
        [Column(TypeName = "varchar")]
        public string Msg { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

    }




    [Table("Subscribe")]
    [DataContract]
    public class Subscribe
    {
        [DataMember]
        [Key]
        public int SubscriptionID { get; set; }
        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [MaxLength(35)]
        [Column(TypeName = "varchar")]
        public string IpAddress { get; set; }
   
    }

    #region ["Return Values"]
    [DataContract]
    public class ReturnValues
    {
        [DataMember]
        public string Success { get; set; }
        [DataMember]
        public string Failure { get; set; }

        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public bool Status { get; set; }


    }
    #endregion


    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string DepartmentName { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string OwnerEmail { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }


    }


}