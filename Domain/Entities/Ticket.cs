using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; private set; }
        public DateOnly CreationDate { get; private set; }
        public TimeOnly Time {  get; private set; }
        public string PhoneNumber { get; private set; }
        public string Governorate {  get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }

        public static async Task<Ticket> CreateTicket(string phoneNumber, string governorate, string city, string district)
        {
            return new Ticket
            {
                City = city,
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                District = district,
                Governorate = governorate,
                PhoneNumber = phoneNumber,
                Time = TimeOnly.FromDateTime(DateTime.Now)
            };
        }

    }
}
