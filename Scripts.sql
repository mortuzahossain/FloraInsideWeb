USE [FloraERP]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Faqs]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Param_Client]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Param_ClientType]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Param_JourneyBy]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Param_Project]
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_DL_Param_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Cont_EmergencyContacts]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContactsById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Cont_EmergencyContactsById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Faqs]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_FaqById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_FaqById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_Client]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_ClientById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientTypeById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_ClientTypeById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_ClientType]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_Param_JourneyBy]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Param_JourneyById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_Param_JourneyById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_Project]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ProjectById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_ProjectById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroupById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_Param_UserGroupById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_User_By_Email]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_User_By_Email]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Cont_EmergencyContacts]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Conv_TourRegister]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Conv_TourRegister]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Faqs]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Param_Client]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Param_ClientType]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Param_JourneyBy]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Param_Project]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_Param_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_In_UserLogin]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_In_UserLogin]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Cont_EmergencyContacts]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts_Deactieve]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Cont_EmergencyContacts_Deactieve]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Faqs]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_FaqVote]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_FaqVote]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Param_Client]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Param_ClientType]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Param_JourneyBy]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Param_Project]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_Param_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UserProfile]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_UserProfile]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UserProfileImage]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_UserProfileImage]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UsersProfile]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_UsersProfile]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_AllUserProfile_For_contactbook]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_AllUserProfile_For_contactbook]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_UserProfile_By_UserId]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Get_UserProfile_By_UserId]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UserPasswordById]    Script Date: 1/2/2021 1:01:51 AM ******/
DROP PROCEDURE [dbo].[sp_Up_UserPasswordById]
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UserPasswordById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2021-01-01
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_UserPasswordById]
	@UserId int,
	@Password varchar(300)
AS
BEGIN
	
UPDATE [dbo].[UserLogin]
   SET [Password] = @Password
 WHERE UserId = @UserId



	
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_UserProfile_By_UserId]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2021-01-01
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_UserProfile_By_UserId]
	@UserId int
AS
BEGIN
	


SELECT [UserId]
      ,[Name]
      ,[Email]
      ,[Phone]
      ,[BloodGroup]
      ,[MaritialStatus]
      ,[Designation]
      ,[Department]
      ,[PresentAddress]
      ,[PermanentAddress]
      ,[EmergencyContact]
      ,[Image]
      ,[Status]
      ,[JoiningDate]
      ,[FireId]
      ,[Nid]
      ,[AccountStatus]
  FROM [dbo].[UsersProfile] where UserId = @UserId



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_AllUserProfile_For_contactbook]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2021-01-01
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_AllUserProfile_For_contactbook]
	
AS
BEGIN
	



SELECT [UserId]
      ,[Name]
      ,[Email]
      ,[Phone]
      ,[BloodGroup]
      ,[MaritialStatus]
      ,[Designation]
      ,[Department]
      ,[PresentAddress]
      ,[PermanentAddress]
      ,[EmergencyContact]
      ,[Image]
      ,[Status]
      ,[JoiningDate]
      ,[FireId]
      ,[Nid]
      ,[AccountStatus]
  FROM [dbo].[UsersProfile]





END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UsersProfile]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_Up_UserProfileImage]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-31
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_UserProfileImage]
	  @UserId int,
      @Image varchar(50)
      
AS
BEGIN


	UPDATE [dbo].[UsersProfile]
	   SET [Name] = @Image
	 WHERE UserId = @UserId


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UserProfile]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-31
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_UserProfile]
	  @UserId int,
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
      @JoiningDate datetime,
      @FireId varchar(max),
      @Nid varchar(15),
      @AccountStatus varchar(max)
