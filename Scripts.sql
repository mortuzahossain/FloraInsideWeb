USE [FloraERP]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Cont_EmergencyContacts]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,Name,DisplayName,ContactNumber,Descriptions from Cont_EmergencyContacts where Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Faqs]
	
AS
BEGIN
	
	SET NOCOUNT ON;

   select f.*,p.Name as ProjectName from Faqs f,Param_Project p
   where p.Id = f.ProjectId and f.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_Client]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select pc.*,pt.Name from Param_Client pc,Param_ClientType pt
	where pc.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================

-- exec sp_Get_Param_ClientType

CREATE PROCEDURE [dbo].[sp_Get_Param_ClientType]
	
AS
BEGIN
	SET NOCOUNT ON;



	SELECT [Id]
      ,[Name]
      ,[Remarks]
	FROM [dbo].[Param_ClientType]



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_Project]
	@Id int,
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	select * from Param_Project


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_UserGroup]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	select * from Param_UserGroup


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_User_By_Email]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_User_By_Email]
	@LoginId varchar(50),
	@Password varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserId,LoginId,LoginName,UserGroupId,pg.Name UserGroupName from UserLogin,Param_UserGroup pg
	where LoginId= @LoginId and Password = @Password and Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Cont_EmergencyContacts]
	@Name  nvarchar(50),
    @DisplayName nvarchar(50),
    @ContactNumber varchar(15),
    @Descriptions nvarchar(max),
    @Status int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Cont_EmergencyContacts


	INSERT INTO [dbo].[Cont_EmergencyContacts]
           ([Id]
           ,[Name]
           ,[DisplayName]
           ,[ContactNumber]
           ,[Descriptions]
           ,[Status]
           ,[CreatedDate])
     VALUES
           (@Id
           ,@Name
           ,@DisplayName
           ,@ContactNumber
           ,@Descriptions
           ,@Status
           ,GETDATE())


END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Faqs]
	
           @Title  nvarchar(250),
           @Description nvarchar(max),
           @ProjectId int,
           @Status int = 1,
           @UpVote int = 0,
           @DownVote int = 0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Faqs 


	INSERT INTO [dbo].[Faqs]
           ([Id]
           ,[Title]
           ,[Description]
           ,[ProjectId]
           ,[Status]
           ,[UpVote]
           ,[DownVote])
     VALUES
           (@Id
           ,@Title
           ,@Description
           ,@ProjectId
           ,@Status
           ,@UpVote
           ,@DownVote)






END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_Client] 
	
	@Name varchar(150),
    @DisplayName varchar(150),
    @ClientTypeId int,
    @Address varchar(150),
    @Lat varchar(50),
    @Lan varchar(50),
    @Status int = 1,
    @ContactNo1 varchar(15),
    @ContactNo2 varchar(15) = '',
    @Email varchar(50) = '',
    @Website varchar(50) = '',
    @Logo varchar(max) = '',
    @Details varchar(250) = ''


AS
BEGIN
	SET NOCOUNT ON;

  
	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_Client 


	INSERT INTO [dbo].[Param_Client]
           ([Id]
           ,[Name]
           ,[DisplayName]
           ,[ClientTypeId]
           ,[Address]
           ,[Lat]
           ,[Lan]
           ,[Status]
           ,[ContactNo1]
           ,[ContactNo2]
           ,[Email]
           ,[Website]
           ,[Logo]
           ,[Details])
     VALUES
           (@Id
           ,@Name
           ,@DisplayName
           ,@ClientTypeId
           ,@Address
           ,@Lat
           ,@Lan
           ,@Status
           ,@ContactNo1
           ,@ContactNo2
           ,@Email
           ,@Website
           ,@Logo
           ,@Details)





END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	Insert Param ClientType 
-- =============================================

-- sp_In_Param_ClientType 'Government School','Government Non Finintial Organigation'


CREATE PROCEDURE [dbo].[sp_In_Param_ClientType] 
	@Name  varchar(50),
    @Remarks varchar(150)
AS
BEGIN

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_ClientType 


	INSERT INTO [dbo].[Param_ClientType]
           ([Id]
           ,[Name]
           ,[Remarks])
     VALUES
           (@Id
           ,@Name
           ,@Remarks)



END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_Project]
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_Project 


	INSERT INTO [dbo].[Param_Project]
           ([Id]
           ,[Name]
           ,[Remarks])
     VALUES
           (@Id
           ,@Name
           ,@Remarks)



END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_UserGroup]
	@Name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_UserGroup 


	INSERT INTO [dbo].[Param_UserGroup]
           ([Id]
           ,[Name])
     VALUES
           (@Id
           ,@Name)




END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_UserLogin]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================

-- exec sp_In_UserLogin 'Mortuza Hossain','admin','PJkJr+wlNU1VHa4hWQuybjjVPyFzuNPcPu5MBH56scHri4UQPjvnumE7MbtcnDYhTcnxSkL9ei/bhIVrylxEwg==',1

