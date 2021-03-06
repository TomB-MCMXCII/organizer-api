﻿using Domain.Interfaces;
using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class DayDto : IDayDto
    {
        public ICollection<INoteDto> NoteDtos { get; set; }
        public ICollection<IToDoDto> ToDoDtos { get; set; }
        public ICollection<IScheduleEntryDto> ScheduleDtos { get; set; }
        public int id { get; set; }
        public string date { get; set; }
    }
}