AS
BEGIN


	UPDATE [dbo].[UserLogin]
	   SET 
		  [LoginName] = @Name
	 WHERE  UserId = @UserId



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
		  ,[JoiningDate] = @JoiningDate
		  ,[FireId] = @FireId
		  ,[Nid] = @Nid
		  ,[AccountStatus] = @AccountStatus
	 WHERE UserId = @UserId


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	UPDATE [dbo].[Param_UserGroup]
	SET
		[Name] = @Name
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	UPDATE [dbo].[Param_Project]
	   SET
		  [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id






END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Up_Param_JourneyBy]
	@Id int,
	@Name varchar(50)
AS
BEGIN

	UPDATE [dbo].[Param_JourneyBy]
	SET
		[Name] = @Name
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	UPDATE [dbo].[Param_ClientType]
	   SET [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id


    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_Up_FaqVote]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-31
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Up_FaqVote]
	@Id int,
    @UpVote int
AS
BEGIN
	

	if @UpVote = 1
	begin
		UPDATE [dbo].[Faqs]
		   SET 
			  [UpVote] = (select UpVote+1 from Faqs)
		 WHERE Id = @Id
	 end
	 else
	 begin
		UPDATE [dbo].[Faqs]
		   SET 
			  [UpVote] = (select DownVote+1 from Faqs)
		 WHERE Id = @Id
	 end

END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
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
	
	UPDATE [dbo].[Faqs]
	   SET 
		  [Title] = @Title
		  ,[Description] = @Description
		  ,[ProjectId] = @ProjectId
		  ,[Status] = @Status
	 WHERE Id = @Id



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts_Deactieve]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Cont_EmergencyContacts_Deactieve] 
	@Id int,
    @Status int = 0
AS
BEGIN
	
   

	UPDATE [dbo].[Cont_EmergencyContacts]
	   SET 
		  [Status] = @Status 
	 WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	UPDATE [dbo].[Cont_EmergencyContacts]
	   SET [Name] = @Name 
		  ,[DisplayName] = @DisplayName 
		  ,[ContactNumber] = @ContactNumber 
		  ,[Descriptions] =@Descriptions 
		  ,[Status] = @Status 
	 WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_UserLogin]    Script Date: 1/2/2021 1:01:51 AM ******/
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
	@Email varchar(50),
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
	if not exists(select UserId from UserLogin where LoginId = @LoginId)
	begin

		declare @UserId int
		select @UserId = (isnull(max(UserId),0)+1) from UserLogin 

		
		Insert into UsersProfile (UserId,Name,Email) Values (@UserId,@LoginName,@Email)

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

/****** Object:  StoredProcedure [dbo].[sp_In_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_Project]
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN

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

/****** Object:  StoredProcedure [dbo].[sp_In_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_JourneyBy]
	@Name varchar(50)
AS
BEGIN
	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_JourneyBy 


	INSERT INTO [dbo].[Param_JourneyBy]
           ([Id]
           ,[Name])
     VALUES
           (@Id
           ,@Name)




END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_In_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_In_Conv_TourRegister]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-31
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Conv_TourRegister]
	@UserId int,
    @TDate datetime,
    @ToAddress varchar(250),
    @FromAddress varchar(250),
    @JourneyBy int,
    @Fare numeric(8,2),
    @Remarks varchar(150),
    @Lat varchar(22),
    @Lan varchar(22),
    @UpOrDown int,
    @TerminalId varchar(100) = '',
    @Status int = 1,
    @ClientId int,
    @IssueId varchar(250) = ''
AS
BEGIN


	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Conv_TourRegister 


	INSERT INTO [dbo].[Conv_TourRegister]
           ([Id]
           ,[UserId]
           ,[TDate]
           ,[ToAddress]
           ,[FromAddress]
           ,[JourneyBy]
           ,[Fare]
           ,[Remarks]
           ,[Lat]
           ,[Lan]
           ,[UpOrDown]
           ,[TerminalId]
           ,[Status]
           ,[ClientId]
           ,[SysDate]
           ,[IssueId])
     VALUES
           (@Id
           ,@UserId
           ,@TDate
           ,@ToAddress
           ,@FromAddress
           ,@JourneyBy
           ,@Fare
           ,@Remarks
           ,@Lat
           ,@Lan
           ,@UpOrDown
           ,@TerminalId
           ,@Status
           ,@ClientId
           ,GETDATE()
           ,@IssueId)


	
END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_Get_User_By_Email]    Script Date: 1/2/2021 1:01:51 AM ******/
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

    -- Insert statements for procedure here
	SELECT UserId,LoginId,LoginName,UserGroupId,pg.Name UserGroupName from UserLogin,Param_UserGroup pg
	where LoginId= @LoginId and Password = @Password and Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroupById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Get_Param_UserGroupById]