CREATE PROCEDURE [dbo].[sp_In_UserLogin]
	
	@LoginName  varchar(50),
    @LoginId  varchar(50),
    @Password  varchar(300),
    @UserGroupId  int,
    @IsLogin  int = 0,
    @IsLogOut int = 0,
    @LatLan varchar(44) = '',
	@Status int = 1

AS
BEGIN
	SET NOCOUNT ON;

	
	if not exists(select UserId from UserLogin where LoginId = @LoginId)
	begin

		declare @UserId int
		select @UserId = (isnull(max(UserId),0)+1) from UserLogin 

		
		Insert into UsersProfile (UserId,Name) Values (@UserId,@LoginName)

		INSERT INTO [dbo].[UserLogin]
			   ([UserId]
			   ,[LoginName]
			   ,[LoginId]
			   ,[Password]
			   ,[UserGroupId]
			   ,[CreateDate]
			   ,[IsLogin]
			   ,[LoginTime]
			   ,[IsLogOut]
			   ,[LogOutTime]
			   ,[LatLan]
			   ,[Status])
		 VALUES
			   (@UserId
			   ,@LoginName
			   ,@LoginId
			   ,@Password
			   ,@UserGroupId
			   ,GETDATE()
			   ,@IsLogin
			   ,GETDATE()
			   ,@IsLogOut
			   ,GETDATE()
			   ,@LatLan
			   ,@Status)


	end
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Cont_EmergencyContacts] 
	@Id int,
	@Name  nvarchar(50),
    @DisplayName nvarchar(50),
    @ContactNumber varchar(15),
    @Descriptions nvarchar(max),
    @Status int = 1
AS
BEGIN
	
	SET NOCOUNT ON;

   

	UPDATE [dbo].[Cont_EmergencyContacts]
	   SET [Name] = @Name 
		  ,[DisplayName] = @DisplayName 
		  ,[ContactNumber] = @ContactNumber 
		  ,[Descriptions] =@Descriptions 
		  ,[Status] = @Status 
	 WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Faqs]
	@Id int,
    @Title  nvarchar(250),
    @Description nvarchar(max),
    @ProjectId int,
    @Status int = 1


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	
	UPDATE [dbo].[Faqs]
	   SET 
		  [Title] = @Title
		  ,[Description] = @Description
		  ,[ProjectId] = @ProjectId
		  ,[Status] = @Status
	 WHERE Id = @Id



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_Client]
	@Id int,
	@Name varchar(150),
    @DisplayName varchar(150),
    @ClientTypeId int,
    @Address varchar(150),
    @Lat varchar(50),
    @Lan varchar(50),
    @Status int = 1,
    @ContactNo1 varchar(15),
    @ContactNo2 varchar(15) = '',
    @Email varchar(50) = '',
    @Website varchar(50) = '',
    @Logo varchar(max) = '',
    @Details varchar(250) = ''
AS
BEGIN
	SET NOCOUNT ON;



	UPDATE [dbo].[Param_Client]
	   SET [Name] = @Name
		  ,[DisplayName] = @DisplayName
		  ,[ClientTypeId] = @ClientTypeId
		  ,[Address] = @Address
		  ,[Lat] = @Lat
		  ,[Lan] = @Lan
		  ,[Status] = @Status
		  ,[ContactNo1] = @ContactNo1
		  ,[ContactNo2] = @ContactNo2
		  ,[Email] = @Email
		  ,[Website] = @Website
		  ,[Logo] = @Logo
		  ,[Details] = @Details
	 WHERE Id = @Id




    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_ClientType] 
	@Id int,
	@Name  varchar(50),
    @Remarks varchar(150)
AS
BEGIN
	
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_ClientType]
	   SET [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id


    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_Project]
	@Id int,
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_Project]
	   SET
		  [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id






END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_UserGroup]
	@Id int,
	@Name varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_UserGroup]
	SET
		[Name] = @Name
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UsersProfile]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_UsersProfile]
	@UserId  int,
	@Name varchar(50),
	@Email varchar(50),
	@Phone varchar(15),
	@BloodGroup varchar(3),
	@MaritialStatus varchar(1),
	@Designation varchar(50),
	@Department varchar(50),
	@PresentAddress varchar(max),
	@PermanentAddress varchar(max),
	@EmergencyContact varchar(15),
	@Image varchar(50),
	@JoiningDate datetime,
	@FireId varchar(max),
	@Nid varchar(15),
	@AccountStatus int
AS
BEGIN
	SET NOCOUNT ON;



	UPDATE [dbo].[UsersProfile]
	   SET [Name] = @Name
		  ,[Email] = @Email
		  ,[Phone] = @Phone
		  ,[BloodGroup] = @BloodGroup
		  ,[MaritialStatus] = @MaritialStatus
		  ,[Designation] = @Designation
		  ,[Department] = @Department
		  ,[PresentAddress] = @PresentAddress
		  ,[PermanentAddress] = @PermanentAddress
		  ,[EmergencyContact] = @EmergencyContact
		  ,[Image] = @Image
		  ,[JoiningDate] = @JoiningDate
		  ,[FireId] = @FireId
		  ,[Nid] = @Nid
		  ,[AccountStatus] = @AccountStatus
	 WHERE UserId = @UserId




END
GO

