using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Common;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Rooms.Model;
using HospitalLibrary.sharedModel;
using HospitalLibrary.TreatmentReports.Model;

namespace HospitalLibrary.Patients.Service
{
    public class PatientAdmissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientAdmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> GetAll()
        {
            return (List<PatientAdmission>)await _unitOfWork.PatientAdmissionRepository.GetAllAsync();
        }
        
        public async Task<PatientAdmission> GetById(Guid id)
        {
            var admission = await _unitOfWork.PatientAdmissionRepository.GetByIdAsync(id);
            await _unitOfWork.CompleteAsync();
            return admission;
        }
        
        public async Task<PatientAdmission> CreateAdmission(PatientAdmission admission)
        {
            List<RoomBed> beds = (List<RoomBed>)await _unitOfWork.RoomBedRepository.GetAllAsync();
            RoomBed bed = new RoomBed();
            Room room = new Room();
            Boolean bedExists = false;
            foreach (var b in beds) {
                if (b.IsFree)
                {
                    bed = b;
                    room = await _unitOfWork.RoomRepository.GetByIdAsync(b.RoomId);
                    bed.IsFree = false;
                    bedExists = true;
                    break;
                }
            }
            if (!(bedExists))
            {
                return null;
            }
            
            await _unitOfWork.RoomBedRepository.UpdateAsync(bed);
            admission.SelectedBedId = bed.Id;
            admission.SelectedRoomId = room.Id;
            TreatmentReport report = new TreatmentReport();
            report.PatientId = admission.PatientId;
            var newReport = await _unitOfWork.TreatmentReportRepository.CreateAsync(report);
            var newAdmission = await _unitOfWork.PatientAdmissionRepository.CreateAsync(admission);
            await _unitOfWork.CompleteAsync();
            return newAdmission;
        }

        public async Task<Boolean> IsHospitalized(PatientAdmission admission)
        {
            List<PatientAdmission> patientAdmissions = (List<PatientAdmission>)await _unitOfWork.PatientAdmissionRepository.GetAllAsync();
            foreach(var p in patientAdmissions)
            {
                if (p.PatientId.Equals(admission.PatientId) && p.DateOfDischarge == null)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Boolean> DiscargePatient(PatientAdmission admissionRequest)
        {
            var admission = await _unitOfWork.PatientAdmissionRepository.GetByIdAsync(admissionRequest.Id);
            if (admission == null) return false;
            admission.Update(admissionRequest.ReasonOfDischarge,admissionRequest.DateOfDischarge);
            await _unitOfWork.PatientAdmissionRepository.UpdateAsync(admission);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}