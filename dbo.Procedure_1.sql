Create procedure [dbo].[DeleteAppointment]  
(  
   @Pid int  
)  
as   
begin  
   Delete from Appointment where Pid=@Pid  
End
