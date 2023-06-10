Create procedure [dbo].[UpdateAppointmentDetails]  
(  
   @Pid int,  
   @Pname nvarchar (50),  
   @AppointmentDate Date ,  
   @Dname nvarchar (100)  
)  
as  
begin  
   Update Appointment  
   set Pname=@Pname,  
   AppointmentDate=@AppointmentDate,  
   Dname=@Dname 
   where Pid=@Pid  
End

