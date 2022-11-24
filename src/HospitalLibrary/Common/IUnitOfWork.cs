﻿using System;
using System.Threading.Tasks;
using HospitalLibrary.ApplicationUsers.Repository;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.BloodConsumptions.Repository;
using HospitalLibrary.BloodUnits.Repository;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.EquipmentMovement.Repository;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Holidays.Repository;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Prescriptions.Repository;
using HospitalLibrary.Rooms.Repository;
using HospitalLibrary.sharedModel.Repository;
using HospitalLibrary.TreatmentReports.Repository;

namespace HospitalLibrary.Common
{
    public interface IUnitOfWork : IDisposable,IAsyncDisposable
    {
        ISpecializationsRepository SpecializationsRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }

        IHolidayRepository HolidayRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IWorkingSchueduleRepository WorkingSchueduleRepository { get; }
        IFloorRepository FloorRepository { get; }
        IBuildingRepository BuildingRepository { get; }
        IGRoomRepository GRoomRepository { get; }
        IRoomRepository RoomRepository { get; }
        IApplicationUserRepository UserRepository { get; }
        IBloodUnitRepository BloodUnitRepository { get; }
        IBloodConsumptionRepository BloodConsumptionRepository { get; }
        
        IBloodPrescriptionRepository BloodPrescriptionRepository { get; }
        IPatientAdmissionRepository PatientAdmissionRepository { get; }
        
        IIEquipmentRepository EquipmentRepository { get; }
        ITreatmentReportRepository TreatmentReportRepository { get; }
        IRoomBedRepository RoomBedRepository { get; }
        IEquipmentMovementAppointmentRepository EquipmentMovementAppointmentRepository { get; }
        
        IAddressRepository AddressRepository { get; }
        IAllergenRepository AllergenRepository { get; }
        IMedicineRepository MedicineRepository { get; }

        T GetRepository<T>() where T : class;
        Task CompleteAsync();
    }
}