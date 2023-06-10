Create procedure [dbo].[AddNewAppointment]  
(  
 @Pid int,
   @Pname nvarchar (50),  
   @AppointmentDate Date,  
   @Dname nvarchar (100)  
)  
as  
begin  
   Insert into Appointment values(@Pid,@Pname,@AppointmentDate,@Dname)  
End