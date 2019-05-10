USE [StuffWorks]
GO

/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
DROP PROCEDURE [dbo].[SW_GetUserData]
GO
/****** Object:  StoredProcedure [dbo].[SW_Register]    Script Date: 7/16/2017 4:47:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].SW_GetUserData
(
@user_email nvarchar(50)
)
AS
BEGIN
select u.*,ad.* from SW_Users u
left join SW_User_Addresses a on u.User_ID=a.User_ID
left join SW_Addresses ad on a.Primary_Address_ID=ad.Address_ID
where User_Email = @user_email
END
GO
