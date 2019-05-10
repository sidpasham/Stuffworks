USE [StuffWorks]
GO

/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
DROP PROCEDURE [dbo].[SW_Register]
GO

/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SW_Register] 
(
@user_email nvarchar(50),
@full_Name nvarchar(50),
@user_Password nvarchar(50),
@user_Type int,
@phone nvarchar(16),
@user_ID int=0 Output
)
AS
BEGIN
declare @now datetime, @userId uniqueidentifier
set @now= GETDATE()

exec aspnet_Membership_CreateUser '/',@user_email, @user_Password,'',@user_email,'','',1,@now,@now,0,0,@userId output

INSERT INTO SW_Users(User_Name,User_Password,User_Email,User_Phone,Service_ID,Is_User_Type) 
SELECT @full_Name,@user_Password,@user_email,@phone,1,@user_Type

set @user_ID=SCOPE_IDENTITY()

END
GO


