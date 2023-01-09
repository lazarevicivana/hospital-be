﻿using System;
using HospitalLibrary.Common.EventSourcing;

namespace HospitalLibrary.Examinations.DomainEvents
{
    public class SymptomsViewedEvent : DomainEvent
    {
        public SymptomsViewedEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}