@Id int
AS
BEGIN

	select * from Param_UserGroup where Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	select * from Param_UserGroup


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ProjectById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Get_Param_ProjectById]
@Id int
AS
BEGIN

	select Id,Name,Remarks from Param_Project where Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
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
AS
BEGIN

	select Id,Name,Remarks from Param_Project


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Param_JourneyById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Get_Param_Param_JourneyById]
@Id int
AS
BEGIN

	select * from Param_JourneyBy where Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Get_Param_Param_JourneyBy]
AS
BEGIN

	select * from Param_JourneyBy


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	SELECT [Id]
      ,[Name]
      ,[Remarks]
	FROM [dbo].[Param_ClientType]



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientTypeById]    Script Date: 1/2/2021 1:01:51 AM ******/
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

create PROCEDURE [dbo].[sp_Get_Param_ClientTypeById]
	@Id int
AS
BEGIN

	SELECT [Id]
      ,[Name]
      ,[Remarks]
	FROM [dbo].[Param_ClientType] where Id = @Id



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_ClientById]
	@Id int
AS
BEGIN

	select pc.*,pt.Name as 'ClientTypeName' from Param_Client pc,Param_ClientType pt
	where pc.Status = 1 and pc.Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
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

	select pc.*,pt.Name as 'ClientTypeName' from Param_Client pc,Param_ClientType pt
	where pc.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_FaqById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Get_FaqById]
	@Id int
AS
BEGIN
	

   select f.*,p.Name as ProjectName from Faqs f,Param_Project p
   where p.Id = f.ProjectId and f.Status = 1 and f.Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
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
	

   select f.*,p.Name as ProjectName from Faqs f,Param_Project p
   where p.Id = f.ProjectId and f.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContactsById]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-30
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Cont_EmergencyContactsById]
	@Id int
AS
BEGIN
    SELECT Id,Name,DisplayName,ContactNumber,Descriptions from Cont_EmergencyContacts where Status = 1 and Id = @Id
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContacts]    Script Date: 1/2/2021 1:01:51 AM ******/
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
	SELECT Id,Name,DisplayName,ContactNumber,Descriptions from Cont_EmergencyContacts where Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_UserGroup]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_DL_Param_UserGroup]
	@Id int,
	@Name varchar(50)
AS
BEGIN

	DELETE FROM [dbo].[Param_UserGroup]
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_Project]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain	
-- Create date: 2020-12-31
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DL_Param_Project]
	@Id int
AS
BEGIN
	Delete From [dbo].[Param_Project]
	WHERE Id = @Id
END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_JourneyBy]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DL_Param_JourneyBy]
	@Id int,
	@Name varchar(50)
AS
BEGIN

	DELETE FROM [dbo].[Param_JourneyBy]
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_ClientType]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_DL_Param_ClientType] 
	@Id int
AS
BEGIN

	Delete FROM [dbo].[Param_ClientType]
	WHERE Id = @Id


END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Param_Client]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_DL_Param_Client]
	@Id int
AS
BEGIN

	Delete from [dbo].[Param_Client]
	  
	 WHERE Id = @Id




    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_DL_Faqs]    Script Date: 1/2/2021 1:01:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_DL_Faqs]
	@Id int
AS
BEGIN
	
	DELETE FROM [dbo].[Faqs]
	WHERE Id = @Id



END
GO

