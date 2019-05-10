USE [Stuffworks]
GO

/****** Object:  Table [dbo].[SW_User_Types]    Script Date: 8/21/2017 10:54:53 PM ******/
DROP TABLE [dbo].[SW_User_Types]
GO

/****** Object:  Table [dbo].[SW_User_Types]    Script Date: 8/21/2017 10:54:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SW_User_Types](
	[Service_User] [int] NOT NULL,
	[Client_User] [int] NOT NULL,
	[Admintype] [int] NULL
) ON [PRIMARY]

GO


