using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppCleanArch.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Tanggal")]
        public DateTime AttendanceDate { get; set; } = DateTime.Now;  // ← UBAH DARI Date
        
        [Required(ErrorMessage = "Status kehadiran harus dipilih")]
        [Display(Name = "Status Kehadiran")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Keterangan")]
        [StringLength(500, ErrorMessage = "Keterangan maksimal 500 karakter")]
        public string? Notes { get; set; }  // ← UBAH DARI Note
        
        // Foreign Keys
        [Required(ErrorMessage = "Student harus dipilih")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        
        [Required(ErrorMessage = "Course harus dipilih")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        
        // Navigation Properties
        public Student Student { get; set; } = null!;  // ← UBAH DARI nullable
        public Course Course { get; set; } = null!;     // ← UBAH DARI nullable
    }
}