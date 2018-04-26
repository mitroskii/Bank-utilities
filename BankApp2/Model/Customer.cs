using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp2.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(long id)
        {
            Id = id;
        }

        public Customer(string firstName, string lastName, long bankId)
        {
            Firstname = firstName;
            Lastname = lastName;
            BankId = bankId;
        }
        public override string ToString()
        {
            return $"{Id}, {Firstname} {Lastname}";
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Account> Account { get; set; }
    }
}
