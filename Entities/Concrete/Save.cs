using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Save : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string VideoConferenceMemberPrice { get; set; }
        public string VideoConferenceNonMemberPrice { get; set; }
        public string OralPresentationMemberPrice { get; set; }
        public string OralPresentationNonMemberPrice { get; set; }
        public string VideoConferenceDescription { get; set; }
        public string ParticipationPriceServiceAdditionDescription { get; set; }
        public string Description { get; set; }
    }

}
