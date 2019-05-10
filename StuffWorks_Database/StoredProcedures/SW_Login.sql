USE [StuffWorks]
GO

/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
DROP PROCEDURE [dbo].[SW_Users]
GO

/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SW_Login]
(
@user_email nvarchar(50),
@user_Password nvarchar(50)
)
AS
BEGIN
 IF EXISTS(SELECT 1 FROM [dbo].[SW_Users] WHERE User_Email = @user_email AND User_Password = @user_Password)
 BEGIN
	return 1
 END
 ELSE
 BEGIN
	return 0
 END
END
GO