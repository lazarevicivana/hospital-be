﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Doctors.Model;

namespace HospitalLibrary.Core.Model
{
    public class Room
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Number { get; set; }
        [Range(1, 10)]
        
        public Doctor Doctor { get; set; }
        
        // public Guid BuildingId { get; set; }//delete
        // public Building Building { get; set; }//delete
        
        public Guid FloorId { get; set; }
        public Floor Floor { get; set; }
        
        public string BuildingName { get; set; }//delete
        public string FloorName { get; set; }//delete
        public  int PositionX { get; set; }//delete
        
        public  int PositionY { get; set; }//delete
        
        public  int Lenght { get; set; }//delete
        
        public  int Width { get; set; }//delete
        /*public Guid FloorPlanViewId { get; set; }
        public FloorPlanView FloorPlanView { get; set; }*/
        

    }
}
