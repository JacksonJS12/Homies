﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Homies.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        [StringLength(150)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Organiser))]
        public Guid OrganiserId { get; set; }

        [Required]
        public virtual ApplicationUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();

    }
}