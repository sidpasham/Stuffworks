USE [StuffWorks]
GO

/****** Object:  StoredProcedure [dbo].[SW_UpdateUserData]    Script Date: 8/4/2017 1:05:32 AM ******/
DROP PROCEDURE [dbo].[SW_UpdateUserData]
GO

/****** Object:  StoredProcedure [dbo].[SW_UpdateUserData]    Script Date: 8/4/2017 1:05:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SW_UpdateUserData]
(
	@userid int,
	@user_email nvarchar(50),
	@address1 nvarchar(100),
    @address2 nvarchar(100),
    @City nvarchar(50),
    @State nvarchar(50),
    @Pincode nvarchar(6)
)
AS
BEGIN

	DECLARE @returnValue int
	DECLARE @insertedValue int
	IF EXISTS(SELECT 1 FROM  SW_Addresses ad 
	join SW_User_Addresses ua ON ad.Address_ID=ua.Primary_Address_ID
	join SW_Users u on ua.User_ID=u.User_ID
	WHERE u.User_ID=@userid)
	BEGIN 

	update  ad set 
		ad.Address1=@address1,
		ad.Address2=@address2,
		ad.City=@City,
		ad.State=@State,
		ad.Zip=@Pincode
	FROM SW_Addresses ad 
	join SW_User_Addresses ua ON ad.Address_ID=ua.Primary_Address_ID
	join SW_Users u on ua.User_ID=u.User_ID
	WHERE u.User_ID=@userid
	set @returnValue = @@ROWCOUNT
	END
	ELSE
	BEGIN
		INSERT INTO SW_Addresses(Address1,Address2,City,State,Zip) 
		SELECT @address1,@address2,@City,@State,@Pincode

		set @insertedValue=SCOPE_IDENTITY()

		INSERT INTO SW_User_Addresses(User_ID,Primary_Address_ID)
		SELECT @userid,@insertedValue

		set @returnValue=SCOPE_IDENTITY()
	END

	return @returnValue

END
GO


