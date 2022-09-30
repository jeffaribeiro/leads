USE [FrameworkDigital]
GO

INSERT INTO [dbo].[Lead]
           ([ContactFirstName]
           ,[ContactLastName]
           ,[ContactPhoneNumber]
           ,[ContactEmail]
           ,[DateCreated]
           ,[Suburb]
           ,[Category]
           ,[Description]
           ,[Price]
           ,[Status])
     VALUES
           ('Jefferson'
           ,'Ribeiro'
           ,'+5521992705295'
           ,'jeffaribeiro@hotmail.com'
           ,GETDATE()
           ,'Rua Alexandre Ramos 29'
           ,'Pintura'
           ,'Pintura da sala'
           ,508
           ,0)

INSERT INTO [dbo].[Lead]
           ([ContactFirstName]
           ,[ContactLastName]
           ,[ContactPhoneNumber]
           ,[ContactEmail]
           ,[DateCreated]
           ,[Suburb]
           ,[Category]
           ,[Description]
           ,[Price]
           ,[Status])
     VALUES
           ('Thays'
           ,'Pachu'
           ,'+5521967415275'
           ,'thays.pachu@yahoo.com.br'
           ,GETDATE()
           ,'Rua Alexandre Ramos 29'
           ,'Pintura'
           ,'Pintura da sala'
           ,492
           ,0)

INSERT INTO [dbo].[Lead]
           ([ContactFirstName]
           ,[ContactLastName]
           ,[ContactPhoneNumber]
           ,[ContactEmail]
           ,[DateCreated]
           ,[Suburb]
           ,[Category]
           ,[Description]
           ,[Price]
           ,[Status])
     VALUES
           ('Mylena'
           ,'Bitencourt'
           ,'+5531999999999'
           ,'mylena.bitencourt@frameworkdigital.com.br'
           ,GETDATE()
           ,'Rua Alexandre Ramos 29'
           ,'Pintura'
           ,'Pintura da sala'
           ,500
           ,0)
GO


